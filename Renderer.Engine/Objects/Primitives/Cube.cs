using Renderer.Engine.Objects.Primitives.Utilities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Renderer.Engine.Objects.Primitives
{
    /// <summary>
    /// Cube object
    /// </summary>
    public class Cube : PrimitivesBase
    {
        public override SFML.Graphics.Color Color { get; set; }

        public Cube() { }

        /// <summary>
        /// Create object
        /// </summary>
        /// <returns></returns>
        public override VertexArray GetVertices(Vector2f objectPosition, int size, float x, float y, float z)
        {
            this.Position = objectPosition;

            float radX = (float)(x * Math.PI / 180);
            float radY = (float)(y * Math.PI / 180);
            float radZ = (float)(z * Math.PI / 180);

            Vector3f[] positions = new Vector3f[]
            {
                new Vector3f(-size, -size, -size),
                new Vector3f(size, -size, -size),
                new Vector3f(size, size, -size),
                new Vector3f(-size, size, -size),
                new Vector3f(-size, -size, size),
                new Vector3f(size, -size, size),
                new Vector3f(size, size, size),
                new Vector3f(-size, size, size),
            };

            int[][] faceIndices = new int[][]
       {
                new int[] { 0, 1, 2, 3 }, // Front face
                new int[] { 4, 5, 6, 7 }, // Back face
                new int[] { 0, 1, 5, 4 }, // Left face
                new int[] { 2, 3, 7, 6 }, // Right face
                new int[] { 0, 3, 7, 4 }, // Top face
                new int[] { 1, 2, 6, 5 }  // Bottom face
       };

            VertexArray vertices = new VertexArray(PrimitiveType.Quads);
            Matrix4x4 rotationX = Utils.CreateCubeRotationalMatrix(radX, Axis.XAxis);
            Matrix4x4 rotationY = Utils.CreateCubeRotationalMatrix(radY, Axis.YAxis);
            Matrix4x4 rotationZ = Utils.CreateCubeRotationalMatrix(radZ, Axis.ZAxis);

            foreach (var faceIndex in faceIndices)
            {
                foreach (var index in faceIndex)
                {
                    Vector3f position = positions[index];
                    Vector3f rotated = Utils.MatrixMultiply(Utils.MatrixMultiply(Utils.MatrixMultiply(position, rotationX), rotationY), rotationZ);
                    vertices.Append(new Vertex(new Vector2f(rotated.X, rotated.Y), this.Color));
                }
            }
            return vertices;
        }

        /// <summary>
        /// Apply gravity to object
        /// </summary>
        /// <param name="objectPosition"></param>
        public override void ApplyGravity(Vector2f objectPosition)
        {
            this.Position = objectPosition;
        }
    }
}
