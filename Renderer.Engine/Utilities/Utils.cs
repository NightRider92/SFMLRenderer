using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.Engine.Utilities
{
    public class Utils
    {
        /// <summary>
        /// Generate random color
        /// </summary>
        /// <returns></returns>
        public static Color RandomColor()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 7);

            switch (r)
            {
                case 0: return Color.Red;
                case 1: return Color.Green;
                case 2: return Color.Blue;
                case 3: return Color.Magenta;
                case 4: return Color.Yellow;
                case 5: return Color.Cyan;
                case 6: return Color.White;
                default: return RandomColor();
            }
        }

        /// <summary>
        /// Return random size number
        /// </summary>
        /// <returns></returns>
        public static int RandomSize()
        {
            Random rnd = new Random();
            return rnd.Next(30, 120);
        }
    }
}
