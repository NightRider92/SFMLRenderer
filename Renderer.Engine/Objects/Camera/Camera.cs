using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.Engine.Objects.Camera
{
    /// <summary>
    /// Camera object
    /// </summary>
    public class Camera
    {
        public View View { get { return _view; } }

        private View _view;
        private CameraParameters _parameters;

        /// <summary>
        /// Setup camera object
        /// </summary>
        /// <param name="parameters"></param>
        public Camera(CameraParameters parameters)
        {
            this._parameters = parameters;
            this._view = new View();
            this._view.Center = this._parameters.Center;
            this._view.Size = this._parameters.Size;

            if (this._parameters.Zoom <= 0) this._parameters.Zoom = 0;
            if (this._parameters.Zoom > 5) this._parameters.Zoom = 5;

            this._view.Zoom(this._parameters.Zoom);
        }
    }
}
