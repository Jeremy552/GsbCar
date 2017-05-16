using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
    class VoitureThermique : Voiture
    {



        public VoitureThermique() : base()
        {

        }

        #region Attributs

        public int capaciteReservoir;
        public int consommationMoy;
        public string typeCarburant;
        private int idThermique;



        #endregion

        #region Get/Set


        public int CapaciteReservoir
        {
            get
            {
                return capaciteReservoir;
            }

            set
            {
                capaciteReservoir = value;
            }
        }

        public int ConsommationMoy
        {
            get
            {
                return consommationMoy;
            }

            set
            {
                consommationMoy = value;
            }
        }

        public string TypeCarburant
        {
            get
            {
                return typeCarburant;
            }

            set
            {
                typeCarburant = value;
            }
        }

        public int IdThermique
        {
            get
            {
                return idThermique;
            }

            set
            {
                idThermique = value;
            }
        }
        #endregion



    }
}

