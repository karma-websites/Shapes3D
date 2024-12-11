using SharpGL;
using System.Numerics;

namespace Scene
{
    internal class Cone : Shape3D
    {
        private const int numberSides = 50;
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

                faces.Add(new Triangle(vertex1, vertex2, vertex3));
            }

            return faces;
        }

        public void Draw(OpenGL gl)
        {
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, ColorFaces);

            DrawBase(gl);
            DrawFaces(gl);

            gl.Flush();
        }

        private void DrawBase(OpenGL gl)
        {
            List<Triangle> faces = GetFacesBase(GetVertices());
            gl.Begin(OpenGL.GL_TRIANGLES);
            gl.Normal(0.0f, 0.0f, -1.0f);

            foreach (var face in faces)
            {
                gl.Vertex(face.Vertex1.X, face.Vertex1.Y, face.Vertex1.Z);
                gl.Vertex(face.Vertex2.X, face.Vertex2.Y, face.Vertex2.Z);
                gl.Vertex(face.Vertex3.X, face.Vertex3.Y, face.Vertex3.Z);
            }

            gl.End();

            /*gl.LineWidth(5f);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Begin(OpenGL.GL_LINES);
            Vector3[] vert = GetVertices();
            for (int i = 2; i < vert.Length; i++)
            {
                gl.Vertex(vert[1].X, vert[1].Y, vert[1].Z-2);
                gl.Vertex(vert[i].X, vert[i].Y, vert[i].Z-2);
            }
            gl.End();
            gl.Enable(OpenGL.GL_LIGHTING);*/
        }

        private void DrawFaces(OpenGL gl)
        {
            List<Triangle> faces = GetFacesSide(GetVertices());
            gl.Begin(OpenGL.GL_TRIANGLES);

            foreach (var face in faces)
            {
                Vector3 vector = GetNormal(face.Vertex1, face.Vertex2, face.Vertex3);
                gl.Normal(vector.X, vector.Y, vector.Z);

                gl.Vertex(face.Vertex1.X, face.Vertex1.Y, face.Vertex1.Z);
                gl.Vertex(face.Vertex2.X, face.Vertex2.Y, face.Vertex2.Z);
                gl.Vertex(face.Vertex3.X, face.Vertex3.Y, face.Vertex3.Z);
            }

            gl.End();
        }
    }
}
