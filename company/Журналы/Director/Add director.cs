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

namespace ПЗ_07.Журналы.Director
{
    public partial class Закрепление_руководителя : Form
    {
        public Закрепление_руководителя()
        {
            InitializeComponent();
        }

        private void Закрепление_руководителя_Load(object sender, EventArgs e)
        {

            try
            {
                textBox1.Text = Меню.ds.Tables["Менеджер"].Rows[Журнал_руководителей.n]["Номер"].ToString();
                comboBox1.Text = Меню.ds.Tables["Менеджер"].Rows[Журнал_руководителей.n]["Подразделение"].ToString();
                comboBox2.Text = Меню.ds.Tables["Менеджер"].Rows[Журнал_руководителей.n]["Руководитель"].ToString();
                dateTimePicker1.Text = Меню.ds.Tables["Менеджер"].Rows[Журнал_руководителей.n]["Дата"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Не указана редактируемая запись таблицы!!!", "Ошибка");
                this.Close(); return;
            }
            textBox1.Enabled = false;
        }

        private void Закрепление_руководителя_Activated(object sender, EventArgs e)
        {
            string sql;
            sql="select id,name as \"Название\" from subdivision";
            Меню.Table_Fill("Подразделение", sql);
            comboBox1.Items.Clear();
            for (int i = 0; i < Меню.ds.Tables["Подразделение"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Меню.ds.Tables["Подразделение"].Rows[i]["Название"].ToString());
            }

            sql = "select id,fio as \"ФИО\" from manager";
            Меню.Table_Fill("Руководитель", sql);
            comboBox2.Items.Clear();
            for (int i = 0; i < Меню.ds.Tables["Руководитель"].Rows.Count; i++)
            {
                comboBox2.Items.Add(Меню.ds.Tables["Руководитель"].Rows[i]["ФИО"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ДанныеПодразделение данныеПодразделение = new ДанныеПодразделение();
            данныеПодразделение.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ДанныеРуководитель данныеРуководитель = new ДанныеРуководитель();
            данныеРуководитель.Show();
        }

        private void Закрепление_руководителя_FormClosed(object sender, FormClosedEventArgs e)
        {
            Журнал_руководителей.n = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kod1 = null, kod2 = null;
            for (int i = 0; i < Меню.ds.Tables["Подразделение"].Rows.Count; i++)
            {
                if (Меню.ds.Tables["Подразделение"].Rows[i]["Название"].ToString() == comboBox1.Text)
                    kod1 = Меню.ds.Tables["Подразделение"].Rows[i]["id"].ToString();
            }
            for (int i = 0; i < Меню.ds.Tables["Руководитель"].Rows.Count; i++)
            {
                if (Меню.ds.Tables["Руководитель"].Rows[i]["ФИО"].ToString() == comboBox2.Text)
                    kod2 = Меню.ds.Tables["Руководитель"].Rows[i]["id"].ToString();
            }
            string sql = $"UPDATE consolidation_of_the_head SET id_subdivision={kod1},id_manager={kod2},data='{dateTimePicker1.Text}' where nomer={textBox1.Text}";
            if (!Меню.Modification_Execute(sql))
                return;
            Меню.ds.Tables["Менеджер"].Rows[Журнал_руководителей.n].ItemArray = new object[] { textBox1.Text, comboBox1.Text, comboBox2.Text, dateTimePicker1.Text };
            this.Close();
        }
    }
}
