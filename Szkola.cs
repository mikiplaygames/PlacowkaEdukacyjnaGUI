using System;
using System.Collections.Generic;

class Szkola
{
    public Dictionary<string, Klasa> szkola = new Dictionary<string, Klasa>();

    public void AddClass(string nazwaKlasy, Klasa klasa)
    {
        szkola.Add(nazwaKlasy, klasa);
    }

    public float SredniaSzkolyInteligencja()
    {
        float iq = 0;
        foreach (var item in szkola.Values)
        {
            iq += item.ObliczSredniaInteligencja();
        }
        iq = iq/szkola.Count;
        return iq;
    }
    public float SredniaSzkolyZachowanie()
    {
        float pkt = 0;
        foreach (var item in szkola.Values)
        {
            pkt += item.ObliczSredniaPkt();
        }
        pkt = pkt / szkola.Count;
        return pkt;
    }
    public float SredniaSzkolyZwinnosc()
    {
        float agility = 0;
        foreach (var item in szkola.Values)
        {
            agility += item.ObliczSredniaZwinnosc();
        }
        agility = agility / szkola.Count;
        return agility;
    }
    public Klasa GetClassFromSchool(UczenID uczenID)
    {
        if (this.szkola.TryGetValue(uczenID.klasa, out Klasa klasa))
        {
            return klasa;
        }
        else
        {
            Console.WriteLine("Nie ma takiej szkoly " + uczenID.szkola);
            throw new NullReferenceException();
        }
    }

    public Uczen GetUczenFromSchool(UczenID uczenID)
    {
        var klasa = GetClassFromSchool(uczenID);
        var uczen = klasa.GetStudentFromClass(uczenID);

        if (uczen != null)
        {
            return uczen;
        }
        else
        {
            Console.WriteLine("Nie ma takiego ucznia " + uczenID.ToString());
            throw new NullReferenceException();
        }
    }
}