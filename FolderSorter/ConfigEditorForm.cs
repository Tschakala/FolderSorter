using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSorter
{
    internal class ConfigEditorForm : Form
    {
        private readonly string _path;
        private readonly DataGridView _grid = new DataGridView { Dock = DockStyle.Fill };

        public ConfigEditorForm(string path, Dictionary<string, string> config)
        {
            _path = path;
            _grid.Columns.Add("Key", "Key");
            _grid.Columns.Add("Value", "Value");
            _grid.Columns[0].Width = 200;
            _grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for(int i = 0; i < config.Count; i++)
            {
                _grid.Rows.Add(config.Keys.ElementAt(i), config.Values.ElementAt(i));
            }

            var saveBtn = new Button { Text = "Save", Dock = DockStyle.Bottom };
            saveBtn.Click += Save;

            Controls.Add(_grid);
            Controls.Add(saveBtn);
            Size = new System.Drawing.Size(500, 400);
        }

        private void Save(object s, EventArgs e)
        {
            var lines = _grid.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[0].Value != null)
                .Select(r => $"{r.Cells[0].Value}={r.Cells[1].Value}");

            File.WriteAllLines(_path, lines);
            Close();
        }

        private void ConfigEditorForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            // 
            // ConfigEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ConfigEditorForm";
            this.ShowIcon = false;
            this.Text = "Config Editor";
            this.ResumeLayout(false);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ConfigEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.MaximizeBox = false;
            this.Name = "ConfigEditorForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }
    }
}
