using System;
using System.Collections.Generic;
using System.Text;

namespace Antibio.Models
{
    public class Antibio

    {
        public string nomAntibio { get; set; }
        public string unite { get; set; }
        //public Categorie laCateg { get; set; }
        public int nombre_par_jour { get; set; }

        public float dose_kilo { get; set; }
        public float dose_prise { get; set; }

        //public Antibio(string pLibelle, string pUnite, Categorie pCategorie, int pNombre)
        public Antibio(string unNom,string uneUnite, int unNombre,float uneDosePrise, float uneDoseKilo)
        {
            this.nomAntibio = unNom;
            this.unite = uneUnite;
            this.dose_prise = uneDosePrise;
            this.dose_kilo = uneDoseKilo;
            //this.laCateg = pCategorie;
            this.nombre_par_jour = unNombre;
        }
        //public string getLibelle()
        //{
        //    return this.libelle;
        //}
           // public string getUnite()
           // {
           //     return this.unite;
           //}
        //    public Categorie getCategorie()
        //    {
        //        return this.id_categorie;
        //    }
            // public int getNombre()
            //{
            //return this.nombre_par_jour;
            //}
        //public override string ToString()
        //       {
        //        return libelle + " " + laCateg;
        //      }
        //}
    }
}
