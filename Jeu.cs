namespace Connect4
{
    /// <summary>
    /// Classe contenant la logique métier du jeu
    /// </summary>
    class Jeu
    {
        /// <summary>
        /// Vérifie si le dernier joueur a aligné 4 jetons
        /// </summary>
        /// <param name="grille">Tableau 2D représentant l'état du jeu</param>
        /// <param name="joueur">Numéro du joueur à vérifier (1 ou 2)</param>
        /// <returns>True si victoire détectée, sinon False</returns>
        public static bool VerifierVictoire(char[,] grille, int joueur)
        {
            const int AlignementVictoire = 4;
            char jeton = (joueur == 1) ? 'X' : 'O';
            int lignes = grille.GetLength(0);
            int colonnes = grille.GetLength(1);

            // Vérification horizontale
            for (int ligne = 0; ligne < lignes; ligne++)
            {
                for (int colonne = 0; colonne <= colonnes - AlignementVictoire; colonne++)
                {
                    if (VerifierAlignement(grille, jeton, ligne, colonne, 0, 1))
                        return true;
                }
            }

            // Vérification verticale
            for (int ligne = 0; ligne <= lignes - AlignementVictoire; ligne++)
            {
                for (int colonne = 0; colonne < colonnes; colonne++)
                {
                    if (VerifierAlignement(grille, jeton, ligne, colonne, 1, 0))
                        return true;
                }
            }

            // Diagonale descendante (\) 
            for (int ligne = 0; ligne <= lignes - AlignementVictoire; ligne++)
            {
                for (int colonne = 0; colonne <= colonnes - AlignementVictoire; colonne++)
                {
                    if (VerifierAlignement(grille, jeton, ligne, colonne, 1, 1))
                        return true;
                }
            }

            // Diagonale ascendante (/) 
            for (int ligne = AlignementVictoire - 1; ligne < lignes; ligne++)
            {
                for (int colonne = 0; colonne <= colonnes - AlignementVictoire; colonne++)
                {
                    if (VerifierAlignement(grille, jeton, ligne, colonne, -1, 1))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Vérifie si la grille est complètement remplie
        /// </summary>
        /// <param name="grille">Tableau 2D à vérifier</param>
        /// <returns>True si la grille est pleine</returns>
        public static bool GrillePleine(char[,] grille)
        {
            const char CaseVide = ' ';
            foreach (char cellule in grille)
            {
                if (cellule == CaseVide)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Vérifie un alignement de 4 jetons dans une direction donnée
        /// </summary>
        /// <param name="grille">Grille de jeu</param>
        /// <param name="jeton">Jeton à vérifier</param>
        /// <param name="ligneDebut">Ligne de départ</param>
        /// <param name="colonneDebut">Colonne de départ</param>
        /// <param name="deltaLigne">Direction verticale (0 ou 1)</param>
        /// <param name="deltaColonne">Direction horizontale (0 ou 1)</param>
        /// <returns>True si alignement détecté</returns>
        private static bool VerifierAlignement(
            char[,] grille, 
            char jeton, 
            int ligneDebut, 
            int colonneDebut, 
            int deltaLigne, 
            int deltaColonne)
        {
            const int AlignementVictoire = 4;
            
            for (int i = 0; i < AlignementVictoire; i++)
            {
                int ligne = ligneDebut + i * deltaLigne;
                int colonne = colonneDebut + i * deltaColonne;
                
                if (grille[ligne, colonne] != jeton)
                    return false;
            }
            return true;
        }
    }
}