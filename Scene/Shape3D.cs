using SharpGL;
using System.Numerics;

namespace Scene;

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

    public static void DrawCoordSystem(OpenGL gl, float lengthAxis)
    {
        gl.Disable(OpenGL.GL_LIGHTING);
        gl.LineWidth(2.0f);

        gl.Begin(OpenGL.GL_LINES);
        gl.Color(1.0f, 0.0f, 0.0f); // Цвет оси X (красный)
        gl.Vertex(0.0f, 0.0f, 0.0f);
        gl.Vertex(lengthAxis, 0.0f, 0.0f);
        gl.End();

        gl.Begin(OpenGL.GL_LINES);
        gl.Color(0.0f, 0.0f, 0.0f); // Цвет оси Y (черный)
        gl.Vertex(0.0f, 0.0f, 0.0f);
        gl.Vertex(0.0f, lengthAxis, 0.0f);
        gl.End();

        gl.Begin(OpenGL.GL_LINES);
        gl.Color(0.0f, 0.0f, 1.0f); // Цвет оси Z (синий)
        gl.Vertex(0.0f, 0.0f, 0.0f);
        gl.Vertex(0.0f, 0.0f, lengthAxis);
        gl.End();

        gl.Flush();
        gl.Enable(OpenGL.GL_LIGHTING);
    }

    public static void DrawTriangles(OpenGL gl, List<Triangle> faces)
    {
        gl.Begin(OpenGL.GL_TRIANGLES);

        foreach (var face in faces)
        {
            Vector3 normal = GetNormal(face.Vertex1, face.Vertex2, face.Vertex3);
            gl.Normal(normal.X, normal.Y, normal.Z);

            gl.Vertex(face.Vertex1.X, face.Vertex1.Y, face.Vertex1.Z);
            gl.Vertex(face.Vertex2.X, face.Vertex2.Y, face.Vertex2.Z);
            gl.Vertex(face.Vertex3.X, face.Vertex3.Y, face.Vertex3.Z);
        }

        gl.End();
    }
}

