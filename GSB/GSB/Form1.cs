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
    public partial class Form1 : Form
    {
        List<VoitureThermique> listVoitureThermique = new List<VoitureThermique>();
        List<VoitureElectrique> listVoitureElectrique = new List<VoitureElectrique>();
        List<Entretien> listEntretien = new List<Entretien>();
        int indiceIdThermique;
        int indiceIdElectrique;
        int indiceEntretien;

        //Info de connexion a la base de données :
        String myConnectionString = "server=192.168.56.101;uid=root;" +  "pwd=root;database=GSB_Csharp;";
        // ! A modifier sur LOGIN.CS pour la connexion au programme !


        

        public Form1()
        {
            InitializeComponent();
            electriqueradio.Checked = true;
            

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ActualisationDgvThermique(); // Charge les voitures depuis la bdd
            ActualisationDgvElectrique();
            ActualisationDgvEntretien();
            radioEntretienT.Checked = true;
            
        }

        
        #region Formulaire et ajouts dans la base de voitures thermiques.

        //Ajouter une voiture thermique dans la base de donnée avec un formulaire.
        private void validerThermique_Click(object sender, EventArgs e)
        {
            try
            {
              

                string immatriculationT = immatriculation.Text; // Condition qui change la Textbox de immatriculation si l'input est vide.
                if (immatriculationT == "")
                {
                    immatriculation.BackColor = Color.Red;
                }
                else
                {
                    immatriculation.BackColor = Color.White;
                }

                string marqueT = marque.Text;
                if(marqueT == "")  // Condition qui change la Textbox de marque si l'input est vide.
                {
                    marque.BackColor = Color.Red;
                }
                else
                {
                    marque.BackColor = Color.White;
                }
                string modeleT = modele.Text;
                if (modeleT == "")  // Condition qui change la Textbox de modele si l'input est vide.
                {
                    modele.BackColor = Color.Red;
                }
                else
                {
                    modele.BackColor = Color.White;
                }

                string puissanceFiscaleT = puissanceFiscale.Text;
                string typeCarburantT = typeCarburant.Text;

                if (typeCarburantT == "") // Condition qui change la Textbox de typeCarburant si l'input est vide.
                {
                    typeCarburant.BackColor = Color.Red;
                }
                else
                {
                    typeCarburant.BackColor = Color.White;
                }

                int kilometrageT; // Condition qui change la Textbox de kilometrage si l'input n'est pas un int.
                bool res = int.TryParse(kilometrage.Text, out kilometrageT);
                if (res == false)
                {
                    kilometrage.BackColor = Color.Red;
                }
                else
                {
                    kilometrage.BackColor = Color.White;
                }

                string dateImmatriculationT = dateImmatriculation.Text;

                string dateAchatT = dateAchat.Text;

                double prixAchatT; 
                double.TryParse(prixAchat.Text, out prixAchatT);
            

                double loyerMensuelT; 
                double.TryParse(loyerMensuel.Text, out loyerMensuelT);
               

                int capaciteReservoirT; // Condition qui change la Textbox de capaciteRes si l'input n'est pas un int.
                bool res3 = int.TryParse(capaciteReservoir.Text, out capaciteReservoirT);
                if (res3 == false)
                {
                    capaciteReservoir.BackColor = Color.Red;
                }
                else
                {
                    capaciteReservoir.BackColor = Color.White;
                }

                int consommationMoyT; // Condition qui change la Textbox de capaciteRes si l'input n'est pas un int.
                int.TryParse(consommationMoy.Text, out consommationMoyT);
                

                if (kilometrage.BackColor != Color.Red && immatriculation.BackColor != Color.Red && typeCarburant.BackColor != Color.Red && marque.BackColor !=Color.Red && modele.BackColor != Color.Red )
                {
                    MySql.Data.MySqlClient.MySqlConnection conn;
                    string myConnectionString;
                    myConnectionString = this.myConnectionString;
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                    String myInsertQuery = @"insert into VehiculeThermique (`immatriculation`,`marque`,`modele`,`puissanceFiscale`
                                    ,`kilometrage`,`dateImmatriculation`,`dateAchat`,`prixAchat`,`loyerMensuel`
                                    ,`capaciteReservoir`,`consommationMoy`,`typeCarburant`) 
                                    VALUES (@immatriculation,@marque,@modele,@puissanceFiscale
                                    ,@kilometrage,@dateImmatriculation,@dateAchat,@prixAchat,@loyerMensuel
                                    ,@capaciteReservoir,@consommationMoy,@typeCarburant);";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Parameters.AddWithValue("@immatriculation", immatriculationT);
                    myCommand.Parameters.AddWithValue("@marque", marqueT);
                    myCommand.Parameters.AddWithValue("@modele", modeleT);
                    myCommand.Parameters.AddWithValue("@puissanceFiscale", puissanceFiscaleT);
                    myCommand.Parameters.AddWithValue("@kilometrage", kilometrageT);
                    myCommand.Parameters.AddWithValue("@dateImmatriculation", dateImmatriculationT);
                    myCommand.Parameters.AddWithValue("@dateAchat", dateAchatT);
                    myCommand.Parameters.AddWithValue("@prixAchat", prixAchatT);
                    myCommand.Parameters.AddWithValue("@loyerMensuel", loyerMensuelT);
                    myCommand.Parameters.AddWithValue("@capaciteReservoir", capaciteReservoirT);
                    myCommand.Parameters.AddWithValue("@consommationMoy", consommationMoyT);
                    myCommand.Parameters.AddWithValue("@typeCarburant", typeCarburantT);
                    myCommand.Connection = conn;
                    myCommand.ExecuteNonQuery();

                    immatriculation.Clear();
                    marque.Clear();
                    modele.Clear();
                    puissanceFiscale.Clear();
                    kilometrage.Clear();
                    prixAchat.Clear();
                    loyerMensuel.Clear();
                    capaciteReservoir.Clear();
                    consommationMoy.Clear();
                    typeCarburant.Clear();

                    MessageBox.Show("Voiture Ajoutée à la base de donnée.");

                    //Actualisation du DGV 
                    ActualisationDgvThermique();
                    //Actualisation ComboBox
                    radioEntretienE.Checked = true;
                    radioEntretienT.Checked = true;
                    
                }
                else
                {
                   MessageBox.Show("Veuillez remplir les champs obligatoires");
                }

            }
            catch (Exception ) // Ne crash pas le programme si une textbox est mal remplit
            {

            }
        }

        #endregion

        #region Formulaire et ajouts dans la base de voitures Electrique

        //Ajouter une voiture electrique dans la base de donnée avec un formulaire.
        private void validerElectrique_Click(object sender, EventArgs e)
        {
            try
            {
                string immatriculationE = immatriculation1.Text;
                if (immatriculationE == "")
                {
                    immatriculation1.BackColor = Color.Red;
                }
                else
                {
                    immatriculation1.BackColor = Color.White;
                }

                string marqueE = marque1.Text;
                if (marqueE == "")
                {
                    marque1.BackColor = Color.Red;
                }
                else
                {
                    marque1.BackColor = Color.White;
                }
                string modeleE = modele1.Text;
                if (modeleE == "")
                {
                    modele1.BackColor = Color.Red;
                }
                else
                {
                    modele1.BackColor = Color.White;
                }

                string puissanceFiscaleE = puissanceFiscale1.Text;
                string tempsDeCharge = tempsCharge.Text;

                if (tempsDeCharge == "")
                {
                    tempsCharge.BackColor = Color.Red;
                }
                else
                {
                    tempsCharge.BackColor = Color.White;
                }

                int kilometrageE;
                bool res = int.TryParse(kilometrage1.Text, out kilometrageE);
                if (res == false)
                {
                    kilometrage1.BackColor = Color.Red;
                }
                else
                {
                    kilometrage1.BackColor = Color.White;
                }

                string dateImmatriculationE = dateImmatriculation1.Text;

                string dateAchatE = dateAchat1.Text;

                double prixAchatE;
                double.TryParse(prixAchat1.Text, out prixAchatE);


                double loyerMensuelE;
                double.TryParse(loyerMensuel1.Text, out loyerMensuelE);


                int autonomieKmE;
                bool res3 = int.TryParse(autonomieKm.Text, out autonomieKmE);
                if (res3 == false)
                {
                    autonomieKm.BackColor = Color.Red;
                }
                else
                {
                    autonomieKm.BackColor = Color.White;
                }


                if (kilometrage1.BackColor != Color.Red && immatriculation1.BackColor != Color.Red && autonomieKm.BackColor != Color.Red && marque1.BackColor != Color.Red && modele1.BackColor != Color.Red)
                {
                    MySql.Data.MySqlClient.MySqlConnection conn;
                    string myConnectionString;
                    myConnectionString = this.myConnectionString;
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                    String myInsertQuery = @"insert into VehiculeElectrique (`immatriculation`,`marque`,`modele`,`puissanceFiscale`
                                    ,`kilometrage`,`dateImmatriculation`,`dateAchat`,`prixAchat`,`loyerMensuel`
                                    ,`tempsDeCharge`,`autonomieEnKm`) 
                                    VALUES (@immatriculation,@marque,@modele,@puissanceFiscale
                                    ,@kilometrage,@dateImmatriculation,@dateAchat,@prixAchat,@loyerMensuel
                                    ,@tempsDeCharge,@autonomieEnKm);";
                    MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Parameters.AddWithValue("@immatriculation", immatriculationE);
                    myCommand.Parameters.AddWithValue("@marque", marqueE);
                    myCommand.Parameters.AddWithValue("@modele", modeleE);
                    myCommand.Parameters.AddWithValue("@puissanceFiscale", puissanceFiscaleE);
                    myCommand.Parameters.AddWithValue("@kilometrage", kilometrageE);
                    myCommand.Parameters.AddWithValue("@dateImmatriculation", dateImmatriculationE);
                    myCommand.Parameters.AddWithValue("@dateAchat", dateAchatE);
                    myCommand.Parameters.AddWithValue("@prixAchat", prixAchatE);
                    myCommand.Parameters.AddWithValue("@loyerMensuel", loyerMensuelE);
                    myCommand.Parameters.AddWithValue("@tempsDeCharge", tempsDeCharge);
                    myCommand.Parameters.AddWithValue("@autonomieEnKm", autonomieKmE);
                    myCommand.Connection = conn;
                    myCommand.ExecuteNonQuery();

                    immatriculation1.Clear();
                    marque1.Clear();
                    modele1.Clear();
                    puissanceFiscale1.Clear();
                    kilometrage1.Clear();
                    prixAchat1.Clear();
                    loyerMensuel1.Clear();
                    tempsCharge.Clear();
                    tempsCharge.Clear();

                    MessageBox.Show("Voiture Ajoutée à la base de donnée.");

                    //Actualisation du DGV 
                    ActualisationDgvElectrique();
                    //Actualisation ComboBox
                    radioEntretienT.Checked = true;
                    radioEntretienE.Checked = true;


                }
                else
                {
                    MessageBox.Show("Veuillez remplir les champs obligatoires");
                }

            }
            catch (Exception) // Ne crash pas le programme si une textbox est mal remplit
            {

            }
        }

        #endregion

        #region Création d'objets a partir de la bdd ( voitures thermiques)
        private List<VoitureThermique> RecuperationThermique()
        {
            List<VoitureThermique> listVoitureThermique = new List<VoitureThermique>();
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn;
                string myConnectionString;
                myConnectionString = this.myConnectionString;
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                String selectquery = "SELECT * FROM VehiculeThermique;";
                MySqlCommand myCommand = new MySqlCommand(selectquery);
                conn.Open();
                myCommand.Connection = conn;
                MySqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    VoitureThermique vt = new VoitureThermique();
                    vt.IdThermique = Convert.ToInt32(reader["idthermique"]);
                    vt.Immatriculation = reader["immatriculation"].ToString();
                    vt.Marque = reader["marque"].ToString();
                    vt.Modele = reader["modele"].ToString();
                    vt.PuissanceFiscale = reader["puissanceFiscale"].ToString();
                    vt.Kilometrage = Convert.ToInt32(reader["kilometrage"]);
                    vt.DateImmatriculation = reader["dateImmatriculation"].ToString();
                    vt.DateAchat = reader["dateAchat"].ToString();
                    vt.PrixAchat = Convert.ToDouble(reader["prixAchat"]);
                    vt.LoyerMensuel = Convert.ToDouble(reader["loyerMensuel"]);
                    vt.CapaciteReservoir = Convert.ToInt32(reader["capaciteReservoir"]);
                    vt.ConsommationMoy = Convert.ToInt32(reader["consommationMoy"]);
                    vt.TypeCarburant = reader["typecarburant"].ToString();

                    listVoitureThermique.Add(vt);
                }

                return listVoitureThermique;

            }
            catch (Exception)
            {
                throw;

            }
           

        
        }
        #endregion

        #region Création d'objets a partir de la bdd ( voitures Electriques)
        private List<VoitureElectrique> RecuperationElectrique()
        {
            List<VoitureElectrique> listVoitureElectrique = new List<VoitureElectrique>();
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn;
                string myConnectionString;
                myConnectionString = this.myConnectionString;
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                String selectquery = "SELECT * FROM VehiculeElectrique;";
                MySqlCommand myCommand = new MySqlCommand(selectquery);
                conn.Open();
                myCommand.Connection = conn;
                MySqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    VoitureElectrique vt = new VoitureElectrique();
                    vt.Idelectrique = Convert.ToInt32(reader["idelectrique"]);
                    vt.Immatriculation = reader["immatriculation"].ToString();
                    vt.Marque = reader["marque"].ToString();
                    vt.Modele = reader["modele"].ToString();
                    vt.PuissanceFiscale = reader["puissanceFiscale"].ToString();
                    vt.Kilometrage = Convert.ToInt32(reader["kilometrage"]);
                    vt.DateImmatriculation = reader["dateImmatriculation"].ToString();
                    vt.DateAchat = reader["dateAchat"].ToString();
                    vt.PrixAchat = Convert.ToDouble(reader["prixAchat"]);
                    vt.LoyerMensuel = Convert.ToDouble(reader["loyerMensuel"]);
                    vt.TempsCharge = reader["tempsDeCharge"].ToString();
                    vt.AutonomieKm = reader["autonomieEnKm"].ToString();


                    listVoitureElectrique.Add(vt);
                }

                return listVoitureElectrique;

            }
            catch (Exception)
            {
                throw;

            }



        }
        #endregion

        #region Afficher/Cacher les formulaires

        private void electriqueradio_Click(object sender, EventArgs e)
        {
            if (electriqueradio.Checked == true)
            {

                formElectrique.Show();
            }

        }
        private void thermiqueradio_Click(object sender, EventArgs e)
        {
            if (thermiqueradio.Checked == true)
            {
                formThermique.Show();
                formElectrique.Hide();
            }

        }


        #endregion

        #region Suppression des voitures et entretiens

        private void dgvthermique_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvthermique.Rows[e.ColumnIndex].Cells[4].Value != null && e.ColumnIndex == 0)
                {
                    //Récupération de l'id pour supprimer dans la bdd.
                    this.indiceIdThermique = Convert.ToInt32(dgvthermique.Rows[e.RowIndex].Cells[4].Value);
                    //Connexion 
                    MySql.Data.MySqlClient.MySqlConnection conn;
                    string myConnectionString;
                    myConnectionString = this.myConnectionString;
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                    //Requete de suppression.
                    String myDeleteQuery = "DELETE FROM VehiculeThermique WHERE idthermique = @idthermique ;";
                    MySqlCommand myCommand = new MySqlCommand(myDeleteQuery);
                    myCommand.Parameters.AddWithValue("@idthermique", indiceIdThermique);
                    myCommand.Connection = conn;
                    myCommand.ExecuteNonQuery();
                    //Actualisation du DGV 
                    ActualisationDgvThermique();
                    //Actualisation ComboBox
                    radioEntretienE.Checked = true;
                    radioEntretienT.Checked = true;
                }


            }
            catch (Exception)
            {

            }


        }

        private void dgvElectrique_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvElectrique.Rows[e.ColumnIndex].Cells[3].Value != null && e.ColumnIndex == 0)
                {
                    //Récupération de l'id pour supprimer dans la bdd.
                    this.indiceIdElectrique = Convert.ToInt32(dgvElectrique.Rows[e.RowIndex].Cells[3].Value);
                    //Connexion 
                    MySql.Data.MySqlClient.MySqlConnection conn;
                    string myConnectionString;
                    myConnectionString = this.myConnectionString;
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                    //Requete de suppression.
                    String myDeleteQuery = "DELETE FROM VehiculeElectrique WHERE idelectrique = @idelectrique ;";
                    MySqlCommand myCommand = new MySqlCommand(myDeleteQuery);
                    myCommand.Parameters.AddWithValue("@idelectrique", indiceIdElectrique);
                    myCommand.Connection = conn;
                    myCommand.ExecuteNonQuery();
                    //Actualisation du DGV 
                    ActualisationDgvElectrique();
                    //Actualisation ComboBox
                    radioEntretienT.Checked = true;
                    radioEntretienE.Checked = true;
                    
                }
            }
            catch (Exception)
            {

            }

        }

        private void dgvEntretien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvEntretien.Rows[e.ColumnIndex].Cells[3].Value != null && e.ColumnIndex == 0)
                {
                    //Récupération de l'id pour supprimer dans la bdd.
                    this.indiceEntretien = Convert.ToInt32(dgvEntretien.Rows[e.RowIndex].Cells[6].Value);
                    //Connexion 
                    MySql.Data.MySqlClient.MySqlConnection conn;
                    string myConnectionString;
                    myConnectionString = this.myConnectionString;
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();
                    //Requete de suppression.
                    String myDeleteQuery = "DELETE FROM Entretien WHERE identretien = @identretien ;";
                    MySqlCommand myCommand = new MySqlCommand(myDeleteQuery);
                    myCommand.Parameters.AddWithValue("@identretien", indiceEntretien);
                    myCommand.Connection = conn;
                    myCommand.ExecuteNonQuery();
                    //Actualisation du DGV 
                    ActualisationDgvEntretien();
                }
            }
            catch (Exception)
            {

            }

        }



        #endregion

        #region Actualisation des DGVs .
        public void ActualisationDgvThermique()
        {
            //Actualisation du DGV 
            this.listVoitureThermique = RecuperationThermique(); // Charge les voitures depuis la bdd
                                                                 // Pour remettre à jour la liste, on efface ses colonnes
            dgvthermique.Columns.Clear();
            // on lui indique la source de données à afficher
            dgvthermique.DataSource = typeof(List<VoitureThermique>);
            dgvthermique.DataSource = this.listVoitureThermique;
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Supprimer";
            btnColumn.Text = "Supprimer";
            btnColumn.UseColumnTextForButtonValue = true;
            // on insère le bouton en position 0 des colonnes
            dgvthermique.Columns.Insert(0, btnColumn);
            dgvthermique.AutoResizeColumns();
            // on actualise l'affichage pour prendre acte des modifications effectuées
            dgvthermique.Refresh();
        }

        public void ActualisationDgvEntretien()
        {
            //Actualisation du DGV 
            this.listEntretien = RecuperationEntretien(); // Charge les voitures depuis la bdd
                                                                 // Pour remettre à jour la liste, on efface ses colonnes
            dgvEntretien.Columns.Clear();
            // on lui indique la source de données à afficher
            dgvEntretien.DataSource = typeof(List<Entretien>);
            dgvEntretien.DataSource = this.listEntretien;
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Supprimer";
            btnColumn.Text = "Supprimer";
            btnColumn.UseColumnTextForButtonValue = true;
            // on insère le bouton en position 0 des colonnes
            dgvEntretien.Columns.Insert(0, btnColumn);
            dgvEntretien.AutoResizeColumns();
            // on actualise l'affichage pour prendre acte des modifications effectuées
            dgvEntretien.Refresh();
        }


        public void ActualisationDgvElectrique()
        {
            //Actualisation du DGV 
            this.listVoitureElectrique = RecuperationElectrique(); // Charge les voitures depuis la bdd
                                                                   // Pour remettre à jour la liste, on efface ses colonnes
            dgvElectrique.Columns.Clear();
            // on lui indique la source de données à afficher
            dgvElectrique.DataSource = typeof(List<VoitureElectrique>);
            dgvElectrique.DataSource = this.listVoitureElectrique;
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Supprimer";
            btnColumn.Text = "Supprimer";
            btnColumn.UseColumnTextForButtonValue = true;
            // on insère le bouton en position 0 des colonnes
            dgvElectrique.Columns.Insert(0, btnColumn);
            dgvElectrique.AutoResizeColumns();
            // on actualise l'affichage pour prendre acte des modifications effectuées
            dgvElectrique.Refresh();
        }


        #endregion

        #region Ajout d'entretiens dans la bdd
  
        private void button1_Click(object sender, EventArgs e)
        {
            string immatriculation;
            string nom;
            string prenom;
            DateTime dateDebut;
            DateTime dateFin;

            immatriculation = immatriculationET.Text;
            nom = nomT.Text;
            prenom = prenomT.Text;
            dateDebut = debutT.Value;
            dateFin = fint.Value;

            if(dateDebut < dateFin)
            {
                MySql.Data.MySqlClient.MySqlConnection conn;
                string myConnectionString;
                myConnectionString = this.myConnectionString;
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                String myInsertQuery = @"insert into Entretien (`nom`,`prenom`,`immatriculation`,`datedebut`,`datefin`) 
                                    VALUES (@nom,@prenom,@immatriculation,@datedebut,@datefin);";

                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Parameters.AddWithValue("@nom", nom);
                myCommand.Parameters.AddWithValue("@prenom", prenom);
                myCommand.Parameters.AddWithValue("@immatriculation", immatriculation);
                myCommand.Parameters.AddWithValue("@datedebut", debutT.Text);
                myCommand.Parameters.AddWithValue("@datefin", fint.Text);

                myCommand.Connection = conn;
                myCommand.ExecuteNonQuery();

                nomT.Clear();
                prenomT.Clear();


                MessageBox.Show("Entretien Ajouté à la base de donnée.");
                ActualisationDgvEntretien();

            }
            else
            {
                MessageBox.Show("Impossible d'avoir une date de fin inférieure à la date de début");
            }

        }

        private void radioEntretienT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEntretienT.Checked == true)
            {
                immatriculationET.DataSource = listVoitureThermique;
                immatriculationET.DisplayMember = "immatriculation";
            }
        }

        private void radioEntretienE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEntretienE.Checked == true)
            {
                immatriculationET.DataSource = listVoitureElectrique;
                immatriculationET.DisplayMember = "immatriculation";
            }
        }

        #endregion

        #region Création d'objets à partir de la bdd (Entretiens).

        private List<Entretien> RecuperationEntretien()
        {
            List<Entretien> listEntretien = new List<Entretien>();
            try
            {
                MySql.Data.MySqlClient.MySqlConnection conn;
                string myConnectionString;
                myConnectionString = this.myConnectionString;
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                String selectquery = "SELECT * FROM Entretien;";
                MySqlCommand myCommand = new MySqlCommand(selectquery);
                conn.Open();
                myCommand.Connection = conn;
                MySqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    Entretien ent = new Entretien();
                    
                    ent.Identretien = Convert.ToInt32(reader["identretien"]);
                    ent.Immatriculation = reader["immatriculation"].ToString();
                    ent.Nom = reader["nom"].ToString();
                    ent.Prenom = reader["prenom"].ToString();
                    ent.Datedebut = reader["datedebut"].ToString();
                    ent.Datefin = reader["datefin"].ToString();


                    listEntretien.Add(ent);
                }

                return listEntretien;

            }
            catch (Exception)
            {
                throw;

            }

        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
