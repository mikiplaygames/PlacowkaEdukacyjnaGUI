using System;
using System.Collections.Generic;

class Klasa
{
    public Dictionary<int, Uczen> klasa = new Dictionary<int, Uczen>();

    public void AddStudent(UczenID uczenID, string imie, string nazwisko, int inteligencja, int zwinnosc, int zachowanie)
    {
        UczenID iD = new UczenID { szkola = uczenID.szkola, klasa = uczenID.klasa, numerUczen = klasa.Count + 1 };

        Uczen uczen = new Uczen { id = iD, imie = imie, nazwisko = nazwisko, inteligencja = inteligencja, zwinnosc = zwinnosc, punktyZachowania = zachowanie };

        klasa.Add(klasa.Count + 1, uczen);
    }

    public Uczen GetStudentFromClass(UczenID uczenID)
    {
        if (this.klasa.TryGetValue(uczenID.numerUczen, out Uczen uczen))
        {
            return uczen;
        }
        else
        {
            Console.WriteLine("Nie ma takiego ucznia " + uczenID.numerUczen);
            throw new NullReferenceException();
        }
    }

    public float ObliczSredniaInteligencja()
    {
        float srednia = 0;
        foreach (int i in klasa.Keys)
        {
            srednia += klasa[i].inteligencja;
        }
        srednia /= klasa.Count;
        return srednia;
    }
    public float ObliczSredniaZwinnosc()
    {
        float srednia = 0;
        foreach (int i in klasa.Keys)
        {
            srednia += klasa[i].zwinnosc;
        }
        srednia /= klasa.Count;
        return srednia;
    }
    public float ObliczSumaPkt()
    {
        float suma = 0;
        foreach (int i in klasa.Keys)
        {
            suma += klasa[i].punktyZachowania;
        }
        return suma;
    }
    public float ObliczSredniaPkt()
    {
        float srednia = 0;
        foreach (int i in klasa.Keys)
        {
            srednia += klasa[i].punktyZachowania;
        }
        srednia /= klasa.Count;
        return srednia;
    }
}