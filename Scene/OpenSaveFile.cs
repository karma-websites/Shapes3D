namespace Scene
{
    internal static class OpenSaveFile
    {
        public static (Cube, Cone) CreateObjects(string filePath)
        {
            using StreamReader reader = new(filePath);

            reader.ReadLine();
            List<float> cubeData = ReadValues(reader, 7);
            Angles cubeAngles = new(cubeData[0], cubeData[1], cubeData[2]);
            Position cubePos = new(cubeData[3], cubeData[4], cubeData[5]);
            float side = cubeData[6];
            float[] cubeColor = ReadColor(reader);

            Cube cube = new(cubeAngles, cubePos, side)
            {
                ColorFaces = [cubeColor[0], cubeColor[1], cubeColor[2], 1.0f]
            };

            reader.ReadLine();
            List<float> coneData = ReadValues(reader, 8);
            Angles coneAngles = new(coneData[0], coneData[1], coneData[2]);
            Position conePos = new(coneData[3], coneData[4], coneData[5]);
            float height = coneData[6];
            float radius = coneData[7];
            float[] coneColor = ReadColor(reader);

            Cone cone = new(coneAngles, conePos, height, radius)
            {
                ColorFaces = [coneColor[0], coneColor[1], coneColor[2], 1.0f]
            };

            return (cube, cone);
        }

        private static List<float> ReadValues(StreamReader reader, int count)
        {
            List<float> values = [];
            for (int i = 0; i < count; i++)
            {
                string line = reader.ReadLine() ?? "0";
                values.Add(float.Parse(line));
            }
            return values;
        }

        private static float[] ReadColor(StreamReader reader)
        {
            string line = reader.ReadLine() ?? "0";
            string[] parts = line.Split(' ');
            return [
                float.Parse(parts[0]),
                float.Parse(parts[1]),
                float.Parse(parts[2])  
            ];
        }

        public static void SaveObjects(string filePath, Cube cube, Cone cone)
        {
            using StreamWriter writer = new(filePath);

            writer.WriteLine("===== Cube =====");
            writer.WriteLine($"{cube.AngleX}");
            writer.WriteLine($"{cube.AngleY}");
            writer.WriteLine($"{cube.AngleZ}");
            writer.WriteLine($"{cube.PosX}");
            writer.WriteLine($"{cube.PosY}");
            writer.WriteLine($"{cube.PosZ}");
            writer.WriteLine($"{cube.Side}");
            writer.WriteLine($"{cube.ColorFaces[0]} {cube.ColorFaces[1]} {cube.ColorFaces[2]}");

            writer.WriteLine("===== Cone =====");
            writer.WriteLine($"{cone.AngleX}");
            writer.WriteLine($"{cone.AngleY}");
            writer.WriteLine($"{cone.AngleZ}");
            writer.WriteLine($"{cone.PosX}");
            writer.WriteLine($"{cone.PosY}");
            writer.WriteLine($"{cone.PosZ}");
            writer.WriteLine($"{cone.Height}");
            writer.WriteLine($"{cone.Radius}");
            writer.WriteLine($"{cone.ColorFaces[0]} {cone.ColorFaces[1]} {cone.ColorFaces[2]}");
        }
    }
}
