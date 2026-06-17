using ProcessSystemLib;
using ProcessSystemLib.SqlServer;
using ProcessSystemLib.Model;
using System;

namespace ProcessSystem
{
    public class DualValveInterlock
    {
        private InterlockState _currentState = InterlockState.None;
        private bool _isRpHolding = false;
        private string _hostName = Environment.MachineName; // 当前机器名

        public string SensorName { get; }

        public ushort Valve1Dq { get; }
        private TCPManager _tcpManager1;
        public byte TcpGroup1 { get; }

        public ushort Valve2Dq { get; }
        private TCPManager _tcpManager2;
        public byte TcpGroup2 { get; }

        private LockDataService _lockDataService;
        private Func<double> _getSensorValue;
        private LockModel _cachedConfig;

        public DualValveInterlock(
            string sensorName,
            ushort valve1Dq, TCPManager tcpManager1,
            ushort valve2Dq, TCPManager tcpManager2,
            LockDataService lockDataService,
            Func<double> getSensorValue,
            byte tcpGroup1 = 1,
            byte tcpGroup2 = 1)
        {
            SensorName = sensorName;
            Valve1Dq = valve1Dq;
            _tcpManager1 = tcpManager1;
            TcpGroup1 = tcpGroup1;

            Valve2Dq = valve2Dq;
            _tcpManager2 = tcpManager2;
            TcpGroup2 = tcpGroup2;

            _lockDataService = lockDataService;
            _getSensorValue = getSensorValue;
        }
        public void SyncDbConfig()
        {
            var res = _lockDataService.QueryLockValue(SensorName);
            if (res.IsSuccess && res.Content != null)
            {
                _cachedConfig = res.Content;
            }
        }

        public void CheckAndExecute()
        {
            if (_tcpManager1 == null || !_tcpManager1.IsConnected ||
                _tcpManager2 == null || !_tcpManager2.IsConnected) return;

            if (_cachedConfig == null || !_cachedConfig.IsLocked)
            {
                if (_currentState != InterlockState.None)
                {
                    ResetState();
                }
                return;
            }

            double currentValue = _getSensorValue();
            InterlockState newState = CalculateState(currentValue, _cachedConfig.AlarmLow, _cachedConfig.AlarmMid, _cachedConfig.AlarmHigh);

            if (newState != _currentState)
            {
                if (_lockDataService.TryAcquireExecutionLock(SensorName, _hostName))
                {
                    ApplyState(newState);
                    _currentState = newState;
                }
                else
                {

                    _currentState = newState;
                }
            }
        }

        private InterlockState CalculateState(double value, float low, float mid, float high)
        {
            if (value < low)
            {
                _isRpHolding = false;
                return InterlockState.Low;
            }

            if (value > high)
            {
                _isRpHolding = true;
                return InterlockState.HighBoth;
            }

            if (!_isRpHolding)
            {
                if (value > mid)
                    return InterlockState.HighSingle;
            }
            else
            {
                return InterlockState.HighBoth;
            }

            return _currentState;
        }

        public void ResetState()
        {
            _currentState = InterlockState.None;
            _isRpHolding = false;

            _lockDataService.ReleaseExecutionLock(SensorName, _hostName);
        }

        private void ApplyState(InterlockState state)
        {
            switch (state)
            {
                case InterlockState.Low:
                    _tcpManager1.Send_PLC_Command(TcpGroup1, Valve1Dq, false);
                    _tcpManager2.Send_PLC_Command(TcpGroup2, Valve2Dq, false);
                    break;

                case InterlockState.HighBoth:
                    _tcpManager1.Send_PLC_Command(TcpGroup1, Valve1Dq, true);
                    _tcpManager2.Send_PLC_Command(TcpGroup2, Valve2Dq, true);
                    break;

                case InterlockState.HighSingle:
                    _tcpManager1.Send_PLC_Command(TcpGroup1, Valve1Dq, true);
                    _tcpManager2.Send_PLC_Command(TcpGroup2, Valve2Dq, false);
                    break;
            }
        }
    }
}