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
    public partial class ДанныеРуководитель : Form
    {
        public ДанныеРуководитель()
        {
            InitializeComponent();
        }
        int n;
        private void ДанныеРуководитель_Load(object sender, EventArgs e)
        {
            string sql = "SELECT id AS \"Код\", fio AS \"ФИО\", post AS \"Должность\" FROM manager;";
            Меню.Table_Fill("Руководитель", sql);

            if (Меню.ds.Tables["Руководитель"].Rows.Count > 0)
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
            textBox1.Text = Меню.ds.Tables["Руководитель"].Rows[n]["Код"].ToString();
            textBox2.Text = Меню.ds.Tables["Руководитель"].Rows[n]["ФИО"].ToString();
            textBox3.Text = Меню.ds.Tables["Руководитель"].Rows[n]["Должность"].ToString();
            textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (n < Меню.ds.Tables["Руководитель"].Rows.Count) n++;
            if (Меню.ds.Tables["Руководитель"].Rows.Count > n)
                FieldsForm_Fill();
            else
                FieldsForm_Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            n = Меню.ds.Tables["Руководитель"].Rows.Count;
            FieldsForm_Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Меню.ds.Tables["Руководитель"].Rows.Count > 0)
            {
                n = 0;
                FieldsForm_Fill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql;
            if (n == Меню.ds.Tables["Руководитель"].Rows.Count)
            {


                sql = $"INSERT INTO manager(id, fio, post) values ({textBox1.Text},'{textBox2.Text}','{textBox3.Text}');";

                if (!Меню.Modification_Execute(sql))
                    return;
                textBox1.Enabled = false;

                Меню.ds.Tables["Руководитель"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text });
            }
            else
            {
                sql = $"UPDATE manager SET fio='{textBox2.Text}', post='{textBox3.Text}' WHERE id={textBox1.Text}";
                if (!Меню.Modification_Execute(sql))
                    return;
                Меню.ds.Tables["Руководитель"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox3.Text };
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = $"Вы точно хотите удалить из справочника руководителя с кодом {textBox1.Text}?";
            string caption = "Удаление руководителя";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No)
            {
                return;
            }
            string sql = $"DELETE FROM manager WHERE id={textBox1.Text}";

            Меню.Modification_Execute(sql);
            try
            {
                Меню.ds.Tables["Руководитель"].Rows.RemoveAt(n);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнено из-за указания несуществующего экземпляра!!!", "Ошибка");
                return;
            }
            if (Меню.ds.Tables["Руководитель"].Rows.Count > n)
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
