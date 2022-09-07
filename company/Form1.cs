using Npgsql;
using System.Data;
using ПЗ_06.Журналы;
using ПЗ_10;

namespace ПЗ_06
{
    public partial class Меню : Form
    {
        const string БазДанная= "Server=localhost;User Id=postgres;" +
            "Password=Devilmaycry135790;Database=EnterpriseDirectory;"; 
        public Меню()
        {
            InitializeComponent();
        }

        public static  NpgsqlConnection connection = new NpgsqlConnection(БазДанная);

        public static DataSet ds = new DataSet();

        public static void Table_Fill(string name, string sql)
        {
            if (ds.Tables[name]!=null)
                ds.Tables[name].Clear();
            NpgsqlDataAdapter dat;
            dat = new NpgsqlDataAdapter(sql, connection);
            dat.Fill(ds, name);
            connection.Close(); 
        }
        public static bool Modification_Execute(string sql)
        {
            NpgsqlCommand com;
            com = new NpgsqlCommand(sql,connection);
            connection.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch(NpgsqlException ex)
            {
                MessageBox.Show("Обновление базы данных не было выполнено из-за не указания обновляемых данных"+
                    $" или несоответствия их типов!!! {ex}","Ошибка");
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }
        private void предприятиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Данные.ДанныеПредприятие предприятие = new Данные.ДанныеПредприятие();
            предприятие.Show();
        }

        private void подразделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Данные.ДанныеПодразделение подразделение = new Данные.ДанныеПодразделение();
            подразделение.Show();
        }

        private void руководительToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Данные.ДанныеРуководитель wasd = new Данные.ДанныеРуководитель();
            wasd.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Справка.AboutBox1 aboutBox = new Справка.AboutBox1();
            aboutBox.Show();
        }

        private void настройкаПаролейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Справка.Настройка_паролей настройка = new Справка.Настройка_паролей();
            настройка.Show();
        }

        private void подразделениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Запросы.ЗапросыПодразделения запросыПодразделения = new Запросы.ЗапросыПодразделения();
            запросыПодразделения.Show();
        }

        private void закреплениеМестоположенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ПЗ_07.Журналы.Location.Журнал_местоположений Журнал_местоположений = new ПЗ_07.Журналы.Location.Журнал_местоположений();
            Журнал_местоположений.Show();
            
        }

        private void закреплениеТелефоновToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ПЗ_07.Журналы.Phone.Журнал_телефонов журнал_Телефонов = new ПЗ_07.Журналы.Phone.Журнал_телефонов();
            журнал_Телефонов.Show();

        }

        private void закреплениеРуководителяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ПЗ_07.Журналы.Director.Журнал_руководителей журнал_Руководителей = new ПЗ_07.Журналы.Director.Журнал_руководителей();
            журнал_Руководителей.Show();

        }

        private void Меню_Load(object sender, EventArgs e)
        {
            if(Авторизация.polzov != "Администратор")
            {
                предприятиеToolStripMenuItem.Enabled = false;
                подразделениеToolStripMenuItem.Enabled=false;
                руководительToolStripMenuItem.Enabled=false;
                настройкаПаролейToolStripMenuItem.Enabled = false;
                подразделениеToolStripMenuItem1.Enabled=false;
            }    
        }
    }
}