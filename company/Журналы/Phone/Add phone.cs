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
using ПЗ_06.Данные;
using ПЗ_07.Журналы.Location;

namespace ПЗ_07.Журналы.Phone
{
    public partial class Закрепление_телефонов : Form
    {
        public Закрепление_телефонов()
        {
            InitializeComponent();
        }

        private void Закрепление_телефонов_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Меню.ds.Tables["Мобильник"].Rows[Журнал_телефонов.n]["Номер"].ToString();
                comboBox1.Text = Меню.ds.Tables["Мобильник"].Rows[Журнал_телефонов.n]["Подразделение"].ToString();
                maskedTextBox1.Text = Меню.ds.Tables["Мобильник"].Rows[Журнал_телефонов.n]["Телефон"].ToString();
                dateTimePicker1.Text = Меню.ds.Tables["Мобильник"].Rows[Журнал_телефонов.n]["Дата"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Не указана редактируемая запись таблицы!!!", "Ошибка");
                this.Close(); return;
            }
            textBox1.Enabled = true;
        }

        private void Закрепление_телефонов_Activated(object sender, EventArgs e)
        {
            string sql = "select id,name as \"Название\" from subdivision";
            Меню.Table_Fill("Подразделение", sql);
            comboBox1.Items.Clear();
            for (int i = 0; i < Меню.ds.Tables["Подразделение"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Меню.ds.Tables["Подразделение"].Rows[i]["Название"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ДанныеПодразделение данныеПодразделение = new ДанныеПодразделение();
            данныеПодразделение.Show();
        }

        private void Закрепление_телефонов_FormClosed(object sender, FormClosedEventArgs e)
        {
            Журнал_телефонов.n = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kod = null;
            for (int i = 0; i < Меню.ds.Tables["Подразделение"].Rows.Count; i++)
            {
                if (Меню.ds.Tables["Подразделение"].Rows[i]["Название"].ToString() == comboBox1.Text)
                    kod = Меню.ds.Tables["Подразделение"].Rows[i]["id"].ToString();
            }
            string sql = $"UPDATE phone_pinning SET id_subdivision={kod},telephone='{maskedTextBox1.Text}',data='{dateTimePicker1.Text}' where nomer={textBox1.Text}";
            if (!Меню.Modification_Execute(sql))
                return;
            Меню.ds.Tables["Мобильник"].Rows[Журнал_телефонов.n].ItemArray = new object[] { textBox1.Text, comboBox1.Text, maskedTextBox1.Text, dateTimePicker1.Text };
            this.Close();
        }
    }
}
