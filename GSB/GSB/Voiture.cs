using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
        public class Voiture
        {
            public string immatriculation;
            public string marque;
            public string modele;
            public string puissanceFiscale;
            public int kilometrage;
            public string dateImmatriculation;// 0000-00-00
            public string dateAchat; // 0000-00-00
            public double prixAchat;
            public double loyerMensuel;

            #region Get/Set

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

            public string Marque
            {
                get
                {
                    return marque;
                }

                set
                {
                    marque = value;
                }
            }

            public string Modele
            {
                get
                {
                    return modele;
                }

                set
                {
                    modele = value;
                }
            }

            public string PuissanceFiscale
            {
                get
                {
                    return puissanceFiscale;
                }

                set
                {
                    puissanceFiscale = value;
                }
            }

            public int Kilometrage
            {
                get
                {
                    return kilometrage;
                }

                set
                {
                    kilometrage = value;
                }
            }

            public string DateImmatriculation
            {
                get
                {
                    return dateImmatriculation;
                }

                set
                {
                    dateImmatriculation = value;
                }
            }

            public string DateAchat
            {
                get
                {
                    return dateAchat;
                }

                set
                {
                    dateAchat = value;
                }
            }

            public double PrixAchat
            {
                get
                {
                    return prixAchat;
                }

                set
                {
                    prixAchat = value;
                }
            }

            public double LoyerMensuel
            {
                get
                {
                    return loyerMensuel;
                }

                set
                {
                    loyerMensuel = value;
                }
            }

            #endregion

        }
    }
