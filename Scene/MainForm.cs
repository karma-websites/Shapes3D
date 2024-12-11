using SharpGL;
using System.Numerics;
using MIConvexHull;

namespace Scene
{
    public partial class MainForm : Form
    {
        private Cube cube;
        private Cone cone;
        private readonly Scene scene;

        private bool showCube = false;
        private bool showCone = false;
        private bool showCubeSystemCoord = false;
        private bool showConeSystemCoord = false;
        private bool showSceneSystemCoord = false;

        private bool isMoveCube = false;
        private bool isMoveCone = false;
        private bool isMoveScene = false;

        private bool isAnimation = false;
        private bool isEnabledIntersect = false;

        private const float sideCube = 300.0f;
        private const float heightCone = 300.0f;
        private const float radiusCone = 200.0f;

        private readonly bool[] rotatations = new bool[6];
        private readonly bool[] translations = new bool[6];
        private readonly bool[] scaling = new bool[2];

        private readonly float rotateSpeed = 5.0f;
        private readonly float translateSpeed = 25.0f;
        private readonly float zoomSpeed = 0.05f;
        private float zoom = 1.0f;

        private readonly float animationSpeed = 1.0f;

        public MainForm()
        {
            InitializeComponent();
            openglControl1.MouseWheel += OpenglControl1_MouseWheel;

            cube = new Cube(new Angles(0.0f, 0.0f, 0.0f), new Position(0.0f, 0.0f, 0.0f), sideCube)
            {
                ColorFaces = [0.0f, 1.0f, 0.0f, 1.0f]
            };

            cone = new Cone(new Angles(0.0f, 0.0f, 0.0f), new Position(0.0f, 0.0f, 0.0f), heightCone, radiusCone)
            {
                ColorFaces = [0.0f, 0.0f, 1.0f, 1.0f]
            };

            scene = new Scene(new Angles(0.0f, 0.0f, 0.0f), new Position(0.0f, 0.0f, 0.0f));

            timer1.Interval = 17; // 60 FPS

            ConfigureNumerics(this);
            SetValuesAllControls();
        }

        private void ConfigureNumerics(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BorderStyle = BorderStyle.FixedSingle;
                    numericUpDown.DecimalPlaces = 2;
                    numericUpDown.Font = new Font(panel1.Font, FontStyle.Regular);

                    numericUpDown.Minimum = int.MinValue;
                    numericUpDown.Maximum = int.MaxValue;
                    numericUpDown.Increment = (decimal)1.0;

                    numericUpDown.Enter += numericUpDown_Enter;
                    numericUpDown.KeyDown += numericUpDown_KeyDown;
                    numericUpDown.KeyUp += numericUpDown_KeyUp;
                    numericUpDown.Leave += numericUpDown_Leave;
                }
                if (control.HasChildren)
                {
                    ConfigureNumerics(control);
                }
            }
        }

        private void SetValuesAllControls()
        {
            label13.Text = string.Empty;
            label7.Text = openglControl1.Width.ToString();
            label9.Text = openglControl1.Height.ToString();

            colorDialogCube.Color = ConvertFloatToColor(cube.ColorFaces);
            colorDialogCone.Color = ConvertFloatToColor(cone.ColorFaces);

            SetValuesCubeNumerics();
            SetValuesConeNumerics();
            SetValuesZoomNumeric();
        }

        private void SetValuesCubeNumerics()
        {
            numericUpDown1.Value = (decimal)cube.Side;

            numericUpDown2.Value = (decimal)cube.PosX;
            numericUpDown3.Value = (decimal)cube.PosY;
            numericUpDown20.Value = (decimal)cube.PosZ;

            numericUpDown4.Value = (decimal)cube.AngleX;
            numericUpDown5.Value = (decimal)cube.AngleY;
            numericUpDown6.Value = (decimal)cube.AngleZ;
        }

        private void SetValuesConeNumerics()
        {
            numericUpDown7.Value = (decimal)cone.Height;
            numericUpDown8.Value = (decimal)cone.Radius;

            numericUpDown9.Value = (decimal)cone.PosX;
            numericUpDown10.Value = (decimal)cone.PosY;
            numericUpDown21.Value = (decimal)cone.PosZ;

            numericUpDown11.Value = (decimal)cone.AngleX;
            numericUpDown12.Value = (decimal)cone.AngleY;
            numericUpDown13.Value = (decimal)cone.AngleZ;
        }

        private void SetValuesSceneNumerics()
        {
            numericUpDown14.Value = (decimal)scene.PosX;
            numericUpDown15.Value = (decimal)scene.PosY;
            numericUpDown22.Value = (decimal)scene.PosZ;

            numericUpDown16.Value = (decimal)scene.AngleX;
            numericUpDown17.Value = (decimal)scene.AngleY;
            numericUpDown18.Value = (decimal)scene.AngleZ;
        }

        private void SetValuesZoomNumeric()
        {
            numericUpDown19.Value = (decimal)zoom;
        }

        private void GetValuesCubeNumerics()
        {
            try
            {
                if (numericUpDown1.Value <= 0)
                {
                    numericUpDown1.Value = Math.Abs(numericUpDown1.Value);
                    throw new Exception(" значение стороны куба может быть только положительным!");
                }
                cube.Side = (float)numericUpDown1.Value;

                cube.PosX = (float)numericUpDown2.Value;
                cube.PosY = (float)numericUpDown3.Value;
                cube.PosZ = (float)numericUpDown20.Value;

                cube.AngleX = (float)numericUpDown4.Value;
                cube.AngleY = (float)numericUpDown5.Value;
                cube.AngleZ = (float)numericUpDown6.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void GetValuesConeNumerics()
        {
            try
            {
                if (numericUpDown7.Value <= 0)
                {
                    numericUpDown7.Value = Math.Abs(numericUpDown7.Value);
                    throw new Exception(" значение высоты конуса может быть только положительным!");
                }
                cone.Height = (float)numericUpDown7.Value;

                if (numericUpDown8.Value <= 0)
                {
                    numericUpDown8.Value = Math.Abs(numericUpDown8.Value);
                    throw new Exception(" значение радиуса конуса может быть только положительным!");
                }
                cone.Radius = (float)numericUpDown8.Value;

                cone.PosX = (float)numericUpDown9.Value;
                cone.PosY = (float)numericUpDown10.Value;
                cone.PosZ = (float)numericUpDown21.Value;

                cone.AngleX = (float)numericUpDown11.Value;
                cone.AngleY = (float)numericUpDown12.Value;
                cone.AngleZ = (float)numericUpDown13.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void GetValuesSceneNumerics()
        {
            scene.PosX = (float)numericUpDown14.Value;
            scene.PosY = (float)numericUpDown15.Value;
            scene.PosZ = (float)numericUpDown22.Value;

            scene.AngleX = (float)numericUpDown16.Value;
            scene.AngleY = (float)numericUpDown17.Value;
            scene.AngleZ = (float)numericUpDown18.Value;
        }

        private void GetValuesZoomNumerics()
        {
            try
            {
                if (numericUpDown19.Value <= 0)
                {
                    numericUpDown19.Value = Math.Abs(numericUpDown19.Value);
                    throw new Exception(" значение коэффициента масштабирования может быть только положительным!");
                }
                zoom = (float)numericUpDown19.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void SetupSceneLighting(OpenGL gl)
        {
            float halfH = (float)openglControl1.Height / 2;
            float halfW = (float)openglControl1.Width / 2;

            // Включение системы освещения OpenGL
            gl.Enable(OpenGL.GL_LIGHTING);
            // Включение нормализации нормалей для корректного освещения после масштабирования
            gl.Enable(OpenGL.GL_NORMALIZE);

            // Настройка первого источника света (GL_LIGHT0)
            gl.Enable(OpenGL.GL_LIGHT0);

            float[] light0Diffuse = [0.8f, 0.8f, 0.8f, 1.0f];
            float[] light0Ambient = [0.3f, 0.3f, 0.3f, 1.0f];
            float[] light0Specular = [0.8f, 0.8f, 0.8f, 1.0f];
            float[] light0Position = [halfW * 2 - 400, halfH * 2 - 200, halfW * 3, 1.0f];

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0Diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0Ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0Specular);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0Position);

            // Настройка второго источника света (GL_LIGHT1)
            gl.Enable(OpenGL.GL_LIGHT1);

            float[] light1Diffuse = [0.6f, 0.6f, 0.6f, 1.0f];
            float[] light1Ambient = [0.2f, 0.2f, 0.2f, 1.0f];
            float[] light1Specular = [0.0f, 0.0f, 0.0f, 1.0f];
            float[] light1Position = [-halfW * 2 + 100, -halfH * 2 + 500, halfW * 3, 1.0f];

            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_DIFFUSE, light1Diffuse);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, light1Ambient);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_SPECULAR, light1Specular);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_POSITION, light1Position);
        }

        // Настройка материалов для объектов на сцене
        private void SetupSceneMaterials(OpenGL gl)
        {
            float[] materialAmbient = [0.2f, 0.2f, 0.2f, 1.0f];
            float[] materialDiffuse = ConvertColorToFloat([255, 167, 0, 255]);
            float[] materialSpecular = [0.9f, 0.9f, 0.9f, 1.0f];
            float materialShininess = 40.0f;

            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_AMBIENT, materialAmbient);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, materialDiffuse);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SPECULAR, materialSpecular);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, materialShininess);
        }

        private float[] ConvertColorToFloat(Color color)
        {
            return [color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f];
        }

        private float[] ConvertColorToFloat(byte[] color)
        {
            return [color[0] / 255f, color[1] / 255f, color[2] / 255f, color[3] / 255f];
        }

        private Color ConvertFloatToColor(float[] color)
        {
            byte r = (byte)(color[0] * 255);
            byte g = (byte)(color[1] * 255);
            byte b = (byte)(color[2] * 255);
            byte a = (byte)(color[3] * 255);

            return Color.FromArgb(a, r, g, b);
        }

        private void openglControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openglControl1.OpenGL;
            gl.ClearColor(0.98f, 0.98f, 0.98f, 1.0f);
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            SetupSceneLighting(gl);
            SetupSceneMaterials(gl);
        }

        private void openglControl1_Resized(object sender, EventArgs e)
        {
            float halfH = (float)openglControl1.Height / 2;
            float halfW = (float)openglControl1.Width / 2;

            OpenGL gl = openglControl1.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, openglControl1.Width, openglControl1.Height);
            gl.Ortho(-halfW, halfW, -halfH, halfH, -halfW * 6, halfW * 6);
            gl.LookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void openglControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openglControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            
            SettingMovement();

            if (!isEnabledIntersect)
            {
                label13.Text = string.Empty;

                gl.Enable(OpenGL.GL_POLYGON_OFFSET_FILL);
                gl.PolygonOffset(1.0f, 0.1f);
                if (showCone) PrintCone(gl);
                gl.Disable(OpenGL.GL_POLYGON_OFFSET_FILL);

                if (showCube) PrintCube(gl);
            }

            if (isEnabledIntersect)
            {
                if (showCube && showCone)
                {
                    List<Vector3> intersectPoints = GetIntersectPoints(gl);
                    if (intersectPoints.Count > 0)
                    {
                        label13.Text = "Фигуры пересекаются";
                        scene.DrawVertex(gl, intersectPoints);
                        List<Vertex> vertices = Algorithms.Vertex3ToVertex(intersectPoints);
                        var triangulation = ConvexHull.Create<Vertex, TriangulatedFace>(vertices);
                        if (triangulation.Result != null)
                        {
                            List<TriangulatedFace> faces = new(triangulation.Result.Faces);
                            scene.RenderMesh(gl, faces);
                        }
                    }
                    else
                    {
                        label13.Text = "Фигуры не пересекаются";
                    }
                }
                else
                {
                    label13.Text = "Фигуры не пересекаются";
                }
            }
        }

        private List<Vector3> GetIntersectPoints(OpenGL gl)
        {
            gl.PushMatrix();
            gl.Scale(zoom, zoom, zoom);
            scene.Move(gl);
            cube.Move(gl);
            Vector3[] verticesCube = Algorithms.ApplyTransformVertixes(gl, cube.GetVertices());
            List<Triangle> facesCube = cube.GetFaces(verticesCube);
            gl.PopMatrix();

            gl.PushMatrix();
            gl.Scale(zoom, zoom, zoom);
            scene.Move(gl);
            cone.Move(gl);
            Vector3[] verticesCone = Algorithms.ApplyTransformVertixes(gl, cone.GetVertices());
            List<Triangle> facesCone = [];
            facesCone.AddRange(cone.GetFacesBase(verticesCone));
            facesCone.AddRange(cone.GetFacesSide(verticesCone));
            gl.PopMatrix();

            List<Vector3> intersectPoints = [];
            intersectPoints.AddRange(Algorithms.FindPointsIntersect(facesCube, facesCone));
            intersectPoints.AddRange(Algorithms.FindPointsInShapes(verticesCone, verticesCube));
            intersectPoints = Algorithms.RemoveDuplicates(intersectPoints, Algorithms.Epsilon);

            return intersectPoints;
        }

        private void PrintCube(OpenGL gl)
        {
            gl.PushMatrix();

            gl.Scale(zoom, zoom, zoom);
            scene.Move(gl);

            if (showSceneSystemCoord)
                scene.DrawCoordSystem(gl, 100f);

            cube.Move(gl);

            if (showCubeSystemCoord)
                cube.DrawCoordSystem(gl, cube.Side);

            cube.Draw(gl);

            gl.PopMatrix();
        }

        private void PrintCone(OpenGL gl)
        {
            gl.PushMatrix();

            gl.Scale(zoom, zoom, zoom);
            scene.Move(gl);

            if (showSceneSystemCoord)
                scene.DrawCoordSystem(gl, 100f);

            cone.Move(gl);

            if (showConeSystemCoord)
                cone.DrawCoordSystem(gl, cone.Height + cone.Radius);

            cone.Draw(gl);

            gl.PopMatrix();
        }

        private void SettingMovement()
        {
            GetValuesZoomNumerics();
            UpdateZoom();
            SetValuesZoomNumeric();

            if (!isAnimation)
            {
                GetValuesCubeNumerics();
                GetValuesConeNumerics();
                GetValuesSceneNumerics();

                UpdatePosObjects(cube, isMoveCube);
                UpdatePosObjects(cone, isMoveCone);
                UpdatePosObjects(scene, isMoveScene);
            }

            SetValuesCubeNumerics();
            SetValuesConeNumerics();
            SetValuesSceneNumerics();
        }

        private void UpdatePosObjects(Shape3D shape3D, bool isMove)
        {
            if (!isMove) return;

            if (rotatations[0]) shape3D.AngleX -= rotateSpeed;
            if (rotatations[1]) shape3D.AngleX += rotateSpeed;
            if (rotatations[2]) shape3D.AngleY += rotateSpeed;
            if (rotatations[3]) shape3D.AngleY -= rotateSpeed;
            if (rotatations[4]) shape3D.AngleZ += rotateSpeed;
            if (rotatations[5]) shape3D.AngleZ -= rotateSpeed;

            shape3D.NormAngles();

            if (translations[0]) shape3D.PosX -= translateSpeed;
            if (translations[1]) shape3D.PosX += translateSpeed;
            if (translations[2]) shape3D.PosY += translateSpeed;
            if (translations[3]) shape3D.PosY -= translateSpeed;
            if (translations[4]) shape3D.PosZ -= translateSpeed;
            if (translations[5]) shape3D.PosZ += translateSpeed;
        }

        private void UpdateZoom()
        {
            if (scaling[0])
            {
                zoom += zoomSpeed;
            }
            if (scaling[1] && zoom - zoomSpeed > 0)
            {
                zoom -= zoomSpeed;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }

            switch (e.Index)
            {
                case 0:
                    isMoveCube = !isMoveCube;
                    groupBox3.Visible = isMoveCube;
                    break;
                case 1:
                    isMoveCone = !isMoveCone;
                    groupBox4.Visible = isMoveCone;
                    break;
                case 2:
                    isMoveScene = !isMoveScene;
                    groupBox5.Visible = isMoveScene;
                    break;
            }
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    showCube = !showCube;
                    break;
                case 1:
                    showCone = !showCone;
                    break;
                case 2:
                    showCubeSystemCoord = !showCubeSystemCoord;
                    break;
                case 3:
                    showConeSystemCoord = !showConeSystemCoord;
                    break;
                case 4:
                    showSceneSystemCoord = !showSceneSystemCoord;
                    break;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();
            ActiveControl = openglControl1;
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox2.ClearSelected();
            ActiveControl = openglControl1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            EnabledMove(e, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            EnabledMove(e, false);
        }

        private void OpenglControl1_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoom += zoomSpeed;
            }
            else if (zoom - zoomSpeed > 0)
            {
                zoom -= zoomSpeed;
            }

            SetValuesZoomNumeric();
        }

        private void EnabledMove(KeyEventArgs e, bool enabled)
        {
            if (e.KeyCode == Keys.W) rotatations[0] = enabled;
            if (e.KeyCode == Keys.S) rotatations[1] = enabled;
            if (e.KeyCode == Keys.D) rotatations[2] = enabled;
            if (e.KeyCode == Keys.A) rotatations[3] = enabled;
            if (e.KeyCode == Keys.Q) rotatations[4] = enabled;
            if (e.KeyCode == Keys.E) rotatations[5] = enabled;

            if (e.KeyCode == Keys.Left) translations[0] = enabled;
            if (e.KeyCode == Keys.Right) translations[1] = enabled;
            if (e.KeyCode == Keys.Up) translations[2] = enabled;
            if (e.KeyCode == Keys.Down) translations[3] = enabled;
            if (e.KeyCode == Keys.Z) translations[4] = enabled;
            if (e.KeyCode == Keys.X) translations[5] = enabled;

            if (e.KeyCode == Keys.Oemplus) scaling[0] = enabled;
            if (e.KeyCode == Keys.OemMinus) scaling[1] = enabled;
        }

        private void buttonAnim_Click(object sender, EventArgs e)
        {
            if (!isAnimation)
            {
                timer1.Start();
                isAnimation = true;
                EnabledNumerics(panel1, false);

                checkedListBox1.SetItemChecked(2, true);
                checkedListBox2.SetItemChecked(0, true);
                checkedListBox2.SetItemChecked(1, true);

                checkedListBox1.Enabled = false;

                buttonAnim.Text = "Остановить анимацию";
            }
            else
            {
                timer1.Stop();
                isAnimation = false;
                EnabledNumerics(panel1, true);

                checkedListBox1.Enabled = true;

                buttonAnim.Text = "Запустить анимацию";
            }
        }

        private void EnabledNumerics(Control parent, bool enabled)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.Enabled = enabled;
                }

                if (control.HasChildren)
                {
                    EnabledNumerics(control, enabled);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.AngleX += animationSpeed;
            scene.AngleY += animationSpeed;
            scene.NormAngles();
        }

        private void numericUpDown_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void numericUpDown_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActiveControl = openglControl1;
            }
        }

        private void numericUpDown_Leave(object? sender, EventArgs e)
        {
            openglControl1.RenderTrigger = RenderTrigger.TimerBased;
        }

        private void numericUpDown_Enter(object? sender, EventArgs e)
        {
            openglControl1.RenderTrigger = RenderTrigger.Manual;
        }

        private void openglControl1_SizeChanged(object sender, EventArgs e)
        {
            label7.Text = openglControl1.Width.ToString();
            label9.Text = openglControl1.Height.ToString();
        }

        private void buttonCube_Click(object sender, EventArgs e)
        {
            if (colorDialogCube.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialogCube.Color;
                cube.ColorFaces = ConvertColorToFloat(color);
            }
        }

        private void buttonCone_Click(object sender, EventArgs e)
        {
            if (colorDialogCone.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialogCone.Color;
                cone.ColorFaces = ConvertColorToFloat(color);
            }
        }

        private void buttonIntersection_Click(object sender, EventArgs e)
        {
            isEnabledIntersect = !isEnabledIntersect;
            if (!isEnabledIntersect)
            {
                buttonIntersection.Text = "Поиск пересечения";
            }
            else
            {
                buttonIntersection.Text = "Показать исходные объекты";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    (cube, cone) = OpenSaveFile.CreateObjects(openFileDialog1.FileName);
                    SetValuesCubeNumerics();
                    SetValuesConeNumerics();
                }
                catch (Exception)
                {
                    MessageBox.Show($"Ошибка: неверный формат файла объектов!");
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private bool SaveData()
        {
            saveFileDialog1.FileName = "scene";
            saveFileDialog1.Filter = "scene (.obj)|*.obj";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                OpenSaveFile.SaveObjects(filePath, cube, cone);
                return true;
            }
            else return false;
        }

        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Руководство пользователя");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Сохранить состояние сцены?",
                "Сохранение сцены",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (!SaveData())
                {
                    e.Cancel = true;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
