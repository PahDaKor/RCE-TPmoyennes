using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    internal class Classe
    {
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }
        public string nomClasse {  get; private set; }
        private readonly static int maxMatiere = 10;
        private readonly static int maxEleve = 30;


        public Classe(string nomClasse)
        {
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
            this.nomClasse = nomClasse;
        }

        public void ajouterEleve(string prenom, string nom)
        {
            if (this.eleves.Count == maxEleve)
            {
                throw new Exception("Classe, nombre d'eleve max atteint");
            }
            this.eleves.Add(new Eleve(prenom, nom));
        }

        public void ajouterMatiere(string matiere)
        {
            if (this.matieres.Count == maxMatiere)
            {
                throw new Exception("Classe, nombre de matiere max atteint");
            }
            this.matieres.Add(matiere);
        }

        public double moyenneMatiere(int matiere) {
            if(!this.eleves.Any()) throw new Exception("Classe, pas d'eleve");
            double somme = 0;
            foreach(Eleve eleve in this.eleves)
            {
                somme += eleve.moyenneMatiere(matiere);
            }
            return Math.Truncate(100 * somme/this.eleves.Count)/100;
        }

        public double moyenneGeneral()
        {
            if (!this.eleves.Any()) throw new Exception("Classe, pas d'eleve");
            double somme = 0;
            for (int matiere = 0; matiere < this.matieres.Count; matiere++)
            {
                somme += this.moyenneMatiere(matiere);
            }
            return Math.Truncate(100 * somme/this.matieres.Count)/100;
        }

    }
}

