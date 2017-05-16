using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
    class Entretien
    {
         int identretien;
         string nom;
         string prenom;
         string immatriculation;
         string datedebut;
         string datefin;


        #region Get/Set
        public string Datefin
        {
            get
            {
                return datefin;
            }

            set
            {
                datefin = value;
            }
        }

        public string Datedebut
        {
            get
            {
                return datedebut;
            }

            set
            {
                datedebut = value;
            }
        }

        public string Immatriculation
        {
            get
            {
                return immatriculation;
            }

            set
            {
                immatriculation = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public int Identretien
        {
            get
            {
                return identretien;
            }

            set
            {
                identretien = value;
            }
        }
        #endregion

        public Entretien()
        {
                
        }
    }
}
