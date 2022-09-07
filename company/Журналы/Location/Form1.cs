using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ПЗ_06;

namespace ПЗ_07.Журналы.Location
{
    public partial class Журнал_местоположений : Form
    {
        public Журнал_местоположений()
        {
            InitializeComponent();
        }

        private void Журнал_местоположений_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "select nomer as \"Номер\", subdivision.name as \"Подразделение\",location as \"Местоположение\",data as \"Дата\" from fixing_the_location left " +
                "join subdivision on subdivision.id = fixing_the_location.id_subdivision;";
            Меню.Table_Fill("Локация",sql);

            dataGridView1.DataSource = Меню.ds.Tables["Локация"];
            dataGridView1.BackgroundColor=SystemColors.Control;
            dataGridView1.BorderStyle=BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void Журнал_местоположений_Activated(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }
        public static int n = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            n = dataGridView1.Rows.Count;
            int kod;
            if (n > 0)
                kod = Convert.ToInt32(dataGridView1.Rows[n - 1].Cells["Номер"].Value) + 1;
            else kod = 1;

            string sql = $"INSERT INTO fixing_the_location (nomer) values({kod})";
            Меню.Modification_Execute(sql);

            Меню.ds.Tables["Локация"].Rows.Add(new object[] {kod,null,null,null});
            dataGridView1.CurrentCell = null;

            Закрепление_местоположения закрепление_Местоположения = new Закрепление_местоположения();
            закрепление_Местоположения.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = dataGridView1.CurrentRow.Index;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Закрепление_местоположения закрепление_Местоположения = new Закрепление_местоположения();
            закрепление_Местоположения.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg="";
            try
            {
                msg = $"Вы точно хотите удалить местоположение с номером {dataGridView1.Rows[n].Cells["Номер"].Value}?";
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Не указана удаляемая запись таблицы!!!", "Ошибка");
            }
            string caption = "Удаление местоположения";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, caption, buttons);
            if(result == DialogResult.No) { return; }

            string sql= $"DELETE FROM fixing_the_location WHERE nomer={dataGridView1.Rows[n].Cells["Номер"].Value}";
            Меню.Modification_Execute(sql);
            Меню.ds.Tables["Локация"].Rows.RemoveAt(n);
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
            n = -1;

        }
    }
}
