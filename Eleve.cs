using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    class Eleve{
        public string nom { get; private set; }
        public string prenom { get; private set; }
        private List<Note> note;
        private static int maxNote = 200;
        private Classe classe;
        private Dictionary<int,double> sommeNotes;
        private Dictionary<int, int> nbNotes;
        public Eleve(string prenom, string nom)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.note = new List<Note>();
            this.sommeNotes = new Dictionary<int, double>();
            this.nbNotes = new Dictionary<int, int>();

        }

        public void ajouterNote(Note note)
        {
            if (this.note.Count == maxNote)
            {
                throw new Exception("Nombre de note max deja atteint");
            }
            this.note.Add(note);

            if (this.sommeNotes.ContainsKey(note.matiere))
            {
                this.sommeNotes[note.matiere]+= (double)note.note;
                this.nbNotes[note.matiere]++;
            }
            else
            {
                this.sommeNotes.Add(note.matiere, (double)note.note);
                this.nbNotes.Add(note.matiere, 1);
            }
        }

        public double moyenneMatiere(int matiere)
        {
            if (!this.sommeNotes.ContainsKey(matiere)){
                throw new Exception();
            }else { 
                return Math.Truncate( 100 * this.sommeNotes[matiere] / this.nbNotes[matiere])/100;
            }
        }

        public double moyenneGeneral()
        {
            double somme = 0;
            int nb = sommeNotes.Keys.Count;
            foreach(int matiere in sommeNotes.Keys)
            {
                somme += moyenneMatiere(matiere);
            }
            return Math.Truncate(100 * (somme/nb)) / 100;
        }
    }
}
