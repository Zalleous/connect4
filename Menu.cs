/*

*/
namespace connect4;
class Menu
{

    public static void Titre()
    {
        const string TITRE = "Connect 4 par Zachary Dubois";
        const int TAB_NUM = 4;
        const char TAB_CHAR = ' ';
        const char SEP_CHAR = '-';
        string tab = new string(TAB_CHAR, TAB_NUM);
        string sep = new string(SEP_CHAR, TAB_NUM + TITRE.Length + TAB_NUM);
        
        Console.WriteLine(sep);
        Console.WriteLine($"{tab}{TITRE}{tab}");
        Console.WriteLine(sep);
    }

    public static void Grille()
    {
        const char CHAR_HOR = '-';
        const char CHAR_VER = '|';
        const char ESPACE = ' ';
        const int COL_NUM = 7; // 7 columns
        const int RAN_NUM = 6; // 6 rows

        char[] tableau = new char[42];

        for (int i = 0; i < tableau.Length; i++)
        {
            tableau[i] = ESPACE;
        }

        int iterations = 0;
        // Print the grid
        for (int i = 0; i < RAN_NUM; i++)
        {
            // Print the top separator line (horizontal line between rows)
            for (int j = 0; j < COL_NUM; j++)
            {
                Console.Write($"{CHAR_HOR}{CHAR_HOR}{CHAR_HOR}"); // Horizontal bars
            }
            Console.WriteLine(); // Right vertical bar

            // Print the vertical bars with one space in the middle of the cell
            for (int j = 0; j < COL_NUM; j++)
            {
                Console.Write($"{CHAR_VER}{tableau[iterations]}{CHAR_VER}"); // One space in the middle of the cell
            }
            Console.WriteLine(); // Right vertical bar

            iterations++;
        }

        // Print the bottom separator line after the last row
        for (int j = 0; j < COL_NUM; j++)
        {
            Console.Write($"{CHAR_HOR}{CHAR_HOR}{CHAR_HOR}"); // Horizontal bars
        }
        Console.WriteLine(); // Right vertical bar
    }


}
