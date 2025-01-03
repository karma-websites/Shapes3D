namespace Scene
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            openglControl1 = new SharpGL.OpenGLControl();
            checkedListBox1 = new CheckedListBox();
            panel2 = new Panel();
            panel3 = new Panel();
            label13 = new Label();
            buttonIntersection = new Button();
            panel4 = new Panel();
            label5 = new Label();
            numericUpDown19 = new NumericUpDown();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            buttonAnim = new Button();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            label15 = new Label();
            numericUpDown20 = new NumericUpDown();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            numericUpDown6 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            buttonCube = new Button();
            groupBox4 = new GroupBox();
            label2 = new Label();
            numericUpDown21 = new NumericUpDown();
            label23 = new Label();
            numericUpDown8 = new NumericUpDown();
            label10 = new Label();
            label11 = new Label();
            label14 = new Label();
            numericUpDown13 = new NumericUpDown();
            buttonCone = new Button();
            numericUpDown12 = new NumericUpDown();
            numericUpDown11 = new NumericUpDown();
            numericUpDown10 = new NumericUpDown();
            numericUpDown9 = new NumericUpDown();
            numericUpDown7 = new NumericUpDown();
            label16 = new Label();
            label21 = new Label();
            label22 = new Label();
            groupBox5 = new GroupBox();
            numericUpDown22 = new NumericUpDown();
            label12 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            numericUpDown18 = new NumericUpDown();
            numericUpDown17 = new NumericUpDown();
            numericUpDown16 = new NumericUpDown();
            numericUpDown15 = new NumericUpDown();
            numericUpDown14 = new NumericUpDown();
            label29 = new Label();
            label30 = new Label();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            checkedListBox2 = new CheckedListBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            инструкцияToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            colorDialogCube = new ColorDialog();
            colorDialogCone = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)openglControl1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown19).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown18).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // openglControl1
            // 
            openglControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openglControl1.BackColor = SystemColors.ControlLightLight;
            openglControl1.DrawFPS = true;
            openglControl1.FrameRate = 30;
            openglControl1.Location = new Point(10, 180);
            openglControl1.Margin = new Padding(4);
            openglControl1.Name = "openglControl1";
            openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL3_3;
            openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openglControl1.Size = new Size(1063, 529);
            openglControl1.TabIndex = 2;
            openglControl1.TabStop = false;
            openglControl1.OpenGLInitialized += OpenglControl1_OpenGLInitialized;
            openglControl1.OpenGLDraw += OpenglControl1_OpenGLDraw;
            openglControl1.Resized += OpenglControl1_Resized;
            openglControl1.SizeChanged += openglControl1_SizeChanged;
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Cursor = Cursors.Hand;
            checkedListBox1.Font = new Font("Segoe UI", 9F);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "куб", "конус", "сцена" });
            checkedListBox1.Location = new Point(24, 28);
            checkedListBox1.Margin = new Padding(3, 2, 3, 2);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(180, 58);
            checkedListBox1.TabIndex = 1;
            checkedListBox1.UseCompatibleTextRendering = true;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(12, 715);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1061, 44);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(label13);
            panel3.Controls.Add(buttonIntersection);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(569, 44);
            panel3.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(224, 14);
            label13.Name = "label13";
            label13.Size = new Size(44, 15);
            label13.TabIndex = 2;
            label13.Tag = "label13";
            label13.Text = "label13";
            // 
            // buttonIntersection
            // 
            buttonIntersection.Location = new Point(3, 7);
            buttonIntersection.Margin = new Padding(3, 2, 3, 2);
            buttonIntersection.Name = "buttonIntersection";
            buttonIntersection.Size = new Size(215, 28);
            buttonIntersection.TabIndex = 1;
            buttonIntersection.Text = "Поиск пересечения";
            buttonIntersection.UseVisualStyleBackColor = true;
            buttonIntersection.Click += buttonIntersection_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label5);
            panel4.Controls.Add(numericUpDown19);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(578, 0);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(483, 44);
            panel4.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(304, 14);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 5;
            label5.Text = "Масштаб:";
            // 
            // numericUpDown19
            // 
            numericUpDown19.Location = new Point(401, 12);
            numericUpDown19.Margin = new Padding(3, 2, 3, 2);
            numericUpDown19.Name = "numericUpDown19";
            numericUpDown19.Size = new Size(79, 23);
            numericUpDown19.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(222, 14);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 3;
            label9.Text = "label9";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(157, 14);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 2;
            label8.Text = "Высота:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 14);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 1;
            label7.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 14);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 0;
            label6.Text = "Ширина:";
            // 
            // buttonAnim
            // 
            buttonAnim.Cursor = Cursors.Hand;
            buttonAnim.Font = new Font("Segoe UI", 9F);
            buttonAnim.Location = new Point(24, 101);
            buttonAnim.Margin = new Padding(3, 2, 3, 2);
            buttonAnim.Name = "buttonAnim";
            buttonAnim.Size = new Size(180, 28);
            buttonAnim.TabIndex = 2;
            buttonAnim.Text = "Запустить анимацию";
            buttonAnim.UseVisualStyleBackColor = true;
            buttonAnim.Click += buttonAnim_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(232, 64);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 7;
            label4.Text = "Центр Y:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(230, 28);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 6;
            label3.Text = "Центр X:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(26, 31);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Cторона:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(numericUpDown20);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(numericUpDown6);
            groupBox3.Controls.Add(numericUpDown5);
            groupBox3.Controls.Add(numericUpDown4);
            groupBox3.Controls.Add(numericUpDown3);
            groupBox3.Controls.Add(numericUpDown2);
            groupBox3.Controls.Add(numericUpDown1);
            groupBox3.Controls.Add(buttonCube);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label4);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(484, 5);
            groupBox3.Margin = new Padding(0);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(579, 142);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Куб";
            groupBox3.Visible = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F);
            label15.Location = new Point(230, 103);
            label15.Name = "label15";
            label15.Size = new Size(54, 15);
            label15.TabIndex = 36;
            label15.Text = "Центр Z:";
            // 
            // numericUpDown20
            // 
            numericUpDown20.Location = new Point(304, 101);
            numericUpDown20.Margin = new Padding(3, 2, 3, 2);
            numericUpDown20.Name = "numericUpDown20";
            numericUpDown20.Size = new Size(79, 23);
            numericUpDown20.TabIndex = 5;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F);
            label20.Location = new Point(416, 103);
            label20.Name = "label20";
            label20.Size = new Size(46, 15);
            label20.TabIndex = 27;
            label20.Text = "Угол Z:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F);
            label19.Location = new Point(416, 64);
            label19.Name = "label19";
            label19.Size = new Size(46, 15);
            label19.TabIndex = 26;
            label19.Text = "Угол Y:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F);
            label18.Location = new Point(416, 29);
            label18.Name = "label18";
            label18.Size = new Size(46, 15);
            label18.TabIndex = 25;
            label18.Text = "Угол X:";
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(473, 101);
            numericUpDown6.Margin = new Padding(3, 2, 3, 2);
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(79, 23);
            numericUpDown6.TabIndex = 8;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(473, 63);
            numericUpDown5.Margin = new Padding(3, 2, 3, 2);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(79, 23);
            numericUpDown5.TabIndex = 7;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(473, 26);
            numericUpDown4.Margin = new Padding(3, 2, 3, 2);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(79, 23);
            numericUpDown4.TabIndex = 6;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(304, 63);
            numericUpDown3.Margin = new Padding(3, 2, 3, 2);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(79, 23);
            numericUpDown3.TabIndex = 4;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(304, 26);
            numericUpDown2.Margin = new Padding(3, 2, 3, 2);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(79, 23);
            numericUpDown2.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(129, 28);
            numericUpDown1.Margin = new Padding(3, 2, 3, 2);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(77, 23);
            numericUpDown1.TabIndex = 1;
            // 
            // buttonCube
            // 
            buttonCube.Font = new Font("Segoe UI", 9F);
            buttonCube.Location = new Point(26, 101);
            buttonCube.Margin = new Padding(3, 2, 3, 2);
            buttonCube.Name = "buttonCube";
            buttonCube.Size = new Size(180, 28);
            buttonCube.TabIndex = 2;
            buttonCube.Text = "Установить цвет";
            buttonCube.UseVisualStyleBackColor = true;
            buttonCube.Click += buttonCube_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(numericUpDown21);
            groupBox4.Controls.Add(label23);
            groupBox4.Controls.Add(numericUpDown8);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(numericUpDown13);
            groupBox4.Controls.Add(buttonCone);
            groupBox4.Controls.Add(numericUpDown12);
            groupBox4.Controls.Add(numericUpDown11);
            groupBox4.Controls.Add(numericUpDown10);
            groupBox4.Controls.Add(numericUpDown9);
            groupBox4.Controls.Add(numericUpDown7);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(label21);
            groupBox4.Controls.Add(label22);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(484, 5);
            groupBox4.Margin = new Padding(0);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(579, 142);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Конус";
            groupBox4.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(232, 103);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 35;
            label2.Text = "Центр Z:";
            // 
            // numericUpDown21
            // 
            numericUpDown21.Location = new Point(304, 101);
            numericUpDown21.Margin = new Padding(3, 2, 3, 2);
            numericUpDown21.Name = "numericUpDown21";
            numericUpDown21.Size = new Size(79, 23);
            numericUpDown21.TabIndex = 6;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F);
            label23.Location = new Point(26, 64);
            label23.Name = "label23";
            label23.Size = new Size(79, 15);
            label23.TabIndex = 29;
            label23.Text = "R основания:";
            // 
            // numericUpDown8
            // 
            numericUpDown8.Location = new Point(127, 63);
            numericUpDown8.Margin = new Padding(3, 2, 3, 2);
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(79, 23);
            numericUpDown8.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(415, 103);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 27;
            label10.Text = "Угол Z:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(416, 64);
            label11.Name = "label11";
            label11.Size = new Size(46, 15);
            label11.TabIndex = 26;
            label11.Text = "Угол Y:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F);
            label14.Location = new Point(415, 28);
            label14.Name = "label14";
            label14.Size = new Size(46, 15);
            label14.TabIndex = 25;
            label14.Text = "Угол X:";
            // 
            // numericUpDown13
            // 
            numericUpDown13.Location = new Point(473, 101);
            numericUpDown13.Margin = new Padding(3, 2, 3, 2);
            numericUpDown13.Name = "numericUpDown13";
            numericUpDown13.Size = new Size(79, 23);
            numericUpDown13.TabIndex = 9;
            // 
            // buttonCone
            // 
            buttonCone.Font = new Font("Segoe UI", 9F);
            buttonCone.Location = new Point(26, 101);
            buttonCone.Margin = new Padding(3, 2, 3, 2);
            buttonCone.Name = "buttonCone";
            buttonCone.Size = new Size(180, 28);
            buttonCone.TabIndex = 3;
            buttonCone.Text = "Установить цвет";
            buttonCone.UseVisualStyleBackColor = true;
            buttonCone.Click += buttonCone_Click;
            // 
            // numericUpDown12
            // 
            numericUpDown12.Location = new Point(473, 63);
            numericUpDown12.Margin = new Padding(3, 2, 3, 2);
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(79, 23);
            numericUpDown12.TabIndex = 8;
            // 
            // numericUpDown11
            // 
            numericUpDown11.Location = new Point(473, 26);
            numericUpDown11.Margin = new Padding(3, 2, 3, 2);
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(79, 23);
            numericUpDown11.TabIndex = 7;
            // 
            // numericUpDown10
            // 
            numericUpDown10.Location = new Point(304, 63);
            numericUpDown10.Margin = new Padding(3, 2, 3, 2);
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(79, 23);
            numericUpDown10.TabIndex = 5;
            // 
            // numericUpDown9
            // 
            numericUpDown9.Location = new Point(304, 26);
            numericUpDown9.Margin = new Padding(3, 2, 3, 2);
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(79, 23);
            numericUpDown9.TabIndex = 4;
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(127, 26);
            numericUpDown7.Margin = new Padding(3, 2, 3, 2);
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(79, 23);
            numericUpDown7.TabIndex = 1;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label16.Location = new Point(26, 28);
            label16.Name = "label16";
            label16.Size = new Size(50, 15);
            label16.TabIndex = 4;
            label16.Text = "Высота:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F);
            label21.Location = new Point(230, 28);
            label21.Name = "label21";
            label21.Size = new Size(54, 15);
            label21.TabIndex = 6;
            label21.Text = "Центр X:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 9F);
            label22.Location = new Point(232, 64);
            label22.Name = "label22";
            label22.Size = new Size(54, 15);
            label22.TabIndex = 7;
            label22.Text = "Центр Y:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(numericUpDown22);
            groupBox5.Controls.Add(label12);
            groupBox5.Controls.Add(label24);
            groupBox5.Controls.Add(label25);
            groupBox5.Controls.Add(label26);
            groupBox5.Controls.Add(numericUpDown18);
            groupBox5.Controls.Add(numericUpDown17);
            groupBox5.Controls.Add(numericUpDown16);
            groupBox5.Controls.Add(numericUpDown15);
            groupBox5.Controls.Add(numericUpDown14);
            groupBox5.Controls.Add(label29);
            groupBox5.Controls.Add(label30);
            groupBox5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox5.Location = new Point(484, 5);
            groupBox5.Margin = new Padding(0);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(579, 142);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "Сцена";
            groupBox5.Visible = false;
            // 
            // numericUpDown22
            // 
            numericUpDown22.Location = new Point(114, 100);
            numericUpDown22.Margin = new Padding(3, 2, 3, 2);
            numericUpDown22.Name = "numericUpDown22";
            numericUpDown22.Size = new Size(79, 23);
            numericUpDown22.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(26, 101);
            label12.Name = "label12";
            label12.Size = new Size(54, 15);
            label12.TabIndex = 36;
            label12.Text = "Центр Z:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F);
            label24.Location = new Point(241, 101);
            label24.Name = "label24";
            label24.Size = new Size(46, 15);
            label24.TabIndex = 27;
            label24.Text = "Угол Z:";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 9F);
            label25.Location = new Point(241, 64);
            label25.Name = "label25";
            label25.Size = new Size(46, 15);
            label25.TabIndex = 26;
            label25.Text = "Угол Y:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F);
            label26.Location = new Point(241, 25);
            label26.Name = "label26";
            label26.Size = new Size(46, 15);
            label26.TabIndex = 25;
            label26.Text = "Угол X:";
            // 
            // numericUpDown18
            // 
            numericUpDown18.Location = new Point(304, 101);
            numericUpDown18.Margin = new Padding(3, 2, 3, 2);
            numericUpDown18.Name = "numericUpDown18";
            numericUpDown18.Size = new Size(79, 23);
            numericUpDown18.TabIndex = 6;
            // 
            // numericUpDown17
            // 
            numericUpDown17.Location = new Point(304, 63);
            numericUpDown17.Margin = new Padding(3, 2, 3, 2);
            numericUpDown17.Name = "numericUpDown17";
            numericUpDown17.Size = new Size(79, 23);
            numericUpDown17.TabIndex = 5;
            // 
            // numericUpDown16
            // 
            numericUpDown16.Location = new Point(304, 26);
            numericUpDown16.Margin = new Padding(3, 2, 3, 2);
            numericUpDown16.Name = "numericUpDown16";
            numericUpDown16.Size = new Size(79, 23);
            numericUpDown16.TabIndex = 4;
            // 
            // numericUpDown15
            // 
            numericUpDown15.Location = new Point(114, 63);
            numericUpDown15.Margin = new Padding(3, 2, 3, 2);
            numericUpDown15.Name = "numericUpDown15";
            numericUpDown15.Size = new Size(79, 23);
            numericUpDown15.TabIndex = 2;
            // 
            // numericUpDown14
            // 
            numericUpDown14.Location = new Point(113, 26);
            numericUpDown14.Margin = new Padding(3, 2, 3, 2);
            numericUpDown14.Name = "numericUpDown14";
            numericUpDown14.Size = new Size(79, 23);
            numericUpDown14.TabIndex = 1;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 9F);
            label29.Location = new Point(26, 28);
            label29.Name = "label29";
            label29.Size = new Size(54, 15);
            label29.TabIndex = 6;
            label29.Text = "Центр X:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 9F);
            label30.Location = new Point(26, 64);
            label30.Name = "label30";
            label30.Size = new Size(54, 15);
            label30.TabIndex = 7;
            label30.Text = "Центр Y:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkedListBox1);
            groupBox2.Controls.Add(buttonAnim);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(242, 5);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(235, 142);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметры";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBox2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(0, 5);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(235, 142);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Построить";
            // 
            // checkedListBox2
            // 
            checkedListBox2.CheckOnClick = true;
            checkedListBox2.Cursor = Cursors.Hand;
            checkedListBox2.Font = new Font("Segoe UI", 9F);
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { "куб", "конус", "система координат куба", "система координат конуса", "система координат сцены" });
            checkedListBox2.Location = new Point(24, 26);
            checkedListBox2.Margin = new Padding(3, 2, 3, 2);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(180, 94);
            checkedListBox2.TabIndex = 1;
            checkedListBox2.ItemCheck += checkedListBox2_ItemCheck;
            checkedListBox2.SelectedIndexChanged += checkedListBox2_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlDark;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, инструкцияToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1084, 24);
            menuStrip1.TabIndex = 28;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохранитьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(133, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(133, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // инструкцияToolStripMenuItem
            // 
            инструкцияToolStripMenuItem.Name = "инструкцияToolStripMenuItem";
            инструкцияToolStripMenuItem.Size = new Size(65, 20);
            инструкцияToolStripMenuItem.Text = "Справка";
            инструкцияToolStripMenuItem.Click += инструкцияToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBox5);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(groupBox2);
            panel1.Location = new Point(10, 25);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1063, 151);
            panel1.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 761);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(openglControl1);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1100, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Моделирование объемных фигур";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)openglControl1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown19).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown20).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown21).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown22).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown18).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
        private CheckedListBox checkedListBox1;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button buttonAnim;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private CheckedListBox checkedListBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private Button buttonCube;
        private Panel panel4;
        private Panel panel3;
        private System.Windows.Forms.Timer timer1;
        private Label label18;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label20;
        private Label label19;
        private ToolStripMenuItem инструкцияToolStripMenuItem;
        private Panel panel1;
        private ColorDialog colorDialogCube;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private GroupBox groupBox4;
        private Label label10;
        private Label label11;
        private Label label14;
        private NumericUpDown numericUpDown13;
        private NumericUpDown numericUpDown12;
        private NumericUpDown numericUpDown11;
        private NumericUpDown numericUpDown10;
        private NumericUpDown numericUpDown9;
        private NumericUpDown numericUpDown7;
        private Button buttonCone;
        private Label label16;
        private Label label21;
        private Label label22;
        private Label label23;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown19;
        private Label label5;
        private GroupBox groupBox5;
        private Label label24;
        private Label label25;
        private Label label26;
        private NumericUpDown numericUpDown18;
        private NumericUpDown numericUpDown17;
        private NumericUpDown numericUpDown16;
        private NumericUpDown numericUpDown15;
        private NumericUpDown numericUpDown14;
        private Label label29;
        private Label label30;
        private Button buttonIntersection;
        private ColorDialog colorDialogCone;
        private Label label15;
        private NumericUpDown numericUpDown20;
        private Label label2;
        private NumericUpDown numericUpDown21;
        private NumericUpDown numericUpDown22;
        private Label label12;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Label label13;
    }
}
