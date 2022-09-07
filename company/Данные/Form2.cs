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
    public partial class ДанныеПодразделение : Form
    {
        public ДанныеПодразделение()
        {
            InitializeComponent();
        }
        int n;
        private void ДанныеПодразделение_Load(object sender, EventArgs e)
        {
            string sql = "SELECT id AS \"Код\", name AS \"Название\", short_name AS \"Краткое название\" FROM enterprise;";
            Меню.Table_Fill("Предприятие",sql);

            for(int i=0; i < Меню.ds.Tables["Предприятие"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Меню.ds.Tables["Предприятие"].Rows[i]["Название"]);
            }
            comboBox1.Sorted = true;

            sql = "SELECT subdivision.id AS \"Код\", subdivision.name AS \"Название\", subdivision.short_name AS \"Краткое название\", enterprise.name AS \"Предприятие\"," +
                " subdivision.kind_of_activity AS \"Вид деятельности\", subdivision.email_address AS \"Электронный адрес\", subdivision.date_of_email_address AS \"Дата электронного адреса\" " +
                "FROM subdivision left join enterprise on enterprise.id = subdivision.id_enterprise order by subdivision.id;";
            Меню.Table_Fill("Подразделение", sql);

            for (int i = 0; i < Меню.ds.Tables["Подразделение"].Rows.Count; i++)
            {
                comboBox2.Items.Add(Меню.ds.Tables["Подразделение"].Rows[i]["Вид деятельности"]);
            }
            comboBox2.Sorted = true;
            if (Меню.ds.Tables["Подразделение"].Rows.Count > 0)
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox4.Text="0";
            dateTimePicker1.Value = DateTime.Now;            
            textBox1.Enabled = true;
            textBox1.Focus();
        }
        private void FieldsForm_Fill()
        {
            textBox1.Text = Меню.ds.Tables["Подразделение"].Rows[n]["Код"].ToString();
            textBox2.Text = Меню.ds.Tables["Подразделение"].Rows[n]["Название"].ToString();
            textBox3.Text = Меню.ds.Tables["Подразделение"].Rows[n]["Краткое название"].ToString();
            comboBox1.Text = Меню.ds.Tables["Подразделение"].Rows[n]["Предприятие"].ToString();
            comboBox2.Text = Меню.ds.Tables["Подразделение"].Rows[n]["Вид деятельности"].ToString();
            textBox4.Text = Меню.ds.Tables["Подразделение"].Rows[n]["Краткое название"].ToString();
            dateTimePicker1.Text = Меню.ds.Tables["Подразделение"].Rows[n]["Дата электронного адреса"].ToString();
            textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (n < Меню.ds.Tables["Подразделение"].Rows.Count) n++;
            if (Меню.ds.Tables["Подразделение"].Rows.Count > n)
                FieldsForm_Fill();
            else
                FieldsForm_Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            n = Меню.ds.Tables["Подразделение"].Rows.Count;
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
            if (Меню.ds.Tables["Подразделение"].Rows.Count > 0)
            {
                n = 0;
                FieldsForm_Fill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                string kod = null;
                for(int i = 0; i < Меню.ds.Tables["Предприятие"].Rows.Count; i++)
                {
                    if (Меню.ds.Tables["Предприятие"].Rows[i]["Название"].ToString() == comboBox1.Text)
                        kod = Меню.ds.Tables["Предприятие"].Rows[i]["Код"].ToString();
                }

            string sql;
            if (n == Меню.ds.Tables["Подразделение"].Rows.Count)
            {
                

                sql = $"INSERT INTO subdivision(id, name, short_name, id_enterprise, kind_of_activity,email_address, date_of_email_address) " +
                    $"values ({textBox1.Text},'{textBox2.Text}','{textBox3.Text}',{kod},'{comboBox2.Text}','{textBox4.Text}','{dateTimePicker1.Text}');";

                if (Меню.Modification_Execute(sql))
                    return;
                textBox1.Enabled = false;

                Меню.ds.Tables["Подразделение"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text, kod, comboBox2.Text, textBox4.Text, dateTimePicker1.Text});
            }
            else
            {
                sql = $"UPDATE subdivision SET " +
                    $"name='{textBox2.Text}', short_name='{textBox3.Text}',id_enterprise={kod}, kind_of_activity='{comboBox2.Text}', " +
                    $"email_address='{textBox4.Text}', date_of_email_address='{dateTimePicker1.Text}' WHERE id={textBox1.Text}";
                if (!Меню.Modification_Execute(sql))
                    return;
                Меню.ds.Tables["Подразделение"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox3.Text, kod, comboBox2.Text, textBox4.Text, dateTimePicker1.Text};
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = $"Вы точно хотите удалить из справочника подразделение с кодом {textBox1.Text}?";
            string caption = "Удаление подразделения";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.No)
            {
                return;
            }
            string sql = $"DELETE FROM subdivision WHERE id={textBox1.Text}";

            Меню.Modification_Execute(sql);
            try
            {
                Меню.ds.Tables["Подразделение"].Rows.RemoveAt(n);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Удаление не было выполнено из-за указания несуществующего экземпляра!!!", "Ошибка");
                return;
            }
            if (Меню.ds.Tables["Подразделение"].Rows.Count > n)
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
