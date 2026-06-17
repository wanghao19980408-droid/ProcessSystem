using ProcessSystemLib;
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
    public partial class GaseSourceElectricSwitchCombo : UserControl, IElectricControlValveBase
    {
        public GaseSourceElectricSwitchCombo()
        {
            InitializeComponent();
        }

        private string valveName { get; set; } = "开关阀";
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
        private ushort diOpenAndClose;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门开关阀DI序号")]
        public ushort DiOpenAndClose
        {
            get => diOpenAndClose;
            set
            {
                if (diOpenAndClose != value)
                {
                    diOpenAndClose = value;
                }
            }
        }
        private bool enable { get; set; }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置使用权限")]
        public bool Enable
        {
            get
            {
                return enable;
            }
            set
            {
                if (enable != value)
                {
                    enable = value;
                    this.button1.Enabled = enable;
                    if (!enable)
                    {
                        this.button1.Cursor = Cursors.No;
                    }
                }
            }
        }

        private string workStation { get; set; }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置所属工位")]
        public string WorkStation
        {
            get
            {
                return workStation;
            }
            set
            {
                if (workStation != value)
                {
                    workStation = value;
                }
            }
        }

        private ValveState state = ValveState.close;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门状态")]
        public ValveState State
        {
            get { return state; }
            set
            {

                if (state != value)
                {
                    state = value;
                    button1.Text = value == ValveState.open ? "关阀" : "开阀";
                    button1.Style = value == ValveState.open ? Sunny.UI.UIStyle.Red : Sunny.UI.UIStyle.Blue;
                }
            }
        }

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("所属PLC")]
        public string PLCRegion
        {
            get => "气源PLC";
        }

        private ushort dqOpen;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门开阀DQ序号")]
        public ushort DqOpen
        {
            get => dqOpen;
            set
            {
                if (dqOpen != value)
                {
                    dqOpen = value;
                }
            }
        }

        private ushort dqClose;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门关阀DQ序号")]
        public ushort DqClose
        {
            get => dqClose;
            set
            {
                if (dqClose != value)
                {
                    dqClose = value;
                }
            }
        }


        [Browsable(true)]
        [Category("自定义事件")]
        [Description("操控阀门触发事件")]
        public event EventHandler ValveClick;
        protected virtual void OnGaseSourceElectricSwitchComboClick(EventArgs e)
        {
            ValveClick?.Invoke(this, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValveClick != null)
            {
                OnGaseSourceElectricSwitchComboClick(e);
            }
        }

    }
}
