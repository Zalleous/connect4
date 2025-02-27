namespace Connect4
{
    /// <summary>
    /// Classe responsable de l'affichage des éléments graphiques du jeu
    /// </summary>
    class Menu
    {
        /// <summary>
        /// Affiche le titre du jeu avec la signature du développeur
        /// </summary>
        public static void AfficherTitre()
        {
            const string TitreJeu = "Connect 4 par Zachary Dubois";
            const int NombreTabulations = 4;
            const char CaractereTabulation = ' ';
            const char CaractereSeparation = '-';
            
            string tabulations = new string(CaractereTabulation, NombreTabulations);
            string separation = new string(CaractereSeparation, TitreJeu.Length + (NombreTabulations * 2));
            
            Console.WriteLine(separation);
            Console.WriteLine($"{tabulations}{TitreJeu}{tabulations}");
            Console.WriteLine(separation);
        }

        /// <summary>
        /// Affiche la grille de jeu actuelle
        /// </summary>
        /// <param name="grille">Tableau 2D représentant l'état du jeu</param>
        public static void AfficherGrille(char[,] grille)
        {
            const char CharHorizontal = '-';
            const char CharVertical = '|';
            const char Espace = ' ';
            
            int nombreColonnes = grille.GetLength(1);
            int nombreRangees = grille.GetLength(0);

            // Affichage des en-têtes de colonnes (A-G)
            for (int i = 0; i < nombreColonnes; i++)
            {
                Console.Write($"{Espace}{(char)('A' + i)}");
            }
            Console.WriteLine();

            // Affichage du contenu de la grille
            for (int i = 0; i < nombreRangees; i++)
            {
                // Ligne horizontale
                for (int j = 0; j < nombreColonnes; j++)
                {
                    Console.Write($"{CharHorizontal}{CharHorizontal}");
                }
                Console.WriteLine(CharHorizontal);

                // Contenu des cellules
                for (int j = 0; j < nombreColonnes; j++)
                {
                    Console.Write($"{CharVertical}{grille[i, j]}");
                }
                Console.WriteLine(CharVertical);
            }

            // Dernière ligne horizontale
            for (int j = 0; j < nombreColonnes; j++)
            {
                Console.Write($"{CharHorizontal}{CharHorizontal}");
            }
            Console.WriteLine(CharHorizontal);
        }

        /// <summary>
        /// Demande et retourne l'action du joueur
        /// </summary>
        /// <param name="joueur">Numéro du joueur actuel (1 ou 2)</param>
        /// <returns>Caractère représentant la colonne choisie</returns>
        public static char DemanderAction(int joueur)
        {
            Console.Write($"Au tour du joueur {joueur} de jouer.\nEntrez une colonne (A-G) : ");
            ConsoleKeyInfo saisie = Console.ReadKey();
            return char.ToLower(saisie.KeyChar); // Conversion en minuscule
        }
    }
}