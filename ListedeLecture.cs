using System;
using System.Collections.Generic;
using System.Text;

public class  ListeDeLecture
{
    private List<Chanson> chansons = new List<Chanson>();
    {
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
        get
        {
            return chansons.Sum(c => c.DureeSecondes);
        }
    }

    // Trier les chansons par durée
    public List<Chanson> TrierParDuree()
    {
        return chansons
            .OrderBy(c => c.DureeSecondes)
            .ToList();
    }
}
