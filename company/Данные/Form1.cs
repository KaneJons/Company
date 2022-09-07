using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПЗ_06.Данные
{
    public partial class ДанныеПредприятие : Form
    {
        public ДанныеПредприятие()
        {
            InitializeComponent();
        }

        int n;
        private void ДанныеПредприятие_Load(object sender, EventArgs e)
        {
            string sql = "SELECT id AS \"Код\", name AS \"Название\", short_name AS \"Краткое название\" FROM enterprise;";
            Меню.Table_Fill("Предприятие", sql);

            if (Меню.ds.Tables["Предприятие"].Rows.Count>0)
            {
                n = 0;
                FieldsForm_Fill();
            }
        }
        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox1.Enabled = true;
            textBox1.Focus();
        }
        private void FieldsForm_Fill()
        {
            textBox1.Text = Меню.ds.Tables["Предприятие"].Rows[n]["Код"].ToString();
            textBox2.Text = Меню.ds.Tables["Предприятие"].Rows[n]["Название"].ToString();
            textBox3.Text = Меню.ds.Tables["Предприятие"].Rows[n]["Краткое название"].ToString();
            textBox1.Enabled = false;       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (n < Меню.ds.Tables["Предприятие"].Rows.Count) n++;
            if (Меню.ds.Tables["Предприятие"].Rows.Count > n)
                FieldsForm_Fill();
            else
                FieldsForm_Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            n = Меню.ds.Tables["Предприятие"].Rows.Count;
            FieldsForm_Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(n>0)
            {
                n--; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Меню.ds.Tables["Предприятие"].Rows.Count>0)
            {
                n = 0;
                FieldsForm_Fill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string sql;
            if (n == Меню.ds.Tables["Предприятие"].Rows.Count)
            {

            
            sql = $"INSERT INTO enterprise(id, name, short_name) values ({textBox1.Text},'{textBox2.Text}','{textBox3.Text}');";

            if (!Меню.Modification_Execute(sql))
                return;
            textBox1.Enabled = false;

            Меню.ds.Tables["Предприятие"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text });
            }
            else
            {
                sql = $"UPDATE enterprise SET name='{textBox2.Text}', short_name='{textBox3.Text}' WHERE id={textBox1.Text}";
                if (!Меню.Modification_Execute(sql))
                    return;
                Меню.ds.Tables["Предприятие"].Rows[n].ItemArray = new object[] {textBox1.Text, textBox2.Text, textBox3.Text };
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = $"Вы точно хотите удалить из справочника предприятие с кодом {textBox1.Text}?";
            string caption = "Удаление предприятия";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if(result == DialogResult.No)
            {
                return;
            }
            string sql = $"DELETE FROM enterprise WHERE id={textBox1.Text}";

            Меню.Modification_Execute(sql);
            try
            {
                Меню.ds.Tables["Предприятие"].Rows.RemoveAt(n);
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнено из-за указания несуществующего экземпляра!!!", "Ошибка");
                return;
            }
            if (Меню.ds.Tables["Предприятие"].Rows.Count>n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }
    }
}
