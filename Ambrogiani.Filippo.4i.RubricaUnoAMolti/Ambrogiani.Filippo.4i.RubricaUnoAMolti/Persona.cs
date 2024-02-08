using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrogiani.Filippo._4i.Rubrica
{
    public class Persona
    {
        public int idPersona { get; set; } //è un ID o anche detto chiave primaria
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Persona()
        {
            idPersona = 1;
        }

        public Persona(string riga)
        {
            string[] Campi = riga.Split(";"); //divido una riga csv
            if (Campi.Count() != 3)
                throw new Exception("Le righe del file Persone.csv devono essere di 3 colonne");

            int id = 0;
            int.TryParse(Campi[0], out id); //converto la stringa in un numero
            idPersona = id;

            this.Nome = Campi[1];
            this.Cognome = Campi[2];

        }
    }
}
