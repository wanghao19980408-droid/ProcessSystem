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
    public partial class SolenoidValve : UserControl
    {
        public SolenoidValve()
        {
            InitializeComponent();
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
                        ? Properties.Resources.AirValveOpenV // 垂直开启状态图片
                        : Properties.Resources.AirValveOpenH; // 水平开启状态图片
                    break;

                case ValveState.close:
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.AirValveCloseV  // 垂直关闭状态图片
                        : Properties.Resources.AirValveCloseH; // 水平关闭状态图片
                    break;

                case ValveState.warning:
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.AirValveWarV  // 垂直警告状态图片
                        : Properties.Resources.AirValveWarH; // 水平警告状态图片
                    break;

                case ValveState.low:
                    this.BackgroundImage = isVertical
                    ? Properties.Resources.AirValveLowV  // 垂直警告状态图片
                    : Properties.Resources.AirValveLowH; // 水平警告状态图片
                    break;
                default:
                    // 默认使用关闭状态图片
                    this.BackgroundImage = isVertical
                        ? Properties.Resources.AirValveCloseV
                        : Properties.Resources.AirValveCloseH;
                    break;
            }
        }
    }
}
