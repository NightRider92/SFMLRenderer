using Renderer.Engine.Objects.Camera;
using Renderer.Engine.Objects.Primitives;
using Renderer.Engine.Utilities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderer.Engine
{
    /// <summary>
    /// Rendering engine
    /// </summary>
    public class Engine : IEngine
    {
        public event MouseEventHandler? MouseClick;
        private LinkedList<PrimitivesBase> _primitives;

        private RenderWindow _window;
        private Camera _camera;

        private float angleX = 0;
        private float angleY = 0;
        private float angleZ = 0;

        private readonly float gravity = 9.8f;
        private readonly int max_y = 2160;
        private readonly int max_angle = 360;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window"></param>
        /// <param name="camera"></param>
        public Engine(RenderWindow window, Camera camera)
        {
            this._window = window;
            this._camera = camera;

            if (this._window == null) throw new ArgumentNullException("Window = NULL");
            if (this._camera == null) throw new ArgumentNullException("Camera = NULL");

            this._primitives = new LinkedList<PrimitivesBase>();
            this._window.SetView(this._camera.View);

            // Event handlers
            this.MouseClick += Engine_MouseClick;
        }

        /// <summary>
        /// On mouse click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Engine_MouseClick(object sender, MouseEventArgs e)
        {
            if (e == null) return;

            Vector2i screenPos = new Vector2i(e.X, e.Y);
            Vector2f worldPos = this._window.MapPixelToCoords(screenPos);

            PrimitivesBase cube = new Cube() { Color = Utils.RandomColor() };
            cube.Position = new Vector2f(worldPos.X, worldPos.Y);
            this._primitives.AddLast(cube);
        }

        /// <summary>
        /// Mouse event
        /// </summary>
        /// <param name="mouseEventArgs"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void MouseEvent(MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs == null) return;
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                if (this.MouseClick != null)
                    MouseClick?.Invoke(this, mouseEventArgs);
            }
        }

        /// <summary>
        /// Increase angle
        /// </summary>
        private void increaseAngle(float value)
        {
            if (value < 1) value = 1;
            if (value > 180) value = 180;

            this.angleX += value;
            if (this.angleX >= this.max_angle) angleX = 0;

            this.angleY += value;
            if (this.angleY >= this.max_angle) angleY = 0;

            this.angleZ += value;
            if (this.angleZ >= this.max_angle) angleZ = 0;
        }

        /// <summary>
        /// Render frame
        /// </summary>
        /// <returns></returns>
        public Task RenderAsync()
        {
            try
            {
                this._window.DispatchEvents();
                this._window.Clear();

                // Increase angle by value for each call
                this.increaseAngle(0.5f);

                for (int i = 0; i < this._primitives.Count; ++i)
                {
                    try
                    {
                        Cube c = (Cube)this._primitives.ElementAt(i);
                        if (c == null) continue;

                        // Apply gravity for each object 
                        c.ApplyGravity(new Vector2f(c.Position.X, c.Position.Y + this.gravity));

                        RenderStates states = new RenderStates(c.Transform);
                        this._window.Draw(c.GetVertices(c.Position, 1, angleX, angleY, angleZ), states);

                        // Remove elements out of bounds
                        if (c.Position.Y > this.max_y) this._primitives.RemoveFirst();
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }
                }
                this._window.Display();
            }
            catch (Exception e) { Trace.WriteLine(e); }
            return Task.CompletedTask;
        }
    }
}
