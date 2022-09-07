using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПЗ_06.Запросы
{
    public partial class ЗапросыПодразделения : Form
    {
        public ЗапросыПодразделения()
        {
            InitializeComponent();
        }
        public string sql;
        private void ЗапросыПодразделения_Load(object sender, EventArgs e)
        {
            sql = "SELECT subdivision.id AS \"Код\", subdivision.name AS \"Название\", subdivision.short_name AS \"Краткое название\", enterprise.name AS \"Предприятие\"," +
                "subdivision.kind_of_activity AS \"Вид деятельности\", subdivision.email_address AS \"Электронный адрес\", subdivision.date_of_email_address AS \"Дата электронного адреса\"," +
                " phone_pinning.telephone as \"Телефон\", phone_pinning.data as \"Дата телефона\" " +
                "FROM ((subdivision left join enterprise on enterprise.id = subdivision.id_enterprise) left join phone_pinning on phone_pinning.id_subdivision = subdivision.id );";
            Меню.Table_Fill("ПоискПодразделений", sql);
           
            dataGridView1.DataSource = Меню.ds.Tables["ПоискПодразделений"];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = true;
            }
            dataGridView1.Columns["Код"].Visible = false;
            dataGridView1.Columns["Дата телефона"].Visible=false;
            dataGridView1.Columns["Телефон"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Enabled = false;
            dataGridView1.AutoResizeColumns();
        }
              
        private void radioButton1_Click(object sender, EventArgs e)
        {
            ЗапросыПодразделения_Load(sender,e);
            Меню.ds.Tables["ПоискПодразделений"].DefaultView.RowFilter = "";
            dataGridView1.CurrentCell = null;
            dataGridView1.AutoResizeColumns();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            sql = $"select count(id) as \"Количество подразделений\" from subdivision where date_of_email_address <>'{dateTimePicker2.Text}';";
            Меню.Table_Fill("Количество", sql);
            dataGridView1.DataSource = Меню.ds.Tables["Количество"];
            dataGridView1.CurrentCell = null;
            dataGridView1.AutoResizeColumns();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            ЗапросыПодразделения_Load(sender, e);
            
            Меню.ds.Tables["ПоискПодразделений"].DefaultView.RowFilter = $"[Дата телефона] = '{dateTimePicker1.Text}'";
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            dataGridView1.Columns["Название"].Visible = true;
            dataGridView1.Columns["Телефон"].Visible = true;
            dataGridView1.AutoResizeColumns();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            sql = $"select  subdivision.name as \"Название подразделения\" from  consolidation_of_the_head left join subdivision on subdivision.id = id_subdivision  group by subdivision.name" +
                $" having count(id_subdivision) = (select max(mycount) from (select id_subdivision, count(id_subdivision) as mycount " +
                $"from  consolidation_of_the_head where data between '{dateTimePicker3.Text}' and '{dateTimePicker4.Text}' group by id_subdivision ) as result )  limit 1;";
            Меню.Table_Fill("Максимально", sql);
            dataGridView1.DataSource = Меню.ds.Tables["Максимально"];
            dataGridView1.CurrentCell = null;
            dataGridView1.AutoResizeColumns();
        }
    }

     
}
