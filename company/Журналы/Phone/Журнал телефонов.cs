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

namespace ПЗ_07.Журналы.Phone
{
    public partial class Журнал_телефонов : Form
    {
        public Журнал_телефонов()
        {
            InitializeComponent();
        }

        private void Журнал_телефонов_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "select nomer as \"Номер\", subdivision.name as \"Подразделение\",telephone as \"Телефон\",data as \"Дата\" from phone_pinning left " +
                "join subdivision on subdivision.id = phone_pinning.id_subdivision;";
            Меню.Table_Fill("Мобильник", sql);

            dataGridView1.DataSource = Меню.ds.Tables["Мобильник"];
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Журнал_телефонов_Activated(object sender, EventArgs e)
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

            string sql = $"INSERT INTO phone_pinning (nomer) values({kod})";
            Меню.Modification_Execute(sql);

            Меню.ds.Tables["Мобильник"].Rows.Add(new object[] { kod, null, null, null });
            dataGridView1.CurrentCell = null;

            Закрепление_телефонов закрепление_Телефонов = new Закрепление_телефонов();
            закрепление_Телефонов.Show();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            n = dataGridView1.CurrentRow.Index;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Закрепление_телефонов закрепление_Телефонов = new Закрепление_телефонов();
            закрепление_Телефонов.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                msg = $"Вы точно хотите удалить телефон с номером {dataGridView1.Rows[n].Cells["Номер"].Value}?";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Не указана удаляемая запись таблицы!!!", "Ошибка");
            }
            string caption = "Удаление телефона";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, caption, buttons);
            if (result == DialogResult.No) { return; }

            string sql = $"DELETE FROM phone_pinning WHERE nomer={dataGridView1.Rows[n].Cells["Номер"].Value}";
            Меню.Modification_Execute(sql);
            Меню.ds.Tables["Мобильник"].Rows.RemoveAt(n);
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
            n = -1;
        }
    }
}
