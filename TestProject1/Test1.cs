using TP1_app;

namespace TestProject1
{
    [TestClass]
    public class TestContacts
    {
        private string testFilePath;

        [TestInitialize]
        public void setup()
        {
            testFilePath = Path.Combine(Path.GetTempPath(), "test_contacts.txt");
        }

        [TestCleanup]
        public void cleanup()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
        [TestMethod]
        public void TestAjouterEtCompter()
        {
            Contacts contacts = new Contacts();
            Utilisateurs usr = new Utilisateurs { Nom = "Dupont", Prenom = "Jean" };
            bool result = contacts.Ajouter(usr);
            Assert.IsTrue(result);
            Assert.AreEqual(1, contacts.Compter());
        }

        [TestMethod]

        public void TestSupprimer()
        {
            Contacts contacts = new Contacts();
            Utilisateurs usr = new Utilisateurs { Nom = "Dupont", Prenom = "Jean" };
            contacts.Ajouter(usr);
            bool result = contacts.Supprimer(usr);
            Assert.IsTrue(result);
            Assert.AreEqual(0, contacts.Compter());
        }

        [TestMethod]
        public void TestModifier()
        {
            Contacts contacts = new Contacts();
            Utilisateurs usr1 = new Utilisateurs { Nom = "Dupont", Prenom = "Jean" };
            Utilisateurs usr2 = new Utilisateurs { Nom = "Martin", Prenom = "Claire" };
            contacts.Ajouter(usr1);

            bool result = contacts.Modifier(0, usr2);

            Assert.IsTrue(result);
            Assert.AreEqual("Martin", contacts.Chercher("Martin")?.Nom);
        }

        [TestMethod]
        public void TestModifierIndexInvalide()
        {
            Contacts contacts = new Contacts();
            Utilisateurs usr = new Utilisateurs { Nom = "Dupont", Prenom = "Jean" };

            bool result = contacts.Modifier(0, usr);

            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TestChercher()
        {
            Contacts contacts = new Contacts();
            Utilisateurs usr = new Utilisateurs { Nom = "Dupont", Prenom = "Jean" };
            contacts.Ajouter(usr);
            Utilisateurs foundUser = contacts.Chercher("Dupont");
            Utilisateurs notFoundUser = contacts.Chercher("Non existant");
            Assert.IsNotNull(foundUser);
            Assert.AreEqual("Dupont", foundUser.Nom);
            Assert.IsNull(notFoundUser);

        }
        [TestMethod]

        public void TestSauvegarderEtRecuperer()
        {
            Contacts contactsOrigine = new Contacts();
            contactsOrigine.Ajouter(new Utilisateurs
            {
                Nom = "Parker",
                Prenom = "Peter",
                Adresse = "20 Ingram St",
                CodePostal = "11375",
                Ville = "New York",
                Email = "peter.parker@dailybugle.com"
            });

        bool saveResult = contactsOrigine.Sauvegarder(testFilePath);
        Assert.IsTrue(saveResult);
            Assert.IsTrue(File.Exists(testFilePath));

            Contacts contactsCharge = new Contacts();
        bool loadResult = contactsCharge.Recuperer(testFilePath);

        Assert.IsTrue(loadResult);
            Assert.AreEqual(1, contactsCharge.Compter());

            Utilisateurs usrCharge = contactsCharge.Chercher("Parker");
        Assert.IsNotNull(usrCharge);
            Assert.AreEqual("Peter", usrCharge.Prenom);
            Assert.AreEqual("20 Ingram St", usrCharge.Adresse);
            Assert.AreEqual("11375", usrCharge.CodePostal);
            Assert.AreEqual("New York", usrCharge.Ville);
            Assert.AreEqual("peter.parker@dailybugle.com", usrCharge.Email);
        }


[TestMethod]
        public void TestCreation()
        {
            Utilisateurs usr = new Utilisateurs();
            Assert.IsNotNull(usr.Nom);
            Assert.IsNotNull(usr.Prenom);
        }

        [TestMethod]
        public void TestNonVide()
        {
            Utilisateurs usr = new Utilisateurs();
            Assert.IsFalse(String.IsNullOrEmpty(usr.Nom));
            Assert.IsFalse(String.IsNullOrEmpty(usr.Prenom));
        }

        [TestMethod]
        public void TestCaracAlph()
        {
            Utilisateurs usr = new Utilisateurs();
            usr.Nom = "Parker";
            Assert.AreEqual("Parker", usr.Nom);
        }
    }
}