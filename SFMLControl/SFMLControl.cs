using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;

namespace SFMLControl
{
    public partial class SFMLControl : UserControl
    {
        public RenderWindow Window { get; private set; }

        public SFMLControl()
        {
            SetStyle(ControlStyles.Opaque, true);
            this.Window = new RenderWindow(Handle);
            this.Window.SetActive(true);
            this.Window.Closed += (sender, e) => this.Window.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Window.DispatchEvents();
            this.Window.Clear();
            this.Window.Display();
        }
    }
}
