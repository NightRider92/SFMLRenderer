using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.Engine.Objects.Camera
{
    /// <summary>
    /// Camera parameters
    /// </summary>
    public struct CameraParameters
    {
        public Vector2f Center;
        public Vector2f Size;
        public float Zoom;
    }
}
