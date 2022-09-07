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

namespace ПЗ_07.Журналы.Location
{
    public partial class Закрепление_местоположения : Form
    {
        public Закрепление_местоположения()
        {
            InitializeComponent();
        }
        
        private void Закрепление_местоположения_Load(object sender, EventArgs e)
        {
            try 
            {
                textBox1.Text = Меню.ds.Tables["Локация"].Rows[Журнал_местоположений.n]["Номер"].ToString();
                comboBox1.Text = Меню.ds.Tables["Локация"].Rows[Журнал_местоположений.n]["Подразделение"].ToString();
                textBox2.Text = Меню.ds.Tables["Локация"].Rows[Журнал_местоположений.n]["Местоположение"].ToString();
                dateTimePicker1.Text = Меню.ds.Tables["Локация"].Rows[Журнал_местоположений.n]["Дата"].ToString();
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Не указана редактируемая запись таблицы!!!", "Ошибка");
                this.Close(); return;
            }
            textBox1.Enabled = true;
        }

       
        private void Закрепление_местоположения_Activated_1(object sender, EventArgs e)
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


        private void button1_Click_1(object sender, EventArgs e)
        {
            string kod = null;
            for(int i = 0; i < Меню.ds.Tables["Подразделение"].Rows.Count;i++)
            {
                if (Меню.ds.Tables["Подразделение"].Rows[i]["Название"].ToString() == comboBox1.Text)
                    kod = Меню.ds.Tables["Подразделение"].Rows[i]["id"].ToString();
            }
            string sql = $"UPDATE fixing_the_location SET id_subdivision={kod},location='{textBox2.Text}',data='{dateTimePicker1.Text}' where nomer={textBox1.Text}";
            if (!Меню.Modification_Execute(sql))
                return;
            Меню.ds.Tables["Локация"].Rows[Журнал_местоположений.n].ItemArray = new object[] { textBox1.Text, comboBox1.Text, textBox2.Text, dateTimePicker1.Text }; 
            this.Close();
        }

        private void Закрепление_местоположения_FormClosed(object sender, FormClosedEventArgs e)
        {
            Журнал_местоположений.n = -1;
        }
    }
}
