using System;
using System.Collections.Generic;
using System.IO;
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

            if (Campi.Count() != 3)
                throw new Exception("Le righe del file Contatti.csv devono essere di 3 colonne");

            int id = 0;
            int.TryParse(Campi[0], out id);
            idPersona = id;

            TipoContatto c;
            Enum.TryParse(Campi[1], out c);
            this.Tipo = c;

            this.Valore = Campi[2];
        }
        public static Contatto MakeContatto(string riga)
        {
            string[] Campi = riga.Split(";"); //divido una riga csv

            TipoContatto c;
            Enum.TryParse(Campi[1], out c);
            switch (c)
            {
                case TipoContatto.Email:
                    return new ContattoEmail(riga);
                    break;
                case TipoContatto.Cellulare:
                    return new ContattoCellulare(riga);
                    break;
                case TipoContatto.Telefono:
                    return new ContattoTelefono(riga);
                    break;
                case TipoContatto.Facebook:
                    return new ContattoFacebook(riga);
                    break;
                case TipoContatto.Instagram:
                    return new ContattoInstagram(riga);
                    break;
                case TipoContatto.Web:
                    return new ContattoWeb(riga);
                    break;
            }
            return new Contatto(riga);
        }

    }

    public class Contatti:List<Contatto>
    {
        public Contatti() { }
        public Contatti(string nomeFile)
        {
            //leggi contatti
            StreamReader fin = new StreamReader("Contatti.csv");
            fin.ReadLine();
            while (!fin.EndOfStream)
            {
                Add( Contatto.MakeContatto( fin.ReadLine() ));
            }
            fin.Close();
        }

    }

    public class ContattoEmail : Contatto //eredita da contatto
    {
        public ContattoEmail() { }
        public ContattoEmail(string riga)
            : base(riga) //chiamo il costruttore base
        {

        }
    }
    public class ContattoCellulare : Contatto //eredita da contatto
    {
        public ContattoCellulare() { }
        public ContattoCellulare(string riga)
            : base(riga) //chiamo il costruttore base
        {

        }
    }
    public class ContattoTelefono : Contatto
    {
        public ContattoTelefono() { }
        public ContattoTelefono(string riga)
            :base(riga)
        {

        }
    }
    public class ContattoFacebook : Contatto
    {
        public ContattoFacebook() { }
        public ContattoFacebook(string riga)
            : base(riga)
        {

        }
    }

    public class ContattoInstagram : Contatto
    {
        public ContattoInstagram() { }
        public ContattoInstagram(string riga)
            : base(riga)
        {

        }
    }
    public class ContattoWeb : Contatto
    {
        public ContattoWeb() { }
        public ContattoWeb(string riga)
            : base(riga)
        {

        }
    }
}
