
using System;
using System.Collections.Generic;
using System.Linq;

// 1. Création de l'enregistrement Chanson
public record Chanson(
    string Titre,
    string Artiste,
    int DureeSecondes
);

// 2. Création de la classe ListeDeLecture
public class ListeDeLecture
{
    private List<Chanson> chansons = new List<Chanson>();

    // Ajouter une chanson
    public void Ajouter(Chanson chanson)
    {
        chansons.Add(chanson);
    }

    // Indexeur
    public Chanson this[int index]
    {
        get { return chansons[index]; }
    }

    // Nombre de chansons
    public int NombreChansons
    {
        get { return chansons.Count; }
    }

    // Durée totale
    public int DureeTotale
    {
        get { return chansons.Sum(c => c.DureeSecondes); }
    }

    // 3. Trier les chansons de la plus courte à la plus longue
    public List<Chanson> TrierParDuree()
    {
        return chansons
            .OrderBy(c => c.DureeSecondes)
            .ToList();
    }
}

// 4. Programme principal
class Programme
{
    static void Main()
    {
        Console.WriteLine("===== GESTION DE LA LISTE DE LECTURE =====");

        ListeDeLecture maListe = new ListeDeLecture();

        // Création des chansons
        Chanson chanson1 = new Chanson("Perfect", "Ed Sheeran", 263);
        Chanson chanson2 = new Chanson("Imagine", "John Lennon", 183);
        Chanson chanson3 = new Chanson("Hello", "Adele", 295);
        Chanson chanson4 = new Chanson("Shape of You", "Ed Sheeran", 240);

        // Ajouter les chansons
        maListe.Ajouter(chanson1);
        maListe.Ajouter(chanson2);
        maListe.Ajouter(chanson3);
        maListe.Ajouter(chanson4);

        // Afficher les chansons
        Console.WriteLine("\n--- Liste des chansons ---");

        for (int i = 0; i < maListe.NombreChansons; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {maListe[i].Titre} - " +
                $"{maListe[i].Artiste} - " +
                $"{maListe[i].DureeSecondes} secondes"
            );
        }

        // Afficher le nombre de chansons
        Console.WriteLine(
            "\nNombre total de chansons : " +
            maListe.NombreChansons);

        // Afficher la durée totale
        Console.WriteLine(
            "Durée totale : " +
            maListe.DureeTotale + " secondes");

        // 5. Ordonnancement par durée
        Console.WriteLine("\n--- Chansons classées de la plus courte à la plus longue ---");

        List<Chanson> chansonsTriees = maListe.TrierParDuree();

        foreach (Chanson chanson in chansonsTriees)
        {
            Console.WriteLine(
                chanson.Titre + " - " +
                chanson.Artiste + " - " +
                chanson.DureeSecondes + " secondes"
            );
        }

        // 6. Vérifier l'égalité des valeurs
        Console.WriteLine("\n--- Vérification de l'égalité ---");

        Chanson chansonA = new Chanson("Hello", "Adele", 295);
        Chanson chansonB = new Chanson("Hello", "Adele", 295);

        Console.WriteLine(
            "Les deux chansons sont-elles égales ? " +
            (chansonA == chansonB));

        // 7. Utiliser l'expression with
        Console.WriteLine("\n--- Utilisation de WITH ---");

        Chanson nouvelleChanson = chansonA with
        {
            Titre = "Hello Remix"
        };

        Console.WriteLine("Chanson originale : " + chansonA.Titre);
        Console.WriteLine("Nouvelle chanson : " + nouvelleChanson.Titre);

        Console.WriteLine("\n===== FIN DU PROGRAMME =====");
    }
}
