using System;
using System.Collections.Generic;
class ListaSzkol
{
    public Dictionary<string, Szkola> listaSzkol = new Dictionary<string, Szkola>();

    public void AddSchool(string nazwaSzkoly, Szkola szkola)
    {
        listaSzkol.Add(nazwaSzkoly, szkola);
    }

    public Szkola GetSchoolFromList(UczenID uczenID)
    {
        if (this.listaSzkol.TryGetValue(uczenID.szkola, out Szkola szkola))
        {
            return szkola;
        }
        else
        {
            Console.WriteLine("Nie ma takiej szkoly " + uczenID.szkola);
            throw new NullReferenceException();
        }
    }

    public Uczen GetStudentFromAnywhere(UczenID uczenID)
    {
        var szkola = GetSchoolFromList(uczenID);
        var klasa = szkola.GetClassFromSchool(uczenID);
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