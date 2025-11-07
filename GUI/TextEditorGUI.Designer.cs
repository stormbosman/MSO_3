namespace mso_2
{
    partial class TextEditorGUI
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
            TextBox = new TextBox();
            Run = new Button();
            Metrics = new Button();
            Export = new Button();
            Output = new TextBox();
            SuspendLayout();
            // 
            // TextBox
            // 
            TextBox.Location = new Point(0, 0);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(598, 322);
            TextBox.TabIndex = 0;
            // 
            // Run
            // 
            Run.BackColor = SystemColors.Highlight;
            Run.ForeColor = Color.White;
            Run.Location = new Point(3, 328);
            Run.Name = "Run";
            Run.Size = new Size(112, 40);
            Run.TabIndex = 1;
            Run.Text = "Run";
            Run.UseVisualStyleBackColor = false;
            Run.Click += Run_Click;
            // 
            // Metrics
            // 
            Metrics.BackColor = SystemColors.Highlight;
            Metrics.ForeColor = SystemColors.ButtonHighlight;
            Metrics.Location = new Point(121, 328);
            Metrics.Name = "Metrics";
            Metrics.Size = new Size(124, 40);
            Metrics.TabIndex = 2;
            Metrics.Text = "Metrics";
            Metrics.UseVisualStyleBackColor = false;
            Metrics.Click += Metrics_Click;
            // 
            // Export
            // 
            Export.BackColor = SystemColors.Highlight;
            Export.ForeColor = SystemColors.ButtonHighlight;
            Export.Location = new Point(251, 328);
            Export.Name = "Export";
            Export.Size = new Size(250, 40);
            Export.TabIndex = 2;
            Export.Text = "Export";
            Export.UseVisualStyleBackColor = false;
            Export.Click += Export_Click;
            // 
            // Output
            // 
            Output.BackColor = SystemColors.Info;
            Output.Location = new Point(3, 374);
            Output.Multiline = true;
            Output.Name = "Output";
            Output.ReadOnly = true;
            Output.Size = new Size(595, 111);
            Output.TabIndex = 3;
            // 
            // TextEditorGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Output);
            Controls.Add(Export);
            Controls.Add(Metrics);
            Controls.Add(Run);
            Controls.Add(TextBox);
            Name = "TextEditorGUI";
            Size = new Size(611, 557);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBox;
        private Button Run;
        private Button Metrics;
        private Button Export;
        private TextBox Output;
    }
}
