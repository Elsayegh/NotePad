using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Notes", typeof(String));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Notes"].Visible = false;
            dataGridView1.Columns["Title"].Width = dataGridView1.Width;
        }

        private void newNote_Click(object sender, EventArgs e)
        {
            textTitle.Clear();
            messageText.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textTitle.Text, messageText.Text);
            textTitle.Clear();
            messageText.Clear();

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            if(index > -1)
            {
                textTitle.Text = table.Rows[index].ItemArray[0].ToString();
                messageText.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            table.Rows[index].Delete();
        }
    }
}
