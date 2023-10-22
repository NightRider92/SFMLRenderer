using SFML.Graphics;
using SFML.System;

namespace Renderer.Engine.Objects.Primitives
{
    /// <summary>
    /// Primitive generator
    /// </summary>
    public abstract class PrimitivesBase : Transformable
    {
        public abstract Color Color { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PrimitivesBase() { }

        /// <summary>
        /// Create object
        /// </summary>
        /// <returns></returns>
        public abstract VertexArray GetVertices(Vector2f objectPosition, int size = 50, float x = 0, float y = 0, float z = 0);

        /// <summary>
        /// Apply gravity to object
        /// </summary>
        /// <param name="objectPosition"></param>
        public abstract void ApplyGravity(Vector2f objectPosition);
    }
}