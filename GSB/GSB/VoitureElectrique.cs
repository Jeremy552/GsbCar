using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
    class VoitureElectrique : Voiture
    {
        #region Attributs
        string tempsCharge; // HH-MM-SS
        string autonomieKm;
        int idelectrique;
        #endregion

        #region Get/Set

        public string TempsCharge
        {
            get
            {
                return tempsCharge;
            }

            set
            {
                tempsCharge = value;
            }
        }

        public string AutonomieKm
        {
            get
            {
                return autonomieKm;
            }

            set
            {
                autonomieKm = value;
            }
        }

        public int Idelectrique
        {
            get
            {
                return idelectrique;
            }

            set
            {
                idelectrique = value;
            }
        }
        #endregion

        public VoitureElectrique() : base()
        {
            
        }
    }
}

