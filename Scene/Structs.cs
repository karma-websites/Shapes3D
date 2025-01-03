using MIConvexHull;
using System.Numerics;

namespace Scene;

internal struct Angles(float X, float Y, float Z)
{
    public float X { get; set; } = X;
    public float Y { get; set; } = Y;
    public float Z { get; set; } = Z;
}

internal struct Position(float X, float Y, float Z)
{
    public float X { get; set; } = X;
    public float Y { get; set; } = Y;
    public float Z { get; set; } = Z;
}

internal readonly struct Triangle(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
{
    public Vector3 Vertex1 { get; } = vertex1;
    public Vector3 Vertex2 { get; } = vertex2;
    public Vector3 Vertex3 { get; } = vertex3;
}

public class Vertex(Vector3 vector) : IVertex
{
    public double[] Position { get; } = [vector.X, vector.Y, vector.Z];
}

public class TriangulatedFace : ConvexFace<Vertex, TriangulatedFace> {}
