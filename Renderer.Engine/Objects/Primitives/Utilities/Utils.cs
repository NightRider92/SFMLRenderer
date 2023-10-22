using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.Engine.Objects.Primitives.Utilities
{
    public static class Utils
    {
        /// <summary>
        /// Create cube rotational matrix depending on selected axis
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static Matrix4x4 CreateCubeRotationalMatrix(float angle, Axis axis)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float sineWave = (float)(sinA * Math.Sin(2 * Math.PI * 5 * angle + 1));

            switch (axis)
            {
                case Axis.XAxis:
                    return new Matrix4x4(1, 0, 0, 0, 0, cosA, -sinA, 0, 0, sinA, cosA, 0, 0, 0, 0, 1);
                case Axis.YAxis:
                    return new Matrix4x4(cosA, 0, sinA, 0, 0, 1, 0, 0, -sinA, 0, cosA, 0, 0, 0, 0, 1);
                case Axis.ZAxis:
                    return new Matrix4x4(cosA, -sinA, 0, 0, sinA, cosA, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                default:
                    return new Matrix4x4();
            }
        }

        /// <summary>
        /// Matrix multiplication
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector3f MatrixMultiply(Vector3f vector, Matrix4x4 matrix)
        {
            float x = matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14;
            float y = matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24;
            float z = matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34;
            return new Vector3f(x, y, z);
        }
    }
}
