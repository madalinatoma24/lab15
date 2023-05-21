using System;
using System.Collections.Generic;
using System.Linq;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
          //  var gestiuneStudenti = new GestiuneStudenti();
            List<Student> studenti = new List<Student>();
            Console.WriteLine("Populam lista de studenti");

            studenti.Add(new Student { Id = Guid.NewGuid(), Nume = "Popescu", Prenume = "Ion", Varsta = 17, Specializare = Specializari.Informatica });
            studenti.Add(new Student { Id = Guid.NewGuid(), Nume = "Andone", Prenume = "Alice", Varsta = 19, Specializare = Specializari.Constructii });
            studenti.Add(new Student { Id = Guid.NewGuid(), Nume = "Biscuite", Prenume = "Rock", Varsta = 23, Specializare = Specializari.Litere });
            studenti.Add(new Student { Id = Guid.NewGuid(), Nume = "Bian", Prenume = "Alina", Varsta = 27, Specializare = Specializari.Informatica });
            studenti.Add(new Student { Id = Guid.NewGuid(), Nume = "Titi", Prenume = "Casandra", Varsta = 22, Specializare = Specializari.Litere });
            studenti.Add(new Student { Id = Guid.NewGuid(), Nume = "Maftei", Prenume = "Alina", Varsta = 21, Specializare = Specializari.Constructii });
            studenti.Add(new Student { Id = Guid.NewGuid(), Nume = "Radulescu", Prenume = "Vasile", Varsta = 40, Specializare = Specializari.Informatica });
           
         

            Console.WriteLine( studenti.Where(p => p.Specializare == Specializari.Informatica).OrderBy(p=> p.Varsta).LastOrDefault());


            Console.WriteLine(studenti.FirstOrDefault(p => p.Varsta == studenti.Min(p => p.Varsta)));
            Console.WriteLine(studenti.OrderBy(p=> p.Varsta).FirstOrDefault());

            Console.WriteLine("Studentii de la Litere ordonati crescator");
            studenti.Where(s=> s.Specializare== Specializari.Litere).OrderBy(p=> p.Varsta).ToList().ForEach(p=> Console.WriteLine(p));


            Console.WriteLine($"Afisati primul student de la constructii cu varsta de peste 20 de ani: \n\t");

            Console.WriteLine(studenti.Where(p=> p.Varsta>20 && p.Specializare==Specializari.Constructii).FirstOrDefault());


            Console.WriteLine($"Afisati studentii avand varsta egala cu varsta medie a studentilor:"); 
            var varstaMedie= studenti.Average(p=> p.Varsta);
            studenti.FindAll(p => p.Varsta == varstaMedie).ForEach(p => Console.WriteLine(p));


            Console.WriteLine($"Afisati, in ordinea descrescatoare a varstei,si in ordine alfabetica, dupa numele defamilie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 35 de ani:");
            studenti.Where(p => p.Varsta > 18 && p.Varsta < 35).OrderByDescending(p => p.Varsta).OrderBy(p => p.Nume).ThenBy(p=> p.Prenume).ToList().ForEach(p=> Console.WriteLine(p));

            Console.WriteLine($"Afisati ultimul elev din lista folosind linq:");
            Console.WriteLine(studenti.LastOrDefault());

            Console.WriteLine($"Afisati mesajul “Exista si minori” daca in lista creeata exista si persone cu varsta mai mica de 18 ani. In caz contar afesati “Nu exista minori”:");

            studenti.Where(p => p.Varsta < 18).ToList();
            if (studenti.Count > 0)
            {
                Console.WriteLine( "Exista si minori");
            }
            else
            {
                Console.WriteLine("Nu exista minori");
            }

            Console.WriteLine($"Special");
            studenti.GroupBy(p => p.Varsta).ToList().ForEach(p=> { Console.WriteLine($"Studenti cu varsta:{p.Key}"); p.ToList().ForEach(s => Console.WriteLine(s)); });
                                
        }
    }
}
