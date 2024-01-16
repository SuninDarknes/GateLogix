using System;

class Osoba
{
    // Privatni atributi
    private string ime;
    private int godine;

    // Konstruktor za postavljanje početnih vrijednosti
    public Osoba(string ime, int godine)
    {
        this.ime = ime;
        this.godine = godine;
    }

    // Javna metoda za dohvačanje imena
    public string DohvatiIme()
    {
        return ime;
    }

    // Javna metoda za postavljanje imena
    public void PostaviIme(string novoIme)
    {
        ime = novoIme;
    }

    // Javna metoda za dohvačanje godina
    public int DohvatiGodine()
    {
        return godine;
    }

    // Javna metoda za postavljanje godina s provjerom
    public void PostaviGodine(int noveGodine)
    {
        if (noveGodine > 0)
        {
            godine = noveGodine;
        } else
        {
            Console.WriteLine("Godina moraju biti pozitivan broj.");
        }
    }
}

class Program
{
    static void Glavna()
    {
        // Kreiranje objekta
        Osoba osoba1 = new Osoba("Ana", 25);

        // Dohvačanje podataka pomoću javnih metoda
        Console.WriteLine("Ime: " + osoba1.DohvatiIme());
        Console.WriteLine("Godine: " + osoba1.DohvatiGodine());

        // Promjena podataka pomoću javnih metoda
        osoba1.PostaviIme("Marko");
        osoba1.PostaviGodine(30);

        // Ponovno dohvačanje podataka nakon promjena
        Console.WriteLine("Nakon promjena - Ime: " + osoba1.DohvatiIme());
        Console.WriteLine("Nakon promjena - Godine: " + osoba1.DohvatiGodine());
    }
}