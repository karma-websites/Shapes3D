using SharpGL;
using System.Numerics;

namespace Scene;

internal static class Algorithm
{
    private const float epsilon = 0.001f;

    public static float Epsilon => epsilon;

    // Метод вычисляет координаты нормали плоскости
    public static Vector3 GetNormal(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 normal = Vector3.Cross(p2 - p1, p3 - p1);
        normal = Vector3.Normalize(normal);
        return normal;
    }

    // Метод преобразует вершины структуры Vector3 в вершины класса Vertex
    public static List<Vertex> Vertex3ToVertex(List<Vector3> pointsIntersect)
    {
        List<Vertex> vertices = [];
        foreach (var point in pointsIntersect)
        {
            vertices.Add(new Vertex(point));
        }
        return vertices;
    }

    // Метод преобразует массив вершин с помощью модельно-видовой матрицы OpenGL
    public static Vector3[] ApplyTransformVertixes(OpenGL gl, Vector3[] vertices)
    {
        float[] modelviewMatrix = new float[16];
        gl.GetFloat(OpenGL.GL_MODELVIEW_MATRIX, modelviewMatrix);

        Matrix4x4 transformMatrix = new(
            modelviewMatrix[0], modelviewMatrix[1], modelviewMatrix[2], modelviewMatrix[3],
            modelviewMatrix[4], modelviewMatrix[5], modelviewMatrix[6], modelviewMatrix[7],
            modelviewMatrix[8], modelviewMatrix[9], modelviewMatrix[10], modelviewMatrix[11],
            modelviewMatrix[12], modelviewMatrix[13], modelviewMatrix[14], modelviewMatrix[15]
        );

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector4 localVertex = new(vertices[i], 1.0f);
            Vector4 transformVertex = Vector4.Transform(localVertex, transformMatrix);
            vertices[i] = new Vector3(transformVertex.X, transformVertex.Y, transformVertex.Z);
        }

        return vertices;
    }

    // Метод возвращает все точки пересечения двух списков треугольников
    // Точка пересечения ищется между стороной одного треугольника (отрезком) и плоскостью другого треугольника
    public static List<Vector3> FindPointsIntersect(List<Triangle> listTriangles1, List<Triangle> listTriangles2)
    {
        List<Vector3> intersectPoints = [];

        foreach (var triangle1 in listTriangles1)
        {
            foreach (var triangle2 in listTriangles2)
            {
                List<Vector3> points = FindTriangleIntersection(triangle1, triangle2);
                intersectPoints.AddRange(points);
            }
        }

        return RemoveDuplicates(intersectPoints, distance: epsilon);
    }

    // Метод возвращает список точек без дубликатов
    public static List<Vector3> RemoveDuplicates(List<Vector3> points, float distance)
    {
        List<Vector3> uniquePoints = [];

        foreach (var point in points)
        {
            bool isDuplicate = false;

            foreach (var uniquePoint in uniquePoints)
            {
                if (Vector3.Distance(point, uniquePoint) < distance)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                uniquePoints.Add(point);
            }
        }

        return uniquePoints;
    }

    // Метод возвращает точки пересечения двух треугольников
    private static List<Vector3> FindTriangleIntersection(Triangle t1, Triangle t2)
    {
        List<Vector3> result = [];

        // Добавление пересечений ребер первого треугольника с плоскостью второго
        result.AddRange(FindEdgePlaneIntersect(t1.Vertex1, t1.Vertex2, t2));
        result.AddRange(FindEdgePlaneIntersect(t1.Vertex2, t1.Vertex3, t2));
        result.AddRange(FindEdgePlaneIntersect(t1.Vertex3, t1.Vertex1, t2));

        // Добавление пересечений ребер второго треугольника с плоскостью первого
        result.AddRange(FindEdgePlaneIntersect(t2.Vertex1, t2.Vertex2, t1));
        result.AddRange(FindEdgePlaneIntersect(t2.Vertex2, t2.Vertex3, t1));
        result.AddRange(FindEdgePlaneIntersect(t2.Vertex3, t2.Vertex1, t1));

        return result;
    }


    // Метод возвращает точку пересечения отрезка с плоскостью треугольника
    private static List<Vector3> FindEdgePlaneIntersect(Vector3 p1, Vector3 p2, Triangle tr)
    {
        List<Vector3> result = [];

        // Уравнение плоскости: Ax + By + Cz + D = 0
        Vector3 normal = GetNormal(tr.Vertex1, tr.Vertex2, tr.Vertex3);
        float d = -Vector3.Dot(normal, tr.Vertex1);

        // Расстояния от точек p1 и p2 до плоскости
        float dist1 = Vector3.Dot(normal, p1) + d;
        float dist2 = Vector3.Dot(normal, p2) + d;

        if (dist1 * dist2 < -epsilon) // Отрезок пересекает плоскость
        {
            float t = dist1 / (dist1 - dist2); // Всегда > 0
            Vector3 intersectPoint = p1 + t * (p2 - p1); // Линейная интерполяция

            if (IsPointInTriangle(intersectPoint, tr))
            {
                result.Add(intersectPoint);
            }
        }

        // Отрезок лежит в плоскости или касается плоскости в точке p1 или точке p2
        if (Math.Abs(dist1) < epsilon && IsPointInTriangle(p1, tr))
        {
            result.Add(p1); // Добавление точки p1, если она на плоскости и в треугольнике
        }

        if (Math.Abs(dist2) < epsilon && IsPointInTriangle(p2, tr))
        {
            result.Add(p2); // Добавление точки p2, если она на плоскости и в треугольнике
        }

        return result;
    }

    // Метод проверяет принадлежность точки треугольнику
    private static bool IsPointInTriangle(Vector3 point, Triangle triangle)
    {
        // Метод барицентрических координат
        Vector3 v0 = triangle.Vertex3 - triangle.Vertex1;
        Vector3 v1 = triangle.Vertex2 - triangle.Vertex1;
        Vector3 v2 = point - triangle.Vertex1;

        float dot00 = Vector3.Dot(v0, v0);
        float dot01 = Vector3.Dot(v0, v1);
        float dot02 = Vector3.Dot(v0, v2);
        float dot11 = Vector3.Dot(v1, v1);
        float dot12 = Vector3.Dot(v1, v2);

        float inverseDenom = 1 / (dot00 * dot11 - dot01 * dot01);
        float u = (dot11 * dot02 - dot01 * dot12) * inverseDenom;
        float v = (dot00 * dot12 - dot01 * dot02) * inverseDenom;

        return (u >= -epsilon) && (v >= -epsilon) && (u + v <= 1 + epsilon);
    }

    // Метод возвращает точки конуса внутри куба и точки куба внутри конуса
    public static List<Vector3> FindPointsInShapes(Vector3[] conePoints, Vector3[] cubePoints)
    {
        List<Vector3> pointsInShapes = [];

        foreach (var conePoint in conePoints)
        {
            if (IsPointInCube(conePoint, cubePoints))
            {
                pointsInShapes.Add(conePoint);
            }
        }

        foreach (var cubePoint in cubePoints)
        {
            if (IsPointInCone(cubePoint, conePoints))
            {
                pointsInShapes.Add(cubePoint);
            }
        }

        return pointsInShapes;
    }


    // Метод проверяет, находится ли точка внутри куба
    private static bool IsPointInCube(Vector3 pointCheck, Vector3[] cubeVertices)
    {
        if (cubeVertices.Length != 8) return false;

        // Координаты центра куба
        Vector3 centerCube = Vector3.Zero;
        foreach (var vertex in cubeVertices)
        {
            centerCube += vertex;
        }
        centerCube /= cubeVertices.Length;

        // Уравнения плоскостей каждой грани куба
        List<Plane> planes = GetCubePlanes(cubeVertices);

        // Проверка, лежат ли точка и центр в одной полуплоскости для каждой грани
        return IsPointInShape(planes, centerCube, pointCheck);
    }

    // Метод возвращает уравнения плоскостей куба
    private static List<Plane> GetCubePlanes(Vector3[] cubeVertices)
    {
        List<Plane> planes = [];

        int[][] cubeFaces =
        [
             [0, 1, 2, 3], // Задняя грань (0, 1, 2, 3)
             [4, 5, 6, 7], // Передняя грань (4, 5, 6, 7)
             [0, 4, 7, 3], // Левая грань (0, 4, 7, 3)
             [1, 5, 6, 2], // Правая грань (1, 5, 6, 2)
             [0, 1, 5, 4], // Нижняя грань (0, 1, 5, 4)
             [3, 7, 6, 2], // Верхняя грань (3, 7, 6, 2)
        ];

        foreach (var face in cubeFaces)
        {
            Vector3 p1 = cubeVertices[face[0]];
            Vector3 p2 = cubeVertices[face[1]];
            Vector3 p3 = cubeVertices[face[2]];

            Vector3 normal = GetNormal(p1, p2, p3);
            float d = -Vector3.Dot(normal, p1);

            planes.Add(new Plane(normal, d));
        }

        return planes;
    }

    // Метод проверяет, лежит ли точка внутри фигуры
    private static bool IsPointInShape(List<Plane> planes, Vector3 pointInShape, Vector3 pointCheck)
    {
        foreach (var plane in planes)
        {
            float distCenter = Vector3.Dot(plane.Normal, pointInShape) + plane.D;
            float distPoint = Vector3.Dot(plane.Normal, pointCheck) + plane.D;

            if (distCenter * distPoint < -epsilon)
            {
                return false; // Точка не в фигуре
            }
        }

        return true; // Точка в фигуре
    }

    // Метод проверяет, находится ли точка внутри конуса
    private static bool IsPointInCone(Vector3 pointCheck, Vector3[] coneVertices)
    {
        if (coneVertices.Length < 4) return false;

        // Координаты центра конуса
        Vector3 baseCenter = Vector3.Zero;
        for (int i = 1; i < coneVertices.Length; i++)
        {
            baseCenter += coneVertices[i];
        }
        baseCenter /= coneVertices.Length - 1;
        Vector3 axis = baseCenter - coneVertices[0];
        float scale = 0.5f;
        Vector3 centerCone = coneVertices[0] + scale * axis;

        // Уравнения плоскостей каждой грани конуса
        List<Plane> planes = GetConePlanes(coneVertices);

        // Проверка, лежат ли точка и центр в одной полуплоскости для каждой грани
        return IsPointInShape(planes, centerCone, pointCheck);
    }

    // Метод возвращает уравнения плоскостей конуса
    private static List<Plane> GetConePlanes(Vector3[] coneVertices)
    {
        List<Plane> planes = [];
        int numVert = coneVertices.Length;

        for (int i = 1; i < numVert; i++)
        {
            Vector3 p1 = coneVertices[0];
            Vector3 p2 = coneVertices[i];
            Vector3 p3 = coneVertices[i % (numVert - 1) + 1];

            Vector3 normal = GetNormal(p1, p2, p3);
            float d = -Vector3.Dot(normal, p1);

            planes.Add(new Plane(normal, d));
        }

        Vector3 pointBase1 = coneVertices[1];
        Vector3 pointBase2 = coneVertices[(numVert / 3 + 1) % numVert];
        Vector3 pointBase3 = coneVertices[(numVert / 3 * 2 + 1) % numVert];

        Vector3 normalBase = GetNormal(pointBase1, pointBase2, pointBase3);
        float dBase = -Vector3.Dot(normalBase, pointBase1);

        planes.Add(new Plane(normalBase, dBase));

        return planes;
    }
}
