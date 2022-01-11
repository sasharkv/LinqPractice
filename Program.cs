using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public string Naam { get; set; } // Name

    public int Geboortejaar { get; set; } // Birth year

    public string Klas { get; set; }  // Group

    public string Geslacht { get; set; } // Gender

    public override string ToString()
    {
        return "Student[" + Naam + "," + Geboortejaar.ToString() + "," + Klas + "," + Geslacht + "]";
    }



    public static IList<Student> Studenten = new List<Student>
        {
            new Student{Naam = "John", Geboortejaar = 1968, Klas = "1A", Geslacht = "Man"},
            new Student{Naam = "Klaas", Geboortejaar = 1980, Klas = "3B", Geslacht = "Genderneutraal"},
            new Student{Naam = "Mohammed", Geboortejaar = 1989, Klas = "2A", Geslacht = "Vrouw"},
            new Student{Naam = "Christus", Geboortejaar = 1998, Klas = "1A", Geslacht = "Man"},
            new Student{Naam = "Jan", Geboortejaar = 1982, Klas = "3B", Geslacht = "Man"},
            new Student{Naam = "Jaap", Geboortejaar = 1969, Klas = "3B", Geslacht = "Geheim"},
            new Student{Naam = "Joep", Geboortejaar = 1968, Klas = "2A", Geslacht = "Genderfluid"},
            new Student{Naam = "Hans", Geboortejaar = 1957, Klas = "1A", Geslacht = "Vrouw"},
            new Student{Naam = "Joep", Geboortejaar = 1971, Klas = "1A", Geslacht = "Vrouw"},
            new Student{Naam = "Tim", Geboortejaar = 1975, Klas = "2A", Geslacht = "Vrouw"},
            new Student{Naam = "Brazil", Geboortejaar = 1985, Klas = "3A", Geslacht = "Man"},
            new Student{Naam = "Hans", Geboortejaar = 1988, Klas = "3B", Geslacht = "Vrouw"},
            new Student{Naam = "Tom", Geboortejaar = 1968, Klas = "1A", Geslacht = "Genderfluid"},
            new Student{Naam = "Pim", Geboortejaar = 2012, Klas = "2B", Geslacht = "Vrouw"},
            new Student{Naam = "Ubud", Geboortejaar = 1997, Klas = "2A", Geslacht = "Vrouw"},
            new Student{Naam = "Julia", Geboortejaar = 1965, Klas = "2A", Geslacht = "Genderfluid"},
            new Student{Naam = "Romeo", Geboortejaar = 1991, Klas = "3B", Geslacht = "Vrouw"},
            new Student{Naam = "John", Geboortejaar = 2002, Klas = "2B", Geslacht = "Non-binair"}
        };

    // Opdrachten = exercises
    public static void Opdrachten()
    {
        Opdracht1();
        Opdracht2();
        Opdracht3();
        Opdracht4();
        Opdracht5();
        Opdracht6();
    }

    static void Opdracht1() // Toon van alle studenten de naam en het geboortejaar, gesorteerd het geboortejaar. ENG: Show name and birth year of all students.
    {
        foreach (Student student in Studenten.OrderBy(s => s.Geboortejaar))
        {
            Console.WriteLine("{0} - {1}", student.Naam, student.Geboortejaar);
        }
    }

    static void Opdracht2() // In welk jaar is de jongste student geboren in klas 2A?  ENG: In which year is the youngest student of klas 2A born?
    {
        Console.WriteLine(Studenten.OrderByDescending(s => s.Geboortejaar).First());
        // OR better
        Console.WriteLine(Studenten.Where(s => s.Klas == "2A").Max(s => s.Geboortejaar));
    }

    static void Opdracht3() // Hoeveel vrouwen zitten er in klas 1A?  ENG: How many women are there in klas 1A?
    {
        Console.WriteLine(Studenten.Where(s => s.Geslacht == "Vrouw").Count());
        //OR better
        Console.WriteLine(Studenten.Where(s => s.Klas == "1A" && s.Geslacht == "Vrouw").Count());
    }

    static void Opdracht4() // Toon de 6e t/m 10e student uit de lijst.   ENG: Show the 6th to 10th student from the list.
    {
        foreach (Student student in Studenten.Take(6))
        {
            Console.WriteLine(student.Naam);
        }

        //OR better
        foreach (Student student in Studenten.Skip(5).Take(5))
        {
            Console.WriteLine(student.Naam);
        }
    }

    static void Opdracht5() // Is er een student uit 1997 (True/False)? ENG: Is there a student born in 1997? (True/False)
    {
        Console.WriteLine(Studenten.Any(s => s.Geboortejaar == 1997)); // couldn't use Exists because Studenten is IEnumerable
    }

    static void Opdracht6() // In welke klas zit Joep? ENG: In which klas is Joep?
    {
        Console.WriteLine(Studenten.Where(s => s.Naam == "Joep").Select(s => s.Klas));  // how would that  work if there were more than 1 Joeps?
    }
}

public class BlackBoardPagina
{
    public string URL { get; set; }

    public override string ToString()
    {
        return "Pagina[" + URL.ToString() + "]";
    }

    public static BlackBoardPagina Home = new BlackBoardPagina() { URL = "blackboard.nl" };
    public static BlackBoardPagina Sem2 = new BlackBoardPagina() { URL = "blackboard.nl/sem2" };
    public static BlackBoardPagina AgileOO = new BlackBoardPagina() { URL = "blackboard.nl/agile" };
    public static BlackBoardPagina Sem3 = new BlackBoardPagina() { URL = "blackboard.nl/sem3" };
    public static BlackBoardPagina WPFW = new BlackBoardPagina() { URL = "blackboard.nl/wpfw" };
    public static BlackBoardPagina Wikipedia = new BlackBoardPagina() { URL = "wikipedia.nl/" };
}

public class Bezoek // Visit
{
    public Student Student { get; set; }
    public BlackBoardPagina Pagina { get; set; }
    public int Duur { get; set; } // Length of a visit
    public List<Bezoek> DoorgekliktNaar { get; set; } // clicked through to

    public override string ToString()
    {
        return "Bezoek[" + Student.ToString() + "," + Pagina.ToString() + "," + Duur.ToString() + "]";
    }


    // De lijst `bezoekjes` bevat alle bezoekjes van studenten aan blackboard pagina's. 
    // ENG: This list 'bezoekjes' ('visits') contains visits of the students to the blackboard pages (blackboard website = university's intranet)
    public static List<Bezoek> bezoekjes = null; // Bezoek = visit, bezoekjes = visits
    static Bezoek()
    {
        Bezoek b1 = new Bezoek() { Student = Student.Studenten[0], Duur = 30, Pagina = BlackBoardPagina.Home }; // Duur = length, pagina = page
        Bezoek b2 = new Bezoek() { Student = Student.Studenten[0], Duur = 130, Pagina = BlackBoardPagina.Sem3 };
        Bezoek b3 = new Bezoek() { Student = Student.Studenten[0], Duur = 342, Pagina = BlackBoardPagina.WPFW };
        Bezoek b4 = new Bezoek() { Student = Student.Studenten[0], Duur = 5, Pagina = BlackBoardPagina.Sem2 };
        Bezoek b5 = new Bezoek() { Student = Student.Studenten[1], Duur = 25, Pagina = BlackBoardPagina.Home };
        Bezoek b6 = new Bezoek() { Student = Student.Studenten[1], Duur = 394, Pagina = BlackBoardPagina.Sem2 };
        Bezoek b7 = new Bezoek() { Student = Student.Studenten[1], Duur = 23, Pagina = BlackBoardPagina.Sem3 };
        Bezoek b8 = new Bezoek() { Student = Student.Studenten[1], Duur = 115, Pagina = BlackBoardPagina.WPFW };
        Bezoek b9 = new Bezoek() { Student = Student.Studenten[1], Duur = 29, Pagina = BlackBoardPagina.AgileOO };
        b1.DoorgekliktNaar = new List<Bezoek> { b2, b4 }; // DoorgekliktNaar = Clicked through to
        b2.DoorgekliktNaar = new List<Bezoek> { b3 };
        b5.DoorgekliktNaar = new List<Bezoek> { b6 };
        b6.DoorgekliktNaar = new List<Bezoek> { b7, b9 };
        b7.DoorgekliktNaar = new List<Bezoek> { b8 };
        bezoekjes = new List<Bezoek> { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
    }

    public static void Opdrachten() // opdrachten = exercises
    {
        Opdracht1();
        Opdracht2();
        Opdracht3();
        Opdracht4();
        Opdracht5();
        Opdracht6();
    }

    static void Opdracht1() // Hoe vaak hebben de studenten in totaal doorgeklikt?. ENG: How many times did the student click through in total?

    {
        /// someValues.ToList().ForEach(x => list.Add(x + 1));

        ///  Console.WriteLine(bezoekjes...);

        /// Console.WriteLine("Sum: {0}", Bezoek.bezoekjes.Where(w => w.DoorgekliktNaar != null).Count());  /// this gets 5, not 7

        /*  /// this works but is not LINQ

           int i = 0;
          foreach (var item in bezoekjes.Where(b => b.DoorgekliktNaar != null))
          {
              i += item.DoorgekliktNaar.Count();
          }
          Console.Write(i);

          */

        Console.WriteLine(bezoekjes.Sum(b => b.DoorgekliktNaar?.Count() ?? 0)); /// The Answer!!! This is a null-conditional operator (mentioned once in lecture on C#)
    }

    static void Opdracht2() // We willen in een console een lijst te zien krijgen van bezoekjes korter dan 1 minuut. Gebruik de ToString in Bezoek. 
                            // Tip: gebruik Where, ToList en daarna ForEach. Waarom bestaat ForEach niet in LINQ?

    // ENG: We want to see a list of visits(bezoekjes) shorter than 1 minute in the console. Use the ToString in Visit (Bezoek).
    //Tip: use Where, ToList and then ForEach. Why doesn't ForEach exist in LINQ?
    {

        bezoekjes.Where(b => b.Duur < 60).ToList().ForEach(b => Console.WriteLine(b));
    }

    static void Opdracht3() // We willen een lijst van pagina's die tenminste twee keer zijn bezocht ENG: We want a list of pages that were visited at least twice.
    {
        List<BlackBoardPagina> paginasTenminsteTweeKeerBezocht = bezoekjes.GroupBy(b => b.Pagina).Where(x => x.Count() >= 2).Select(p => p.Key).ToList();
        bezoekjes.GroupBy(b => b.Pagina).Where(x => x.Count() >= 2).Select(p => p.Key).Select(x => x.URL).ToList().ForEach(item => Console.WriteLine(item));
    }

    static void Opdracht4() // Print van elke student uit hoeveel verschillende pagina's hij/zij heeft bezocht. 
    //Tip: kijk uit dat je meerdere bezoekjes van een student aan dezelfde pagina niet dubbel telt! Tip: gebruik Distinct. Tip: gebruik een anonieme type. 
    // ENG: Print for each student how many pages he/she visited.
    // Tip: Make sure not to count the visits to the same page of a given student! Tip: Use Distinct. Tip: use anonymous type.
    {
        var r = bezoekjes.GroupBy(b => b.Student).Select(p => p.Key);//???
        var user = new { Name = "Tom", LastName = "Angelo" };
        foreach (var i in bezoekjes.GroupBy(b => b.Student).Select(temp => new { Student = temp.Key, Aantal = temp.Select(b => b.Pagina).Distinct().Count() }))
            Console.WriteLine("Student " + i.Student.Naam + " heeft " + i.Aantal + " verschillende pagina's bezocht. ");
    }

    static void Opdracht5() // Geef alternatieve LINQ die sneller werkt. ENG: Give alternative LINQ that works quicker.
    {
        if (bezoekjes.FirstOrDefault(x => x.Duur > 100) != null)
            Console.WriteLine("Er is een lang bezoek geweest. ");
    }


    static void Opdracht6() // Zet de top drie meest ijverige studenten in een IEnumerable. Een student is ijveriger dan een andere student als deze meer paginas heeft bekeken. Tip: kopieer je antwoord bij Opdracht4
    // ENG: Put three of the most diligent student into an IEnumerable. A student is more diligent than others if he visited more pages. Tip: copy your answer from Opdracht4
    {
        //= bezoekjes.GroupBy(b => b.Student).Select(temp => new { Student = temp.Key, Aantal = temp.Select(b => b.Pagina).Distinct().Count() }).OrderByDescending(x=>x.Aantal).Take(3).Select(x=>x.Student);
        IEnumerable<Student> ijverigeStudenten = bezoekjes.GroupBy(b => b.Student).Select(temp => new { Student = temp.Key, Aantal = temp.Select(b => b.Pagina).Distinct().Count() }).OrderByDescending(x => x.Aantal).Select(x => x.Student).Take(3);
    }
}

public static class LosseOpgaven
{
    public static void Opdrachten()
    {
        Opdracht1();
        Opdracht2();
        Opdracht3();
        Opdracht4();
        Opdracht5();
    }

    static void Opdracht1() // De gebruiker voert een zin in, en die zin wordt vervolgens opgesplitst in woorden. Bedenk welke LINQ er op de plaats van de puntjes terecht moet komen om de oorspronkelijke zin weer terug te krijgen. 
    // ENG: The user inputs a sentence, and the sentence is then split into words. Think of a LINQ to fill in the dots to return the original sentence.
    {
        string zin = "Wie dit leest is gek";
        string[] woorden = zin.Split(" ");
        zin = null;
        zin = woorden.Aggregate((s1, s2) => s1 + " " + s2);
        Console.WriteLine(zin);
    }

    static void Opdracht2() // Wat moet er op de plaats van de puntjes komen te staan om de getallen uit de lijst die hetzelfde zijn als het getal ervoor eruit te filteren?
    // ENG: What needs to be filled in in place of the dots to filter out the nubers that are the same as the previous numbers?
    {
        List<int> getallen = new List<int> { 4, 6, 6, 3, 2, 5, 5, 3, 5, 3, 3, 7, 8 };

        // met new List<int>() geef je een type mee aan 'a'. Je kunt ook een seed getal meegeven om hem te initialiseren. 
        foreach (int i in getallen.Aggregate(new List<int>(), (a, b) =>
        {
            if (a.Count == 0 || b != a[a.Count - 1])    // met 'b' checked het of het dezelfde waarde heeft als de vorige index positie. Als zelfde, niet toevoegen.
                a.Add(b);
            return a;
        }))
            Console.WriteLine(i);
        // De uitvoer hoort 4, 6, 3, 2, 5, 3, 5, 3, 7, 8 te zijn. 
    }

    static void Opdracht3() // Houd er rekening mee dat de getallen in de lijst flink van grootte verschillen en dat double een eindige precisie heeft. 
                            // Bereken het totaal en print het resultaat. Tip: maakt de volgorde uit waarin de getallen worden opgeteld?
                            // ENG: Take into account that the numbers in the list differ a lot and that double is more precise.
                            // Calculate the total and print out the result. Tip: does the order in which the numbers are added up matter?
    {
        List<double> getallen = new List<double>();
        getallen.Add(100000000000000000.0);
        for (int i = 0; i < 1000000; i++) getallen.Add(1);
        double totaal = getallen.OrderBy(i => i).Sum();
        Console.WriteLine(totaal);
    }
    class HelperClass
    {
        public DateTime? vorige { get; set; } = null;
        public bool aan { get; set; }
        public int totaal { get; set; }
    }

    static void Opdracht4() // Gegeven is een lijst `tijden` van tijdstippen waarop de lichtschakelaar is ingedrukt. 
    // Bereken hoe lang het licht aan heeft gestaan in LINQ, door gebruik te maken van Aggregate. Het licht stond uit voor de eerste item. Deze vraag is erg moeilijk! Tip: maak een helper klasse aan. 
    // ENG: Given is a list `tijden`(times) of the time slots when the light switch was turned on.
    // Calculate how long the light was on with LINQ by using Aggregate. The light was out for the first item. This question is very hard! Tip: make a helper class.
    {
        List<DateTime> tijden = new List<DateTime>
        {
            new DateTime(2021, 3, 4, 9, 0, 3),
            new DateTime(2021, 3, 4, 10, 20, 35),
            new DateTime(2021, 3, 4, 15, 2, 22),
            new DateTime(2021, 3, 4, 16, 1, 0),
            new DateTime(2021, 3, 4, 16, 55, 48),
            new DateTime(2021, 3, 4, 22, 40, 12)
        };

        int totaalAantalSecondenAan = tijden.Aggregate<DateTime, HelperClass>(new HelperClass(), (totnutoe, deze) =>
        {
            if (totnutoe.aan)
                totnutoe.totaal += (int)(deze - totnutoe.vorige).Value.TotalSeconds;
            totnutoe.aan = !totnutoe.aan;
            totnutoe.vorige = deze;
            return totnutoe;
        }).totaal;
    }

    static void Opdracht5() // Omdat lambda expressies variabelen kunnen capturen van buiten de lambda expressie, is het mogelijk om te tellen met een ForEach. 
    // Zonder uitvoeren van de code, wat denk je dat er wordt geprint? Waarom? Is jouw antwoord hetzelfde als de Select wordt vervangen door ForEach?
    // ENG: Because lambda expressions can capture variables from outside the lambda expression, it's possible to count with a ForEach.
    // Without running the code, what do you think will be the output? Why? Is your answer the same if Select is replaced with ForEach?
    {
        int i = 0;
        Student.Studenten.Select((student) => i++);
        Console.WriteLine(i);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student.Opdrachten();
        Bezoek.Opdrachten();
        LosseOpgaven.Opdrachten();
    }
}