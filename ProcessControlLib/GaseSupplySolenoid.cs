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
    public partial class GaseSupplySolenoid : UserControl, IAirControlValveBase
    {
        public GaseSupplySolenoid()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("操控阀门触发事件")]
        public event EventHandler ValveClick;
        protected virtual void OnGaseSupplySolenoidClick(EventArgs e)
        {
            ValveClick?.Invoke(this, e);
        }
        private void GaseSupplySolenoid_Click(object sender, EventArgs e)
        {
            if (ValveClick != null)
            {
                OnGaseSupplySolenoidClick(e);
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
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置PLC")]
        public string PLCRegion
        {
            get
            {
                return "配气PLC";
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
                    this.panel1.Enabled = enable;
                    if (!enable)
                    {
                        this.panel1.Cursor = Cursors.No;
                    }
                }
            }
        }

        private string valveName { get; set; } = "电磁阀";
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
                valveName = value;
                this.label1.Text = valveName;
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

                    UpdateImage(this.isVertical, state);
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
        private ushort dqOpenAndClose;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门开关阀DQ序号")]
        public ushort DqOpenAndClose
        {
            get => dqOpenAndClose;
            set
            {
                if (dqOpenAndClose != value)
                {
                    dqOpenAndClose = value;
                }
            }
        }
        private bool isVertical = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门的水平或垂直状态")]
        public bool IsVertical
        {
            get { return isVertical; }
            set
            {
                isVertical = value;
                UpdateImage(isVertical, this.state);
            }
        }
        private void UpdateImage(bool isVertical, ValveState state)
        {
            if (isVertical)
            {
                this.Size = new Size(72, 30);
                this.label1.Dock = DockStyle.Right;
                this.panel1.Dock = DockStyle.Left;
                if (state == ValveState.open)
                {
                    this.panel1.BackgroundImage = Properties.Resources._10V;
                }
                else
                {
                    this.panel1.BackgroundImage = Properties.Resources._01V;
                }
            }
            else
            {
                this.Size = new Size(40, 46);
                this.label1.Dock = DockStyle.Top;
                this.panel1.Dock = DockStyle.Bottom;
                if (state == ValveState.open)
                {
                    this.panel1.BackgroundImage = Properties.Resources._10;
                }
                else
                {
                    this.panel1.BackgroundImage = Properties.Resources._01;
                }
            }
        }


    }
}
