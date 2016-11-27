using System;
using System.Collections.Generic;

namespace UnderstandingExtensionMethods.Net
{
    class Criteres
    {
        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public List<int> ListeIntegers { get; set; }

        public Criteres(DateTime dateDebut, DateTime dateFin, params int[] listeIntegers)
        {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.ListeIntegers = new List<int>(listeIntegers);
        }
        
        public string[] ToParamArray()
        {
            return new string[] { "DateDebut = " + this.DateDebut.ToString("yyyy-MM-dd"),
                                  "DateFin = " + this.DateFin.ToString("yyyy-MM-dd"), 
                                  "ListeIntegers = " + string.Join(", ", this.ListeIntegers.ToArray())};
        }

    }
}
