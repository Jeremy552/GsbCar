using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GSB
{
    public partial class Login : Form
    {

        String myConnectionString = "server=192.168.56.101;uid=root;" + "pwd=root;database=GSB_Csharp;";
        // ! A modifier sur FoRM1_.CS pour la connexion au programme !
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            List<int> rlist = new List<int>();
            string pseudo = utilisateur.Text;
            string mdpasse = mdp.Text;

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = this.myConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
           

            String myInsertQuery = "SELECT * FROM Utilisateur WHERE pseudo = @pseudo AND mdp = @mdp ;";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
            myCommand.Parameters.AddWithValue("@pseudo", pseudo);
            myCommand.Parameters.AddWithValue("@mdp", mdpasse);
            myCommand.Connection = conn;
            conn.Open();
            MySqlDataReader reader = myCommand.ExecuteReader();


            while (reader.Read())
            {
                rlist.Add(0);
            }

            if (rlist.Count == 0)
            {
                MessageBox.Show("Mot de passe ou pseudo incorrect.");
            }
            else
            {
                this.Hide();
                Form1 mainform = new Form1();
                mainform.ShowDialog(); 
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
