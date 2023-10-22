using SFML.Window;
using SFML.Graphics;
using SFML.System;
using Timer = System.Windows.Forms.Timer;
using Cursor = System.Windows.Forms.Cursor;
using Renderer.Engine.Objects.Camera;
using Renderer.Engine;

namespace Raytracer
{
    public partial class MainForm : Form
    {
        private SFMLControl.SFMLControl sfmlControl;
        private IEngine engine;
        private Camera camera;
        private Timer renderTimer;
        private bool isMouseDown = false;

        public MainForm()
        {
            InitializeComponent();
            this.sfmlControl = new SFMLControl.SFMLControl();
            this.sfmlControl.MouseDown += SfmlControl_MouseDown;
            this.sfmlControl.MouseUp += SfmlControl_MouseUp;
            this.sfmlControl.MouseMove += SfmlControl_MouseMove;
            this.sfmlControl.Dock = DockStyle.Fill;
            this.Controls.Add(this.sfmlControl);

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            this.renderTimer = new Timer() { Enabled = true, Interval = 8 }; // 120 Hz
            this.renderTimer.Tick += RenderTimer_Tick;
            this.renderTimer.Start();

            camera = new Camera(new CameraParameters() { Center = new Vector2f(0, 0), Size = new Vector2f(this.Width, this.Height), Zoom = 1f });
            engine = new Engine(this.sfmlControl.Window, camera);
        }

        /// <summary>
        /// Mouse move handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SfmlControl_MouseMove(object? sender, MouseEventArgs e)
        {
            if (this.isMouseDown) engine.MouseEvent(e);
        }

        /// <summary>
        /// Mouse down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SfmlControl_MouseDown(object? sender, MouseEventArgs e)
        {
            this.isMouseDown = true;
        }

        /// <summary>
        /// Mouse up event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SfmlControl_MouseUp(object? sender, MouseEventArgs e)
        {
            this.isMouseDown = false;
        }

        /// <summary>
        /// Render frame(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RenderTimer_Tick(object? sender, EventArgs e)
        {
            await engine.RenderAsync();
        }
    }
}