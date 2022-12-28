using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ListManager.Models
{
    public class Lista
    {
        public int ID { get; set; }
        public bool Completed { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime prazo { get; set; }
        public IdentityUser UserID { get; set; }
        public List<Afazeres> Afazares { get; set; }
        

        public Lista() 
            {

            }
    }

    public class Afazeres
    {
        public int ID { get; set; }
        public bool Completed { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public DateTime prazo { get; set; }
    }
}
