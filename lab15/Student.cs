using System;

namespace lab15
{
    public class Student
    {
        public Guid Id { get;  set; } = Guid.NewGuid();
        public string Nume { get;  set; }
        public string Prenume { get;  set; }
        public decimal Varsta { get;  set; }
        public Specializari Specializare { get; set; }


        public override string ToString()
        {
            return $"{Id} , {Nume}, {Prenume}, {Varsta}, {Specializare}";
        }
    }
}
