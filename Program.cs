namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const int ColNum = 7;
            const int RanNum = 6;   
            const char Espace = ' ';
            char[,] tableau = new char[RanNum, ColNum];

            // Initialisation de la grille avec des espaces vides
            for (int i = 0; i < RanNum; i++)
            {
                for (int j = 0; j < ColNum; j++)
                {
                    tableau[i, j] = Espace;
                }
            }

            int joueur = 1; // Joueur actuel (1 ou 2)
            char action;     // Choix de colonne du joueur

            do
            {
                Console.Clear();
                // Affichage de l'interface
                Menu.AfficherTitre();
                Menu.AfficherGrille(tableau);
                
                // Récupération de l'action du joueur
                action = Menu.DemanderAction(joueur);

                // Traitement de la colonne sélectionnée
                if (char.ToLower(action) >= 'a' && char.ToLower(action) <= 'g')
                {
                    int col = char.ToLower(action) - 'a'; // Conversion lettre -> index
                    bool jetonPlace = false;

                    // Placement du jeton
                    for (int row = RanNum - 1; row >= 0; row--)
                    {
                        if (tableau[row, col] == Espace)
                        {
                            tableau[row, col] = (joueur == 1) ? 'X' : 'O';
                            jetonPlace = true;
                            break;
                        }
                    }

                    // Gestion colonne pleine
                    if (!jetonPlace)
                    {
                        Console.WriteLine("La colonne est pleine, essayez une autre.");
                        Console.ReadKey();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Entrée invalide. Veuillez entrer une colonne entre A et G.");
                    Console.ReadKey();
                    continue;
                }

                // Vérification fin de partie
                if (Jeu.VerifierVictoire(tableau, joueur))
                {
                    Console.Clear();
                    Menu.AfficherTitre();
                    Menu.AfficherGrille(tableau);
                    Console.WriteLine($"Le joueur {joueur} a gagné ! Appuyez sur une touche pour quitter.");
                    Console.ReadKey();
                    break;
                }

                if (Jeu.GrillePleine(tableau))
                {
                    Console.Clear();
                    Menu.AfficherTitre();
                    Menu.AfficherGrille(tableau);
                    Console.WriteLine("Match nul ! Appuyez sur une touche pour quitter.");
                    Console.ReadKey();
                    break;
                }

                // Changement de joueur
                joueur = joueur == 1 ? 2 : 1;

            } while (true); // Boucle principale jusqu'à fin de partie
        }
    }
}