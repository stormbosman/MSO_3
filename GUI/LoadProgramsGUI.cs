using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mso_2
{
    public partial class LoadProgramsGUI : UserControl
    {
        bool visible;

        public event EventHandler? UpdateGrid;

        public event EventHandler<string>? SetEditorText;
        ClientGUI clientGUI;
        public LoadProgramsGUI(ClientGUI ClientGUI)
        {
            InitializeComponent();

            visible = false;

            clientGUI = ClientGUI;

            BeginnerProgram.Visible = visible;
            IntermediateProgram.Visible = visible;
            AdvancedProgram.Visible = visible;
            LoadFile.Visible = visible;
        }

        private void LoadProgram_Click(object sender, EventArgs e)
        {
            visible = !visible;

            BeginnerProgram.Visible = visible;
            IntermediateProgram.Visible = visible;
            AdvancedProgram.Visible = visible;
            LoadFile.Visible = visible;
        }

        private void BeginnerProgram_Click(object sender, EventArgs e)
        {
            ReadFile(@"..\..\..\Examples\BasicProgram.txt");
        }

        private void IntermediateProgram_Click(object sender, EventArgs e)
        {
            ReadFile(@"..\..\..\Examples\IntermediateProgram.txt");
        }

        private void AdvancedProgram_Click(object sender, EventArgs e)
        {
            ReadFile(@"..\..\..\Examples\AdvancedProgram.txt");
        }

        private void LoadFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ReadFile(filePath);
            }
        }

        private void ReadFile(string filePath)
        {
            SetEditorText?.Invoke(this, File.ReadAllText(filePath));
        }

        private void LoadGrid_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                clientGUI.LoadGridFromFile(filePath);
                UpdateGrid?.Invoke(this, new EventArgs());
            }
        }
    }
}
