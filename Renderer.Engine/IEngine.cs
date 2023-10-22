using System.Windows.Forms;

namespace Renderer.Engine
{
    public interface IEngine
    {
        /// <summary>
        /// Render frame
        /// </summary>
        /// <returns></returns>
        public Task RenderAsync();

        /// <summary>
        /// Mouse event
        /// </summary>
        /// <param name="mouseEventArgs"></param>
        public void MouseEvent(MouseEventArgs mouseEventArgs);
    }
}