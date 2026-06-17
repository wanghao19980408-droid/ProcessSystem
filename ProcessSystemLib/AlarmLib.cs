using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessSystemLib
{
    public class AlarmConfig
    {
        public string SensorName { get; set; }

        public float? LowThreshold { get; set; }
        public float? HighThreshold { get; set; }
        public float? HHighThreshold { get; set; }

        public string LowDetail { get; set; }
        public string HighDetail { get; set; }
        public string HHighDetail { get; set; }

        public bool LowAlarmTriggered { get; set; }
        public bool HighAlarmTriggered { get; set; }
        public bool HHighAlarmTriggered { get; set; }
    }

    public class AlarmLib
    {
        public static Action<int, string> AddAlarmLog;

        private static readonly Dictionary<string, AlarmConfig> _alarmConfigs = new Dictionary<string, AlarmConfig>();

        public static void CheckSensorAlarm(string sensorName, double currentValue)
        {
            if (!_alarmConfigs.TryGetValue(sensorName, out var config))
                return;

            StringBuilder alarmMessage = null;

            if (config.LowThreshold.HasValue)
            {
                if (currentValue < config.LowThreshold.Value && !config.LowAlarmTriggered)
                {
                    config.LowAlarmTriggered = true;
                    if (alarmMessage == null) alarmMessage = new StringBuilder();

                    alarmMessage.AppendLine($"【低报警】{sensorName} 低于阈值{config.LowThreshold.Value:F2}");
                    if (!string.IsNullOrEmpty(config.LowDetail))
                        alarmMessage.AppendLine($"  报警详情: {config.LowDetail}");
                }
                else if (currentValue >= config.LowThreshold.Value && config.LowAlarmTriggered)
                {
                    config.LowAlarmTriggered = false;
                    AddAlarmLog?.Invoke(0, $"{sensorName} 低报警恢复，当前值{currentValue:F2}");
                }
            }

            if (config.HighThreshold.HasValue)
            {
                if (currentValue > config.HighThreshold.Value && !config.HighAlarmTriggered)
                {
                    config.HighAlarmTriggered = true;
                    if (alarmMessage == null) alarmMessage = new StringBuilder();

                    alarmMessage.AppendLine($"【高报警】{sensorName} 超过阈值{config.HighThreshold.Value:F2}");
                    if (!string.IsNullOrEmpty(config.HighDetail))
                        alarmMessage.AppendLine($"  报警详情: {config.HighDetail}");
                }
                else if (currentValue <= config.HighThreshold.Value && config.HighAlarmTriggered)
                {
                    config.HighAlarmTriggered = false;
                    AddAlarmLog?.Invoke(0, $"{sensorName} 高报警恢复，当前值{currentValue:F2}");
                }
            }

            if (config.HHighThreshold.HasValue)
            {
                if (currentValue > config.HHighThreshold.Value && !config.HHighAlarmTriggered)
                {
                    config.HHighAlarmTriggered = true;
                    if (alarmMessage == null) alarmMessage = new StringBuilder();

                    alarmMessage.AppendLine($"【高高报警】{sensorName} 超过阈值{config.HHighThreshold.Value:F2}");
                    if (!string.IsNullOrEmpty(config.HHighDetail))
                        alarmMessage.AppendLine($"  报警详情: {config.HHighDetail}");
                }
                else if (currentValue <= config.HHighThreshold.Value && config.HHighAlarmTriggered)
                {
                    config.HHighAlarmTriggered = false;
                    AddAlarmLog?.Invoke(0, $"{sensorName} 高高报警恢复，当前值{currentValue:F2}");
                }
            }

            if (alarmMessage != null && alarmMessage.Length > 0)
            {
                TriggerAlarm(alarmMessage.ToString().TrimEnd('\n'));
            }
        }

        public static void ProcessSensors(List<Dictionary<string, object>> sensors)
        {
            foreach (var sensor in sensors)
            {
                if (!sensor.TryGetValue("Name", out object nameObj) || nameObj == null)
                    continue;

                string sensorName = nameObj.ToString().Trim();
                if (string.IsNullOrEmpty(sensorName))
                    continue;

                if (!_alarmConfigs.TryGetValue(sensorName, out var config))
                {
                    config = new AlarmConfig { SensorName = sensorName };
                    _alarmConfigs[sensorName] = config;
                }

                config.LowThreshold = ParseThreshold(sensor, "AlarmLowThreshold");
                config.HighThreshold = ParseThreshold(sensor, "AlarmHighThreshold");
                config.HHighThreshold = ParseThreshold(sensor, "AlarmHHighThreshold");

                config.LowDetail = GetStringValue(sensor, "LDetails");
                config.HighDetail = GetStringValue(sensor, "HDetails");
                config.HHighDetail = GetStringValue(sensor, "HHDetails");
            }
        }


        private static float? ParseThreshold(Dictionary<string, object> dict, string key)
        {
            if (dict.TryGetValue(key, out object val) && val != null)
            {
                string strVal = val.ToString();
                if (strVal != "无" && float.TryParse(strVal, out float threshold))
                {
                    return threshold;
                }
            }
            return null;
        }

        private static string GetStringValue(Dictionary<string, object> dict, string key)
        {
            return dict.TryGetValue(key, out object val) && val != null ? val.ToString() : string.Empty;
        }

        private static void TriggerAlarm(string alarmMsg)
        {
            AddAlarmLog?.Invoke(1, alarmMsg);
        }
    }
}