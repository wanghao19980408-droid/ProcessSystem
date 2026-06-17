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
    public partial class FiringISwitchIcon : UserControl, IAirControlValveIcon
    {
        public FiringISwitchIcon()
        {
            InitializeComponent();
            this.panel1.Paint += Panel1_Paint;
        }
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("操控阀门触发事件")]
        public event EventHandler ValveClick;

        protected virtual void OnFiringISwitchIconClick(EventArgs e)
        {
            ValveClick?.Invoke(this, e);
        }
        private void FiringISwitchIcon_Click(object sender, EventArgs e)
        {
            if (!this.enable) return;
            if (ValveClick != null)
            {
                OnFiringISwitchIconClick(e);
            }
        }

        private bool enable = false;
        [Browsable(true)]
        [Category("自定义属性")]
        public bool Enable
        {
            get { return enable; }
            set
            {
                if (enable != value)
                {
                    enable = value;
                    this.Enabled = enable;
                    this.panel1.Invalidate();
                }
            }
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.enable) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int w = this.panel1.Width;
            int h = this.panel1.Height;

            DrawModernDisabled_Lock(g, w, h);

            DrawModernDisabled_Stripes(g, w, h);
        }

        private void DrawModernDisabled_Lock(Graphics g, int w, int h)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush gradBrush =
                   new System.Drawing.Drawing2D.LinearGradientBrush(
                       new Rectangle(0, 0, w, h),
                       Color.FromArgb(140, 245, 245, 245),
                       Color.FromArgb(160, 230, 230, 230),
                       45f))
            {
                g.FillRectangle(gradBrush, 0, 0, w, h);
            }

            int iconSize = Math.Min(w, h) / 2;
            int x = (w - iconSize) / 2;
            int y = (h - iconSize) / 2;

            using (Pen pen = new Pen(Color.FromArgb(200, 100, 100, 100), 2.5f))
            {
                pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

                Rectangle lockBody = new Rectangle(
                    x + iconSize / 4,
                    y + iconSize / 2,
                    iconSize / 2,
                    iconSize / 2
                );
                g.FillRectangle(new SolidBrush(Color.FromArgb(180, 90, 90, 90)), lockBody);
                g.DrawRectangle(pen, lockBody);

                Rectangle lockArc = new Rectangle(
                    x + iconSize / 3,
                    y + iconSize / 6,
                    iconSize / 3,
                    iconSize / 2
                );
                g.DrawArc(pen, lockArc, 180, 180);

                using (SolidBrush whiteBrush = new SolidBrush(Color.FromArgb(220, 255, 255, 255)))
                {
                    int keyHoleSize = iconSize / 8;
                    g.FillEllipse(whiteBrush,
                        x + iconSize / 2 - keyHoleSize / 2,
                        y + iconSize * 5 / 8 - keyHoleSize / 2,
                        keyHoleSize, keyHoleSize);
                }
            }
        }

        private void DrawModernDisabled_Stripes(Graphics g, int w, int h)
        {
            using (SolidBrush baseBrush = new SolidBrush(Color.FromArgb(120, 240, 240, 240)))
            {
                g.FillRectangle(baseBrush, 0, 0, w, h);
            }

            using (Pen stripePen = new Pen(Color.FromArgb(100, 180, 180, 180), 3))
            {
                int spacing = 10;
                for (int i = -h; i < w + h; i += spacing)
                {
                    g.DrawLine(stripePen, i, 0, i + h, h);
                }
            }

            using (Pen borderPen = new Pen(Color.FromArgb(180, 150, 150, 150), 2))
            {
                borderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(borderPen, 1, 1, w - 3, h - 3);
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
        private string valveName { get; set; }
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
        [Description("所属PLC")]
        public string PLCRegion
        {
            get => "助燃IPLC";
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


        private bool showName = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置阀门的水平或垂直状态")]
        public bool ShowName
        {
            get { return showName; }
            set
            {
                showName = value;
                this.label1.Visible = !value;
                if (value)
                {
                    this.Size = new Size(30, 30);
                    this.panel1.Size = new Size(30, 30);
                    this.panel1.Dock = DockStyle.Fill;
                }
                else
                {
                    UpdateImage(isVertical, this.state);
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

        private void WhenVertical()
        {
            if (showName)
                return;
            this.Size = new Size(90, 35);
            this.panel1.Size = new Size(35, 35);
            this.panel1.Dock = DockStyle.Left;
            this.label1.Dock = DockStyle.Right;
        }

        private void WhenHorizontal()
        {
            if (showName)
                return;
            this.Size = new Size(55, 65);
            this.label1.Dock = DockStyle.Top;
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Size = new Size(55, 48);
        }
        private void UpdateImage(bool isVertical, ValveState state)
        {
            switch (state)
            {
                case ValveState.open:
                    if (isVertical)
                    {
                        WhenVertical();
                        this.panel1.BackgroundImage = Properties.Resources.AirValveOpenV;
                    }
                    else
                    {
                        WhenHorizontal();
                        this.panel1.BackgroundImage = Properties.Resources.AirValveOpenH;
                    }
                    break;

                case ValveState.close:
                    if (isVertical)
                    {
                        WhenVertical();

                        this.panel1.BackgroundImage = Properties.Resources.AirValveCloseV;
                    }
                    else
                    {
                        WhenHorizontal();
                        this.panel1.BackgroundImage = Properties.Resources.AirValveCloseH;
                    }
                    break;

                case ValveState.warning:
                    if (isVertical)
                    {
                        WhenVertical();

                        this.panel1.BackgroundImage = Properties.Resources.AirValveWarV;
                    }
                    else
                    {
                        WhenHorizontal();
                        this.panel1.BackgroundImage = Properties.Resources.AirValveWarH;
                    }
                    break;

                case ValveState.low:
                    if (isVertical)
                    {
                        WhenVertical();

                        this.panel1.BackgroundImage = Properties.Resources.AirValveLowV;
                    }
                    else
                    {
                        WhenHorizontal();
                        this.panel1.BackgroundImage = Properties.Resources.AirValveLowH;
                    }
                    break;
                default:
                    if (isVertical)
                    {
                        WhenVertical();

                        this.panel1.BackgroundImage = Properties.Resources.AirValveCloseV;
                    }
                    else
                    {
                        WhenHorizontal();
                        this.panel1.BackgroundImage = Properties.Resources.AirValveCloseH;
                    }
                    break;
            }
        }


    }
}
