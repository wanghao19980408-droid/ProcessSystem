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
    public partial class GaseSourceElectricSwitchIcon : UserControl, IElectricControlValveIcon
    {
        public GaseSourceElectricSwitchIcon()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("操控阀门触发事件")] 
        public event EventHandler ValveClick;
        protected virtual void OnGaseSourceElectricSwitchIconClick(EventArgs e)
        {
            ValveClick?.Invoke(this, e);
        }
        private void GaseSourceSwitchIcon_Click(object sender, EventArgs e)
        {
            if (ValveClick != null)
            {
                OnGaseSourceElectricSwitchIconClick(e);
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
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门名称")]
        public string ValveName { get; set; }

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

        private ushort diClose;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门关阀DI序号")]
        public ushort DiClose
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

        private ushort diOpen;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门开阀DI序号")]
        public ushort DiOpen
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

        private ushort diFault;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门开阀DI序号")]
        public ushort DiFault
        {
            get => diFault;
            set
            {
                if (diFault != value)
                {
                    diFault = value;
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
            switch (state)
            {
                case ValveState.open:
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.HRegulatingValveON // 垂直开启状态图片
                        : Properties.Resources.RegulatingValveON; // 水平开启状态图片
                    break;

                case ValveState.close:
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.HRegulatingValveOFF  // 垂直关闭状态图片
                        : Properties.Resources.RegulatingValveOFF; // 水平关闭状态图片
                    break;

                case ValveState.warning:
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.VRegulatingValveWAR  // 垂直警告状态图片
                        : Properties.Resources.RegulatingValveWAR; // 水平警告状态图片
                    break;
                case ValveState.low:
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.VRegulatingLow   
                        : Properties.Resources.RegulatingLow; 
                    break;
                default:
                    // 默认使用关闭状态图片
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.HRegulatingValveOFF
                        : Properties.Resources.RegulatingValveOFF;
                    break;
            }
        }

    }

}
