using SharpGL;
using System.Numerics;

namespace Scene;

internal class Cone : Shape3D, IDraw
{
    private const int numberSides = 30;
    public float Height { get; set; }
    public float Radius { get; set; }

    public Cone(Angles rotateAngles, Position position, float height, float radius)
        : base(rotateAngles, position)
    {
        Height = height;
        Radius = radius;
    }
    
    public Vector3[] GetVertices()
    {
        List<Vector3> vertices = [];
        vertices.Add(new Vector3(0.0f, 0.0f, Height));

        for (int i = 0; i < numberSides; i++)
        {
            float angle = (float)(i * 2.0f * Math.PI / numberSides);
            float x1 = Radius * (float)Math.Cos(angle);
            float y1 = Radius * (float)Math.Sin(angle);

            vertices.Add(new Vector3(x1, y1, 0.0f));
        }
        return [.. vertices];
    }

    public List<Triangle> GetFacesSide(Vector3[] vertices)
    {
        List<Triangle> faces = [];

        for (int i = 1; i < vertices.Length; i++)
        {
            Vector3 vertex1 = vertices[0];
            Vector3 vertex2 = vertices[i];
            Vector3 vertex3 = vertices[i % (vertices.Length - 1) + 1];

            faces.Add(new Triangle(vertex1, vertex2, vertex3));
        }

        return faces;
    }

    public List<Triangle> GetFacesBase(Vector3[] vertices)
    {
        List<Triangle> faces = [];

        for (int i = 2; i < vertices.Length - 1; i++)
        {
            Vector3 vertex1 = vertices[1];
            Vector3 vertex2 = vertices[i];
            Vector3 vertex3 = vertices[i + 1];

            faces.Add(new Triangle(vertex1, vertex3, vertex2));
        }

        return faces;
    }

    public void Draw(OpenGL gl)
    {
        gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, ColorFaces);

        List<Triangle> facesBase = GetFacesBase(GetVertices());
        DrawTriangles(gl, facesBase);

        List<Triangle> facesSide = GetFacesSide(GetVertices());
        DrawTriangles(gl, facesSide);

        gl.Flush();
    }

    public void DrawLineBase(OpenGL gl)
    {
        gl.LineWidth(5f);
        gl.Disable(OpenGL.GL_LIGHTING);
        gl.Begin(OpenGL.GL_LINES);
        Vector3[] vert = GetVertices();
        for (int i = 2; i < vert.Length; i++)
        {
            gl.Vertex(vert[1].X, vert[1].Y, vert[1].Z - 2);
            gl.Vertex(vert[i].X, vert[i].Y, vert[i].Z - 2);
        }
        gl.End();
        gl.Enable(OpenGL.GL_LIGHTING);
    }
}
