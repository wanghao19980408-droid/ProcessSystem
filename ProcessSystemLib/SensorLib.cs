using ProcessSystemLib.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public class SensorLib
    {
        public static void PrepareSensorValue<T>(UDPValues e, IList<T> sensorList) where T : ISensorBase
        {
            int aiLen = e.AI_value?.Length ?? 0;

            for (int i = 0; i < sensorList.Count; i++)
            {
                if (!UInt16.TryParse(sensorList[i].AI.ToString(), out UInt16 ai))
                    continue;

                if (ai >= aiLen)
                    continue;

                sensorList[i].SensorValue = e.AI_value[ai].ToString();
                AlarmLib.CheckSensorAlarm(sensorList[i].SensorName, sensorList[i].PhysicalValue);
            }
        }

        public static void PrepareHighSensorValue<T>(UDPValues e, IList<T> sensorList) where T : ISensorBase
        {
            int aiLen = e.HIGH_AI_value?.Length ?? 0;

            for (int i = 0; i < sensorList.Count; i++)
            {
                if (!UInt16.TryParse(sensorList[i].AI.ToString(), out UInt16 ai))
                    continue;

                if (ai >= aiLen)
                    continue;

                sensorList[i].SensorValue = (e.HIGH_AI_value[ai] / 1000.0f).ToString();
            }
        }
    }
}
