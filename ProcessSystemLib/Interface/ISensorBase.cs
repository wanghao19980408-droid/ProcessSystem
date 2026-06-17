using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Interface
{
    public interface ISensorBase
    {
        string SensorName { get; set; }

        float SpeedValue { get; set; }

        float MinSensorRange { get; set; }

        float MaxSensorRange { get; set; }

        string SensorValue { get; set; }
        Unit Unit { get; set; }
        bool IsPT100 { get; set; }
        Unit OriginalPressureUnit { get; set; }

        int DecimalPlaces { get; set; }

        double PhysicalValue { get;}


        float Density { get; set; }

        ushort AI { get; set; }

        int DigitalRange { get; set; }

        InputValueType InputType { get; set; }

        CurrentRange CurrentRange { get; set; }

        VoltageRange VoltageRange { get; set; }
        bool TFMState { get; set; }
    }
}
