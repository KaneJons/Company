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

namespace ПЗ_07.Журналы.Director
{
    public partial class Журнал_руководителей : Form
    {
        public Журнал_руководителей()
        {
            InitializeComponent();
        }

        private void Журнал_руководителей_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "select consolidation_of_the_head.nomer as \"Номер\",subdivision.name\"Подразделение\",manager.fio\"Руководитель\",consolidation_of_the_head.data\"Дата\" " +
                "from ((consolidation_of_the_head left join subdivision on subdivision.id = consolidation_of_the_head.id_subdivision)" +
                " left join manager on manager.id=consolidation_of_the_head.id_manager);";
            Меню.Table_Fill("Менеджер", sql);

            dataGridView1.DataSource = Меню.ds.Tables["Менеджер"];
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Журнал_руководителей_Activated(object sender, EventArgs e)
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

            string sql = $"INSERT INTO consolidation_of_the_head (nomer) values({kod})";
            Меню.Modification_Execute(sql);

            Меню.ds.Tables["Менеджер"].Rows.Add(new object[] { kod, null, null, null });
            dataGridView1.CurrentCell = null;

            Закрепление_руководителя закрепление_Руководителя = new Закрепление_руководителя();
            закрепление_Руководителя.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Закрепление_руководителя закрепление_Руководителя = new Закрепление_руководителя();
            закрепление_Руководителя.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = dataGridView1.CurrentRow.Index;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                msg = $"Вы точно хотите удалить руководителя с номером {dataGridView1.Rows[n].Cells["Номер"].Value}?";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Не указана удаляемая запись таблицы!!!", "Ошибка");
            }
            string caption = "Удаление руководителя";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, caption, buttons);
            if (result == DialogResult.No) { return; }

            string sql = $"DELETE FROM consolidation_of_the_head WHERE nomer={dataGridView1.Rows[n].Cells["Номер"].Value}";
            Меню.Modification_Execute(sql);
            Меню.ds.Tables["Менеджер"].Rows.RemoveAt(n);
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
            n = -1;
        }

        
    }
}
