using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПЗ_06.Справка
{
    public partial class Настройка_паролей : Form
    {
        public Настройка_паролей()
        {
            InitializeComponent();
        }

        private void Настройка_паролей_Load(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT *FROM usser ORDER BY login";

            Меню.Table_Fill("Пользователь", sql);

            for(int i = 0; i < Меню.ds.Tables["Пользователь"].Rows.Count; i++)
            {
                comboBox1.Items.Add(Меню.ds.Tables["Пользователь"].Rows[i]["login"]);
            }
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(textBox1.Text==textBox2.Text)
            {
                case true:string sql = $"UPDATE usser SET password = '{textBox1.Text}' WHERE login ='{comboBox1.Text}'";
                    Меню.Modification_Execute(sql);
                    Close();
                    break;
                default:
                    MessageBox.Show("Неверное подтверждение пароля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
