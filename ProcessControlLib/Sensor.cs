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
    public partial class Sensor : UserControl
    {
        public Sensor()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门名称")]
        public string ValveName { get; set; }

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
                UpdateImage(isVertical);
            }
        }
        private void UpdateImage(bool isVertical)
        {
            this.BackgroundImage = isVertical
                ? Properties.Resources.SensorV 
                : Properties.Resources.SensorH;
        }
    }
}
