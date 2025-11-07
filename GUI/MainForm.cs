using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace mso_2
{
    public partial class MainForm : Form
    {
        ClientGUI clientGUI;
        public MainForm()
        {
            InitializeComponent();

            clientGUI = new ClientGUI();

            var LoadProgramsGUI = new LoadProgramsGUI(clientGUI);
            LoadProgramsGUI.Location = new Point(10, 10);
            this.Controls.Add(LoadProgramsGUI);

            var TextEditorGUI = new TextEditorGUI(clientGUI);
            TextEditorGUI.Location = new Point(200, 10);
            this.Controls.Add(TextEditorGUI);

            var GridGUI = new GridGUI(clientGUI);
            GridGUI.Size = new Size(300, 300);
            GridGUI.Location = new Point(750, 10);
            this.Controls.Add(GridGUI);

            LoadProgramsGUI.SetEditorText += (s, msg) => TextEditorGUI.SetEditorText(msg);
            TextEditorGUI.UpdateGrid += (s, msg) => GridGUI.Invalidate();
            LoadProgramsGUI.UpdateGrid += (s, msg) => GridGUI.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
