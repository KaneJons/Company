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

namespace ПЗ_10
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT *FROM usser ORDER BY login";
            Меню.Table_Fill("Пользователь",sql);

            for (int i = 0; i < Меню.ds.Tables["Пользователь"].Rows.Count; i++)
                comboBox1.Items.Add(Меню.ds.Tables["Пользователь"].Rows[i]["login"]);
            textBox1.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (checkBox1.Checked)
            { 
                case true:textBox1.UseSystemPasswordChar = false;
                    break;
                default: textBox1.UseSystemPasswordChar = true;
                    break;            
            }    
        }
        public static string polzov = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Меню.ds.Tables["Пользователь"].Rows[comboBox1.SelectedIndex]["password"].ToString())
            {
                if (comboBox1.Text == "Менеджер")
                    polzov = "Администратор";
                Hide();
                Меню меню = new Меню(); меню.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильный пароль","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
