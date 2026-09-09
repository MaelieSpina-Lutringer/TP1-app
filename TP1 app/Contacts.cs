using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TP1_app
{
    public class Contacts
    {
        private List<Utilisateurs> items;
        public Contacts()
        {
            items = new List<Utilisateurs>();
        }
        public bool Ajouter(Utilisateurs item)
        {
            bool result = true;
            try
            {
                items.Add(item);
            }
            catch
            { result = false; }
            return result;
        }
        public bool Supprimer(Utilisateurs item)
        {
            return items.Remove(item);
        }

        public bool Modifier(int index, Utilisateurs Nouveau)
        {
            if (index >= 0 && index < items.Count && Nouveau != null)

            {
                items[index] = Nouveau;
                return true;
            }
            return false;

        }
        public Utilisateurs Chercher(string nom)
        {
            foreach (var item in items)
            {
                if (item.Nom != null && item.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }
        public int Compter()
        {
            return items.Count;

        }
        public bool Sauvegarder(string leFichier)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(leFichier))
                {
                    foreach (var u in items)
                    {
                        sw.WriteLine($"{u.Nom};{u.Prenom};{u.Adresse};{u.CodePostal};{u.Ville};{u.Email}");

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Recuperer(string leFichier)
        {
            if (!File.Exists(leFichier)) return false;

            try
            {
                items.Clear();
                string[] lignes = File.ReadAllLines(leFichier);
                foreach (string ligne in lignes)

                {
                    string[] parts = ligne.Split(';');
                    if (parts.Length == 6)
                    {
                        Utilisateurs u = new Utilisateurs
                        {
                            Nom = parts[0],
                            Prenom = parts[1],
                            Adresse = parts[2],
                            CodePostal = parts[3],
                            Ville = parts[4],
                            Email = parts[5]
                        };
                        items.Add(u);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }


        }
        static void Main(string[] args)
        {
            Contacts contacts = new Contacts();
            Utilisateurs utilisateur1 = new Utilisateurs
            {
                Nom = "Doe",
                Prenom = "John",
                Adresse = "123 Main St",
                CodePostal = "12345",
                Ville = "Anytown",
                Email = "",
            };
           }
    }
}

