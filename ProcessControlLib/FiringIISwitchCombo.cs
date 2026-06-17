using ProcessSystemLib;
using Sunny.UI;
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
    public partial class FiringIISwitchCombo : UserControl, IAirControlValveBase
    {
        public FiringIISwitchCombo()
        {
            InitializeComponent();
            UpdateVisualFeedback();
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
                    UpdateVisualFeedback();
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

        private bool enable = false; 
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置使用权限")]
        public bool Enable
        {
            get { return enable; }
            set
            {
                if (enable != value)
                {
                    enable = value;
                    UpdateVisualFeedback();
                }
            }
        }

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("所属PLC")]
        public string PLCRegion
        {
            get => "助燃IIPLC";
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

        private int diClose;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门关阀DI序号")]
        public int DiClose
        {
            get => diClose;
            set
            {
                if (diClose != value)
                {
                    diClose = value;
                }
            }
        }

        private int diOpen;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门开阀DI序号")]
        public int DiOpen
        {
            get => diOpen;
            set
            {
                if (diOpen != value)
                {
                    diOpen = value;
                }
            }
        }
        private void UpdateVisualFeedback()
        {
            if (this.enable)
            {
                this.Cursor = Cursors.Default;
                this.button1.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.No;
                this.button1.Cursor = Cursors.No;
            }

            this.button1.Style = UIStyle.Custom;

            if (this.enable)
            {
                this.button1.ForeHoverColor = Color.White;
                this.button1.ForePressColor = Color.White;

                if (state == ValveState.open)
                {
                    this.button1.Text = "关阀";

                    this.button1.FillColor = Color.Red;
                    this.button1.FillHoverColor = Color.FromArgb(255, 80, 80);
                    this.button1.FillPressColor = Color.DarkRed;
                    this.button1.RectColor = Color.Red;
                    this.button1.RectHoverColor = Color.Red;
                    this.button1.RectPressColor = Color.DarkRed;

                    this.button1.ForeColor = Color.White;
                }
                else
                {
                    this.button1.Text = "开阀";

                    this.button1.FillColor = Color.FromArgb(80, 160, 255);
                    this.button1.FillHoverColor = Color.FromArgb(100, 180, 255);
                    this.button1.FillPressColor = Color.FromArgb(0, 120, 215);
                    this.button1.RectColor = Color.FromArgb(80, 160, 255);
                    this.button1.RectHoverColor = Color.FromArgb(100, 180, 255);
                    this.button1.RectPressColor = Color.FromArgb(0, 120, 215);

                    this.button1.ForeColor = Color.White;
                }
            }
            else
            {
                Color disabledBg = Color.FromArgb(247, 248, 250);
                this.button1.FillColor = disabledBg;
                this.button1.FillHoverColor = disabledBg;
                this.button1.FillPressColor = disabledBg;

                Color disabledRect = Color.FromArgb(220, 220, 220);
                this.button1.RectColor = disabledRect;
                this.button1.RectHoverColor = disabledRect;
                this.button1.RectPressColor = disabledRect;

                this.button1.ForeHoverColor = Color.Red;
                this.button1.ForePressColor = Color.Red;

                if (state == ValveState.open)
                {
                    this.button1.Text = "🔒";
                    this.button1.ForeColor = Color.IndianRed; 
                }
                else
                {
                    this.button1.Text = "🔒";
                    this.button1.ForeColor = Color.SteelBlue;
                }
            }
        }
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("操控阀门触发事件")]
        public event EventHandler ValveClick;
        protected virtual void OnFiringIISwitchClick(EventArgs e)
        {
            ValveClick?.Invoke(this, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.enable)
            {
                return;
            }
            if (ValveClick != null)
            {
                OnFiringIISwitchClick(e);
            }
        }

    }
}
