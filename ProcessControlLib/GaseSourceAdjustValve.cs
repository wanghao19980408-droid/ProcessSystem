using ProcessSystemLib;
using ProcessSystemLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessControlLib
{

    public partial class GaseSourceAdjustValve : UserControl, IAdjustValve
    {
        public GaseSourceAdjustValve()
        {
            InitializeComponent();
            this.button1.Click += button1_Click;
        }
        private string valveName { get; set; } = "调节阀";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门名称")]
        public string ValveName
        {
            get
            {
                return valveName;
            }
            set
            {
                if (valveName != value)
                {
                    this.label1.Text = value;
                    valveName = value;
                }

            }
        }
        private bool adjustFeedback { get; set; }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置调节阀反馈(正/反逻辑)")]
        public bool AdjustFeedback
        {
            get
            {
                return adjustFeedback;
            }
            set
            {
                if (adjustFeedback != value)
                {
                    adjustFeedback = value;
                    if (value)
                    {
                        this.ucComboBoxcs1.MinSensorRange = 0;
                        this.ucComboBoxcs1.MaxSensorRange = 100;
                    }
                    else
                    {
                        this.ucComboBoxcs1.MinSensorRange = 100;
                        this.ucComboBoxcs1.MaxSensorRange = 0;
                    }
                }

            }
        }

        private bool adjustType { get; set; } = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置调节阀类型(全开/全关)")]
        public bool AdjustType
        {
            get
            {
                return adjustType;
            }
            set
            {
                if (adjustType != value)
                {
                    adjustType = value;
                }
            }
        }

        private string adjustValue { get; set; }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置开度反馈")]
        public string AdjustValue
        {
            get
            {
                return adjustValue;
            }
            set
            {
                this.ucComboBoxcs1.SensorValue = value;
                adjustValue = value;
            }
        }

        private ushort adjustAI { get; set; }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置AI")]
        public ushort AdjustAI
        {
            get
            {
                return adjustAI;
            }
            set
            {
                adjustAI = value;
            }
        }
        private ushort adjustAQ { get; set; }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置AI")]
        public ushort AdjustAQ
        {
            get
            {
                return adjustAQ;
            }
            set
            {
                adjustAQ = value;
            }
        }

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("所属PLC")]
        public string PLCRegion
        {
            get => "气源PLC";
        }

        [Browsable(true)]
        [Category("自定义事件")]
        [Description("操控阀门触发事件")]
        public event EventHandler<AdjustInfo> AdjustValveClick;
        protected virtual void OnFiringIAdjustClick(AdjustInfo e)
        {
            AdjustValveClick?.Invoke(this, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (AdjustValveClick != null)
            {
                var eventArgs = new AdjustInfo
                {
                    ValveName = valveName,
                    PLCRegion = PLCRegion,
                    AdjustType = adjustType,
                    AdjustAI = adjustAI,
                    AdjustAQ = adjustAQ,
                    InputValue = this.textBox1.Text
                };
                OnFiringIAdjustClick(eventArgs);
            }
        }
    }
}
