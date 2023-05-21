using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab15
{
    public class GestiuneStudenti
    {

        private List<Student> _studenti = new List<Student>();


        public void AddStudenti(Student student)
        {
            _studenti.Add(student);
        }
        public Student CelMaiMareStudent(Specializari specializari)
        {
           var student= _studenti.Where(p => p.Specializare == specializari).ToList();
           var studentVarsta = student.Max(p => p.Varsta);
            return student.Where(p => p.Varsta == studentVarsta).First();
                    
        }

        public Student CelMaiMicStudent()
        {
            var studentVarsta = _studenti.Min(p => p.Varsta);
           return _studenti.Where(p => p.Varsta == studentVarsta).FirstOrDefault();
        }

        public List<Student> AfisareStudentiLitereCrescatorVarstei(Specializari specializari)
        {
            return _studenti.Where(p => p.Specializare == specializari).OrderBy(p => p.Varsta).ToList();
        }

        public Student AfisarePrimulStudentConstructiiCuVarstaPeste(Specializari specializari)
        {
            return _studenti.Where(p => p.Specializare == specializari && p.Varsta > 20).FirstOrDefault();
        }

        public List<Student> AfisareStudentiCuVarstaMedie()
        {
            var varstaMedie = _studenti.Average(p => p.Varsta);
            return _studenti.FindAll(p => p.Varsta == varstaMedie).ToList();
        }

        /*Afisati, in ordinea descrescatoare a varstei,si in ordine alfabetica, dupa numele de
            familie si dupa numele mic, toti studentii cu varsta cuprinsa intre 18 si 35 de ani*/

        public List<Student> AfisareStudenti()
        {
            return _studenti.Where(p => p.Varsta > 18 && p.Varsta < 35)
                .OrderBy(p => p.Nume)
                .OrderByDescending(p => p.Varsta).ToList();
        }

        public Student AfisareUltimulStudent()
        {
            return _studenti.LastOrDefault();
        }

        public string AfisareMinori()
        {
            var studenti = _studenti.Where(p => p.Varsta < 18).ToList();
            if (studenti.Count > 0)
            {
                return "Exista minori";
            }

            return "Nu exista minori";
        }
    }
}
