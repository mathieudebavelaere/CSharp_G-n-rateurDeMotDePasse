namespace générateur_mot_de_passe;

static class boite_outils
{

    public static int DemanderNombre(string question="ATTENTION: Aucune question n'est demandé dans les paramètres. \n La valeur retourner de cette fonction est un (int NUMBER). \n Ainsi que les valeurs minimal et maximal sont par défaut de (0 à 10). ", int minValue = 0, int maxValue = 10)
    {
        Console.WriteLine(question);
        int NUMBER = -1;
        while (NUMBER < minValue || NUMBER > maxValue)
        {
            Console.Write("Réponse : ");
            string number_str = Console.ReadLine();

            try
            {
                NUMBER = int.Parse(number_str);
                if (NUMBER > maxValue)
                    Console.WriteLine($"Erreur : Le nombre ne doit pas être superieur à {maxValue}");
                if (NUMBER < minValue)
                    Console.WriteLine($"Erreur : Le nombre ne doit pas être inferieur à {minValue}");
            }
            catch
            {
                Console.WriteLine($"Erreur :  Vous devez rentrer un nombre valide entre {minValue} et {maxValue}");
            }
        }
        return NUMBER;
    }
    public static void GenerateurDeMotDePasse()
    {
        int choice = boite_outils.DemanderNombre("Taper le numéro selon quel mot de passe vous souhaitez créer \n" +
                                                 "1 / Uniquement des caractère en minuscule ? \n" +
                                                 "2 / Des caractères minuscules et majuscules ? \n" +
                                                 "3 / Des caractères et des chiffres ? \n" +
                                                 "4 / Caractères, Chiffres et caractères spécieaux ?", 1, 4);

        int numberGenerate = boite_outils.DemanderNombre("Combien de mot de passe voulez vous créer ?", 0, 100);

        int numberQuestion = boite_outils.DemanderNombre("Combien de caractère souhaitez-vous générer ?", 0, 100);

        for (int o = 1; o < numberGenerate +1; o++)
        {
            string motDePasse = "";
            string alphabet_min = "";
            string alphabet_maj = "";
            string caractere = "";
            string number = "";

            if (choice >= 1)
            {
                alphabet_min = "abcdefghijqlmnopqrstuvwxyz";
                if (choice >= 2)
                {
                    alphabet_maj = alphabet_min.ToUpper();
                    if (choice >= 3)
                    {
                        number = "0123456789";
                        if (choice >= 4)
                        {
                            caractere = "#@&-_!";
                        }
                    }
                }
            }

            Random aleatoire = new Random();
            string alphabet = alphabet_min + alphabet_maj + caractere + number;
            int longueur_alphabet = alphabet.Length - 1;

            for (int i = 0; i < numberQuestion; i++)
            {
                int index = aleatoire.Next(0, longueur_alphabet);
                motDePasse += alphabet[index];
            }

            Console.WriteLine("");
            Console.WriteLine($"Mode de passe n°{o}: {motDePasse}");
        }

        Console.WriteLine("");
        Console.WriteLine($"Voici vos {numberGenerate} mots de passes de {numberQuestion} caractères !");
    }
}
