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
    public partial class Heater : UserControl
    {
        public Heater()
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

                    UpdateImage(state);
                }
            }
        }
        private void UpdateImage(ValveState state)
        {
            switch (state)
            {
                case ValveState.open:
                    this.BackgroundImage = Properties.Resources.HeateOpen;
                    break;

                case ValveState.close:
                    this.BackgroundImage = Properties.Resources.HeateClose;
                    break;

                case ValveState.warning:
                    this.BackgroundImage = Properties.Resources.HeateWar;
                    break;
                default:
                    this.BackgroundImage = Properties.Resources.HeateClose;
                    break;
            }
        }

    }
}
