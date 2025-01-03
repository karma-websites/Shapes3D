using SharpGL;
using System.Numerics;

namespace Scene;

internal class Scene(Angles rotateAngles, Position position) 
    : Shape3D(rotateAngles, position)
{
    public static void RenderMesh(OpenGL gl, List<TriangulatedFace> triangles)
    {
        gl.Begin(OpenGL.GL_TRIANGLES);
        gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, [0.5f, 0.0f, 0.5f]); // Цвет фиолетовый
        foreach (var triangle in triangles)
        {
            var vertex = triangle.Vertices;

            Vector3 point1 = new((float)vertex[0].Position[0], (float)vertex[0].Position[1], (float)vertex[0].Position[2]);
            Vector3 point2 = new((float)vertex[1].Position[0], (float)vertex[1].Position[1], (float)vertex[1].Position[2]);
            Vector3 point3 = new((float)vertex[2].Position[0], (float)vertex[2].Position[1], (float)vertex[2].Position[2]);

            Vector3 normal = GetNormal(point1, point2, point3);
            gl.Normal(normal.X, normal.Y, normal.Z);

            gl.Vertex(point1.X, point1.Y, point1.Z);
            gl.Vertex(point2.X, point2.Y, point2.Z);
            gl.Vertex(point3.X, point3.Y, point3.Z);
        }
        gl.End();
    }

    public static void DrawVertex(OpenGL gl, List<Vector3> vertexes)
    {
        IntPtr quadric = gl.NewQuadric();
        gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, [0.5f, 0.5f, 0.5f]); // Цвет серый
        foreach (var vertex in vertexes)
        {
            gl.PushMatrix();
            gl.Translate(vertex.X, vertex.Y, vertex.Z);
            gl.Sphere(quadric, radius: 6, slices: 5, stacks: 5);
            gl.PopMatrix();
        }
        gl.End();
        gl.Flush();
    }
}
