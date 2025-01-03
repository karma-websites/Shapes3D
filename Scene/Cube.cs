using SharpGL;
using System.Numerics;

namespace Scene;

internal class Cube : Shape3D, IDraw
{
    public float Side { get; set; }

    public readonly int[] indices = [
        
        0, 3, 2, 0, 2, 1, // Задняя грань (0, 1, 2, 3)
        4, 5, 6, 4, 6, 7, // Передняя грань (4, 5, 6, 7)
        0, 4, 7, 0, 7, 3, // Левая грань (0, 4, 7, 3)
        1, 2, 6, 1, 6, 5, // Правая грань (1, 5, 6, 2)
        0, 1, 5, 0, 5, 4, // Нижняя грань (0, 1, 5, 4)
        3, 7, 6, 3, 6, 2  // Верхняя грань (3, 7, 6, 2)
    ];

    public Cube(Angles rotateAngles, Position position, float side)
        : base(rotateAngles, position)
    {
        Side = side;
    }

    public Vector3[] GetVertices()
    {
        float halfSide = Side / 2;
        return [
            new Vector3(-halfSide, -halfSide, -halfSide), // 0
            new Vector3( halfSide, -halfSide, -halfSide), // 1
            new Vector3( halfSide,  halfSide, -halfSide), // 2
            new Vector3(-halfSide,  halfSide, -halfSide), // 3
            new Vector3(-halfSide, -halfSide,  halfSide), // 4
            new Vector3( halfSide, -halfSide,  halfSide), // 5
            new Vector3( halfSide,  halfSide,  halfSide), // 6
            new Vector3(-halfSide,  halfSide,  halfSide)  // 7
        ];
    }

    public List<Triangle> GetFaces(Vector3[] vertices)
    {
        List<Triangle> faces = [];

        for (int i = 0; i < indices.Length; i += 3)
        {
            Vector3 vertex1 = vertices[indices[i]];
            Vector3 vertex2 = vertices[indices[i + 1]];
            Vector3 vertex3 = vertices[indices[i + 2]];

            faces.Add(new Triangle(vertex1, vertex2, vertex3));
        }

        return faces;
    }

    public void Draw(OpenGL gl)
    {
        gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, ColorFaces);

        List<Triangle> faces = GetFaces(GetVertices());
        DrawTriangles(gl, faces);

        gl.Flush();
    }
}
