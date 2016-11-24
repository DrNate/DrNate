using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mow
{



    /// <summary>
    /// Classe correspondant à un ensemble de carte.
    /// Peut être "Main", "Etable", "Pioche", "Deck" ou "Troupeau".
    /// Implémente les méthodes et propriétés communes permettant l'évolution de l'ensemble au fil du jeu.
    /// 
    /// </summary>
    public abstract class EnsembleCarte
    {
        /// <summary>
        /// Collection générique contenant le type Vache.
        /// La contenance maximale est précisée par la propriété max_cartes.
        /// </summary>
        public virtual List<Vache> Cartes { get; set; }

        /// <summary>
        /// Précise le nombre maximum de cartes que la List Cartes peut contenir.
        /// </summary>
        public virtual int max_cartes { get; set; }

        public virtual IEnumerable<Vache> Carte { get; set; }

        public virtual bool Est_vide()
        {
            throw new System.NotImplementedException();
        }

        public virtual int CompterMouches()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Vider()
        {
            throw new System.NotImplementedException();
        }

        public virtual void AjouterCarte(Vache carte)
        {
            throw new System.NotImplementedException();
        }

        public virtual void RetirerCarte(Vache carte)
        {
            throw new System.NotImplementedException();
        }

    }
}