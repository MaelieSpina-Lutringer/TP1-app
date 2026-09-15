using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TP1_app
{
    internal class program
    {
        static void Main(string[] args)
        {
            Contacts contacts = new Contacts();
            bool continuer = true;

            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("Gestionnaire des contacts");
                Console.WriteLine("1. Ajouter un contact");
                Console.WriteLine("2. Chercher un contact par nom");
                Console.WriteLine("3. Modifier un contact par son index");
                Console.WriteLine("4. Supprimer un contact");
                Console.WriteLine("5. Afficher le nombre total de contacts");
                Console.WriteLine("6. Sauvegarder les contacts dans un fichier");
                Console.WriteLine("7. Charger un fichier");
                Console.WriteLine("8. Quitter");
                Console.Write("Choisissez une option: (1/8)");

                int choix = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choix)
                {
                    case 1:
                        Utilisateurs nouveau = new Utilisateurs();
                        Console.Write("Nom : ");
                        nouveau.Nom = Console.ReadLine();
                        Console.Write("Prénom : ");
                        nouveau.Prenom = Console.ReadLine();
                        Console.Write("Adresse : ");
                        nouveau.Adresse = Console.ReadLine();
                        Console.Write("Code Postal : ");
                        nouveau.CodePostal = Console.ReadLine();
                        Console.Write("Ville : ");
                        nouveau.Ville = Console.ReadLine();
                        Console.Write("Email : ");
                        nouveau.Email = Console.ReadLine();

                        if (contacts.Ajouter(nouveau))
                            Console.WriteLine("\nContact ajouté avec succès !");
                        else
                            Console.WriteLine("\nErreur lors de l'ajout.");
                        break;


                    case 2:

                        Console.Write("Entrez le nom à rechercher : ");
                        string nomCherche = Console.ReadLine();
                        Utilisateurs trouve = contacts.Chercher(nomCherche);
                        if (trouve != null)
                        {
                            Console.WriteLine("\n--- Contact trouvé ---");
                            Console.WriteLine($"Nom : {trouve.Nom}");
                            Console.WriteLine($"Prénom : {trouve.Prenom}");
                            Console.WriteLine($"Adresse : {trouve.Adresse}");
                            Console.WriteLine($"Code Postal : {trouve.CodePostal}");
                            Console.WriteLine($"Ville : {trouve.Ville}");
                            Console.WriteLine($"Email : {trouve.Email}");
                        }
                        else
                        {
                            Console.WriteLine("\nAucun contact trouvé avec ce nom.");
                        }

                        break;

                    case 3:
                        Console.Write("Entrez l'index du contact à modifier : ");
                        int index = int.Parse(Console.ReadLine());
                        Utilisateurs modifie = new Utilisateurs();
                        Console.Write("Nom : ");
                        modifie.Nom = Console.ReadLine();
                        Console.Write("Prénom : ");
                        modifie.Prenom = Console.ReadLine();
                        Console.Write("Adresse : ");
                        modifie.Adresse = Console.ReadLine();
                        Console.Write("Code Postal : ");
                        modifie.CodePostal = Console.ReadLine();
                        Console.Write("Ville : ");
                        modifie.Ville = Console.ReadLine();
                        Console.Write("Email : ");
                        modifie.Email = Console.ReadLine();
                        if (contacts.Modifier(index, modifie))
                            Console.WriteLine("\nContact modifié avec succès !");
                        else
                            Console.WriteLine("\nErreur lors de la modification.");
                        break;

                    case 4:
                        Console.Write("Entrez le nom du contact à supprimer : ");
                        string nomSupprime = Console.ReadLine();
                        Utilisateurs aSupprimer = contacts.Chercher(nomSupprime);
                        if (aSupprimer != null && contacts.Supprimer(aSupprimer))
                            Console.WriteLine("\nContact supprimé avec succès !");
                        else
                            Console.WriteLine("\nErreur lors de la suppression.");
                        break;

                    case 5:
                        Console.WriteLine($"\nNombre total de contacts : {contacts.Compter()}");
                        break;

                    case 6:
                        Console.Write("Entrez le nom du fichier pour sauvegarder : ");
                        string nomFichierSauvegarde = Console.ReadLine();
                        if (contacts.Sauvegarder(nomFichierSauvegarde))
                            Console.WriteLine("\nContacts sauvegardés avec succès !");
                        else
                            Console.WriteLine("\nErreur lors de la sauvegarde.");
                        break;

                    case 7:
                        Console.Write("Entrez le nom du fichier à charger : ");
                        string nomFichierCharge = Console.ReadLine();
                        if (contacts.Recuperer(nomFichierCharge))
                            Console.WriteLine("\nContacts chargés avec succès !");
                        else
                            Console.WriteLine("\nErreur lors du chargement.");
                        break;

                    case 8:
                        continuer = false;
                        break;
                }
                if (continuer)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
                    Console.ReadKey();
                }
            }
        }
    }
}
