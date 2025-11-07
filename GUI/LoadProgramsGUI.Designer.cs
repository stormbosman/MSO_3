namespace mso_2
{
    partial class LoadProgramsGUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadProgram = new Button();
            BeginnerProgram = new Button();
            IntermediateProgram = new Button();
            AdvancedProgram = new Button();
            LoadFile = new Button();
            LoadGrid = new Button();
            SuspendLayout();
            // 
            // LoadProgram
            // 
            LoadProgram.BackColor = Color.OliveDrab;
            LoadProgram.ForeColor = Color.White;
            LoadProgram.Location = new Point(0, 0);
            LoadProgram.Name = "LoadProgram";
            LoadProgram.Size = new Size(161, 59);
            LoadProgram.TabIndex = 0;
            LoadProgram.Text = "Load Program";
            LoadProgram.UseVisualStyleBackColor = false;
            LoadProgram.Click += LoadProgram_Click;
            // 
            // BeginnerProgram
            // 
            BeginnerProgram.BackColor = Color.Lime;
            BeginnerProgram.ForeColor = Color.White;
            BeginnerProgram.Location = new Point(18, 65);
            BeginnerProgram.Name = "BeginnerProgram";
            BeginnerProgram.Size = new Size(120, 43);
            BeginnerProgram.TabIndex = 1;
            BeginnerProgram.Text = "Beginner";
            BeginnerProgram.UseVisualStyleBackColor = false;
            BeginnerProgram.Click += BeginnerProgram_Click;
            // 
            // IntermediateProgram
            // 
            IntermediateProgram.BackColor = Color.Gold;
            IntermediateProgram.ForeColor = Color.White;
            IntermediateProgram.Location = new Point(18, 127);
            IntermediateProgram.Name = "IntermediateProgram";
            IntermediateProgram.Size = new Size(120, 41);
            IntermediateProgram.TabIndex = 2;
            IntermediateProgram.Text = "Intermediate";
            IntermediateProgram.UseVisualStyleBackColor = false;
            IntermediateProgram.Click += IntermediateProgram_Click;
            // 
            // AdvancedProgram
            // 
            AdvancedProgram.BackColor = Color.Crimson;
            AdvancedProgram.ForeColor = Color.White;
            AdvancedProgram.Location = new Point(18, 186);
            AdvancedProgram.Name = "AdvancedProgram";
            AdvancedProgram.Size = new Size(120, 41);
            AdvancedProgram.TabIndex = 3;
            AdvancedProgram.Text = "Advanced";
            AdvancedProgram.UseVisualStyleBackColor = false;
            AdvancedProgram.Click += AdvancedProgram_Click;
            // 
            // LoadFile
            // 
            LoadFile.BackColor = Color.Purple;
            LoadFile.ForeColor = Color.White;
            LoadFile.Location = new Point(18, 245);
            LoadFile.Name = "LoadFile";
            LoadFile.Size = new Size(120, 41);
            LoadFile.TabIndex = 4;
            LoadFile.Text = "Load File";
            LoadFile.UseVisualStyleBackColor = false;
            LoadFile.Click += LoadFile_Click;
            // 
            // LoadGrid
            // 
            LoadGrid.BackColor = Color.OliveDrab;
            LoadGrid.ForeColor = Color.White;
            LoadGrid.Location = new Point(3, 292);
            LoadGrid.Name = "LoadGrid";
            LoadGrid.Size = new Size(161, 59);
            LoadGrid.TabIndex = 5;
            LoadGrid.Text = "Load Grid";
            LoadGrid.UseVisualStyleBackColor = false;
            LoadGrid.Click += LoadGrid_Click;
            // 
            // LoadProgramsGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(LoadGrid);
            Controls.Add(LoadFile);
            Controls.Add(BeginnerProgram);
            Controls.Add(IntermediateProgram);
            Controls.Add(AdvancedProgram);
            Controls.Add(LoadProgram);
            Name = "LoadProgramsGUI";
            Size = new Size(171, 354);
            ResumeLayout(false);
        }

        #endregion

        private Button LoadProgram;
        private Button BeginnerProgram;
        private Button IntermediateProgram;
        private Button AdvancedProgram;
        private Button button1;
        private Button LoadFile;
        private Button LoadGrid;
    }
}
