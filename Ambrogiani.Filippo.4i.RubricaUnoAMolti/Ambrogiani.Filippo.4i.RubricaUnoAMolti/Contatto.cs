using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrogiani.Filippo._4i.Rubrica
{
    public enum TipoContatto { nessuno, Email, Telefono, Web, Instagram, Facebook, Cellulare}
    public class Contatto
    {
        public int idPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Valore { get; set; }


        public Contatto()
        {
            Tipo = TipoContatto.nessuno;
        }

        public Contatto(string riga)
        {
            string[] Campi = riga.Split(";"); //divido una riga csv

            int id = 0;
            int.TryParse(Campi[0], out id);
            idPersona = id;

            TipoContatto c;
            Enum.TryParse(Campi[1], out c);
            this.Tipo = c;

            this.Valore = Campi[2];

        }
    }
}
