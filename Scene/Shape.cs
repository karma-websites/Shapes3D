using SharpGL;
using System.Numerics;

namespace Scene
{
    internal abstract class Shape3D(Angles rotateAngles, Position position)
    {
        public float AngleX { get; set; } = rotateAngles.X;
        public float AngleY { get; set; } = rotateAngles.Y;
        public float AngleZ { get; set; } = rotateAngles.Z;

        public float PosX { get; set; } = position.X;
        public float PosY { get; set; } = position.Y;
        public float PosZ { get; set; } = position.Z;

        public float[] ColorFaces { get; set; } = [];

        public void NormAngles()
        {
            if (AngleX > 360 || AngleX < -360) AngleX %= 360;
            if (AngleY > 360 || AngleY < -360) AngleY %= 360;
            if (AngleZ > 360 || AngleZ < -360) AngleZ %= 360;
        }

        public void Move(OpenGL gl)
        {
            gl.Translate(PosX, PosY, PosZ);
            gl.Rotate(AngleX, AngleY, AngleZ);
        }

        public static Vector3 GetNormal(Vector3 A, Vector3 B, Vector3 C)
        {
            Vector3 normal = Vector3.Cross(B - A, C - A);
            normal = Vector3.Normalize(normal);
            return normal;
        }

        public void DrawCoordSystem(OpenGL gl, float lengthAxis)
        {
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.LineWidth(2.0f);

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1.0f, 0.0f, 0.0f); // Цвет для оси X (красный)
            gl.Vertex(0.0f, 0.0f, 0.0f);
            gl.Vertex(lengthAxis, 0.0f, 0.0f);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0.0f, 0.0f, 0.0f); // Цвет для оси Y (черный)
            gl.Vertex(0.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, lengthAxis, 0.0f);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0.0f, 0.0f, 1.0f); // Цвет для оси Z (синий)
            gl.Vertex(0.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, lengthAxis);
            gl.End();

            gl.Flush();
            gl.Enable(OpenGL.GL_LIGHTING);
        }
    }
}

