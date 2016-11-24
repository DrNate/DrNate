using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Media;
using System.Windows.Controls;

namespace Mow
{

    public class Vache
    {
        /// <summary>
        /// Indique la valeur de la carte, c'est à dire son identité principale.
        /// De 0 à 16
        /// </summary>
        public virtual int Valeur { get; private set; }

        /// <summary>
        /// Indique le nombre de mouches présente sur la carte.
        /// De 0 à 5
        /// </summary>
        public virtual int nb_mouches { get; private set; }
        
        public virtual ImageSource Portrait { get; private set; }

        /// <summary>
        /// Indique la catégorie de vache à laquelle correspond la carte
        /// - standard
        /// - acrobate (7 et 9, elles se mettent par dessus un 7 ou un 9 respectivement), il n'y en a que 2, une de chaque
        /// - retardataire (<> elle se met à la place de n'importe quel valeur entre deux valeurs ex: 2 entre 1 et 3), il n'y en a que 2
        /// - serre-file (0 et 16) il n'y en qu'une de chaque
        /// </summary>
        public virtual ECategorieVache Categorie { get; private set; }

        /// <summary>
        /// 48 cartes différentes
        /// </summary>
        public List<Vache> deck { get; set; }

        /// <summary>
        /// Creation :
        /// - 15 cartes vaches (numérotées de 1 à 15), avec 0 mouche
        /// - 13 cartes vaches (numérotées de 2 à 14), avec 1 mouche
        /// - 11 cartes vaches (numérotées de 3 à 13), avec 2 mouches
        /// - 3 cartes vaches (numérotées 7, 8, 9), avec 3 mouches
        /// </summary>
        public List<Vache> creerdeck()
        {
            List<Vache> deck = new List<Vache>();

            for (int i = 1; i < 16; i++)
            {
                deck.Add(new Vache() { Valeur = i, nb_mouches = 0, Categorie = ECategorieVache.Standard, image = ? });
            }

            for (int i = 2; i < 15; i++)
            {
                deck.Add(new Vache() { Valeur = i, nb_mouches = 1, Categorie = ECategorieVache.Standard });
            }

            for (int i = 3; i < 14; i++)
            {
                deck.Add(new Vache() { Valeur = i, nb_mouches = 2, Categorie = ECategorieVache.Standard });
            }

            for (int i = 7; i < 10; i++)
            {
                deck.Add(new Vache() { Valeur = i, nb_mouches = 3, Categorie = ECategorieVache.Standard });
            }
            
            /// <summary>
            /// 6 cartes vaches spéciales, avec 5 mouches
            /// - 2 serre-files
            /// - 2 vaches acrobates
            /// - 2 vaches retardataires
            /// </summary>
            deck.Add(new Vache() { Valeur = 0, nb_mouches = 5, Categorie = ECategorieVache.SerreFile });
            deck.Add(new Vache() { Valeur = 16, nb_mouches = 5, Categorie = ECategorieVache.SerreFile });

            deck.Add(new Vache() { Valeur = 7, nb_mouches = 5, Categorie = ECategorieVache.Acrobate });
            deck.Add(new Vache() { Valeur = 9, nb_mouches = 5, Categorie = ECategorieVache.Acrobate });

            deck.Add(new Vache() { Valeur = 0, nb_mouches = 5, Categorie = ECategorieVache.Retardataire });
            deck.Add(new Vache() { Valeur = 0, nb_mouches = 5, Categorie = ECategorieVache.Retardataire });

            return deck;
        }

        /// <summary>
        /// Methode Shuffle : mélange une liste aléatoirement
        /// </summary>
        /// <typeparam name="T">Objet de type "Vache" avec trois propriétés ( Valeur - nb_mouches - Categorie )</typeparam>
        /// <param name="list">Liste (deck, pioche, paquet ...) à mélanger</param>
        public void Shuffle<T>(IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}