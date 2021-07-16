using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace PoELevelingGuide_Lite
{
    /**
     * Classe Sérialise
     * Permet de sauvegarder en binaire et récupérer des objets
     */
    [Serializable]
    class Serialise
    {

        //--- Sérialisation ---
        public static void Sauve(string fichier, Object objet)
        {

            //--- si le fichier existe, il faut le supprimer ---
            if (File.Exists(fichier))
            {
                File.Delete(fichier);
            }

            //--- création du flux pour l'écriture dans le fichier ---
            FileStream flux = new FileStream(fichier, FileMode.Create);

            //--- création d'un objet pour le formatage en binaire des informations ---
            BinaryFormatter fbinaire = new BinaryFormatter();

            //--- sérialisation des objets de la collection
            fbinaire.Serialize(flux, objet);

            //--- fermeture du flux ---
            flux.Close();

        }

        //--- Désérialisation ---
        public static Object Recup(string fichier)
        {

            //--- Contrôle de l'existance du fichier ---
            if (File.Exists(fichier))
            {
                //--- ouverture du flux pour la lecture dans le fichier ---
                FileStream flux = new FileStream(fichier, FileMode.Open);

                //--- création d'un objet pour le formatage en binaire des informations ---
                BinaryFormatter fbinaire = new BinaryFormatter();

                //--- récupération de l'objet sérialisé ---
                try
                {
                    Object objet = fbinaire.Deserialize(flux);

                    //--- fermeture du flux ---
                    flux.Close();

                    //--- retour de l'objet ---
                    return objet;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

    }
}
