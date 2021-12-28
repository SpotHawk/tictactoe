using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    class Program
    {
        static string[] jatekelem = {"X", "O" };
        static string[,] tabla = new string[3,3];
        static int sor;
        static int oszlop;
        static int elsoj;
        static int masodj;
        static string input = "";
        static bool tobbjatekos = false;
        static string player = jatekelem[elsoj];
        static string ai = jatekelem[1 - elsoj];
        static bool eredmeny = false;
        static void Main(string[] args)
        {
            bool jatek = true;
            //TTorles();
            Random random = new Random();
            do
            {
                TTorles();
                Jatekosv();
                if(tobbjatekos)
                {
                    do
                    {
                        Console.WriteLine("Melyikkel szeretne lenni az első játékos? (X/O)");
                        input = Console.ReadLine().ToUpper();
                        if (input == "X")
                        {
                            elsoj = 0;
                            masodj = 1;
                        }
                        else if (input == "O")
                        {
                            elsoj = 1;
                            masodj = 0;
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen lehetőség!");
                        }
                    }
                    while ((input!="X") && (input!="O"));
                    do
                    {
                        Console.WriteLine("Ki kezd? (1/2/R=random)");
                        input = Console.ReadLine().ToUpper();
                        if (input == "1")
                        {
                            Elsoj();
                            do
                            {
                                Masodj();
                                Elsoj();
                            }
                            while (Eredmeny() != true);
                        }
                        else if (input == "2")
                        {
                            Masodj();
                            do
                            {
                                Elsoj();
                                Masodj();
                            }
                            while (Eredmeny() != true);
                        }
                        else if (input == "R")
                        {
                            int kezd = random.Next(1, 3);
                            if (kezd == 1)
                            {
                                Elsoj();
                                do
                                {
                                    Masodj();
                                    Elsoj();
                                }
                                while (Eredmeny() != true);
                            }
                            else
                            {
                                Masodj();
                                do
                                {
                                    Elsoj();
                                    Masodj();
                                }
                                while (Eredmeny() != true);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen lehetőség!");
                        }
                    }
                    while (!eredmeny);

                    Console.WriteLine("Kilép? (Ha nem akkor új játék kezdődik) (I/N)");
                    input = Console.ReadLine().ToUpper();
                    if (input == "I")
                    {
                        jatek = false;
                    }
                }
                else //egyjátékos
                {
                    do
                    {
                        Console.WriteLine("Melyikkel szeretne lenni? (X/O)");
                        input = Console.ReadLine().ToUpper();
                        if (input=="X")
                        {
                            elsoj = 0;
                        }
                        else if(input=="O")
                        {
                            elsoj = 1;
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen lehetőség!");
                        }
                    }
                    while ((input != "X") && (input != "O"));
                    do
                    {
                        Console.WriteLine("Ki kezd? (1/C/R=random)");
                        input = Console.ReadLine().ToUpper();
                        if(input== "1")
                        {
                            Elsoj();
                            do
                            {
                                aiMove(tabla);
                                Elsoj();
                            }
                            while (Eredmeny() != true);
                        }
                        else if(input== "C")
                        {
                            aiMove(tabla);
                            do
                            {
                                Elsoj();
                                aiMove(tabla);
                            }
                            while (Eredmeny() != true);
                        }
                        else if (input == "R")
                        {
                            int kezd = random.Next(1, 3);
                            if (kezd == 1)
                            {
                                Elsoj();
                                do
                                {
                                    aiMove(tabla);
                                    Elsoj();
                                }
                                while (Eredmeny() != true);
                            }
                            else
                            {
                                aiMove(tabla);
                                do
                                {
                                    Elsoj();
                                    aiMove(tabla);
                                }
                                while (Eredmeny() != true);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nincs ilyen lehetőség!");
                        }
                    }
                    while (!eredmeny);
                    Console.WriteLine("Kilép? (Ha nem akkor új játék kezdődik) (I/N)");
                    input = Console.ReadLine().ToUpper();
                    if (input == "I")
                    {
                        jatek = false;
                    }
                }
            }
            while (jatek);
        }

        static void Jatekosv()
        {
            do
            {
                Console.WriteLine("Egy vagy többjátékos játékot szeretne játszani?(E/T)");
                input = Console.ReadLine().ToUpper();
                if (input == "E")
                {
                    tobbjatekos = false;
                }
                else if (input == "T")
                {
                    tobbjatekos = true;
                }
                else
                {
                    Console.WriteLine("Nincs ilyen lehetőség!");
                }
            }
            while ((input != "E") && (input != "T"));
        }

        static void Tabla()
        {
            for (int i=0;i<3;i++)
            {
                Console.WriteLine("-------------------");
                for (int j=0;j<4;j++)
                {
                    if (j==2)
                    {
                        if(i==0)
                        {
                            Console.WriteLine("|  " + tabla[0,0] + "  |  " + tabla[0,1] + "  |  " + tabla[0,2] + "  |");
                        }
                        else if(i==1)
                        {
                            Console.WriteLine("|  " + tabla[1,0] + "  |  " + tabla[1,1] + "  |  " + tabla[1,2] + "  |");
                        }
                        else
                        {
                            Console.WriteLine("|  " + tabla[2,0] + "  |  " + tabla[2,1] + "  |  " + tabla[2,2] + "  |");
                        }
                    }
                    Console.WriteLine("|     |     |     |");
                }
            }
            Console.WriteLine("-------------------");
        }

        static void Elsoj()
        {
            try
            {
                Console.WriteLine("Az első játékos melyik sorba szeretne rakni? (1/2/3)");
                sor = int.Parse(Console.ReadLine());
                Console.WriteLine("És melyik oszlopba szeretne rakni? (1/2/3)");
                oszlop = int.Parse(Console.ReadLine());
                while (tabla[sor - 1, oszlop - 1] != " ")
                {
                    Console.WriteLine("Ez a mező már foglalt kérem adjon meg egy másikat!");
                    Console.WriteLine("Az első játékos melyik sorba szeretne rakni? (1/2/3)");
                    sor = int.Parse(Console.ReadLine());
                    Console.WriteLine("És melyik oszlopba szeretne rakni? (1/2/3)");
                    oszlop = int.Parse(Console.ReadLine());
                }
                tabla[sor - 1, oszlop - 1] = jatekelem[elsoj];
                Tabla();
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Nincs ilyen mező!");
                Elsoj();
            }
        }

        static void Masodj()
        {
            try
            {
                Console.WriteLine("A második játékos melyik sorba szeretne rakni? (1/2/3)");
                sor = int.Parse(Console.ReadLine());
                Console.WriteLine("És melyik oszlopba szeretne rakni? (1/2/3)");
                oszlop = int.Parse(Console.ReadLine());
                while (tabla[sor - 1, oszlop - 1] != " ")
                {
                    Console.WriteLine("Ez a mező már foglalt kérem adjon meg egy másikat!");
                    Console.WriteLine("A második játékos melyik sorba szeretne rakni? (1/2/3)");
                    sor = int.Parse(Console.ReadLine());
                    Console.WriteLine("És melyik oszlopba szeretne rakni? (1/2/3)");
                    oszlop = int.Parse(Console.ReadLine());
                }
                tabla[sor - 1, oszlop - 1] = jatekelem[masodj];
                Tabla();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Nincs ilyen mező!");
                Masodj();
            }
        }

        static void TTorles()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabla[i, j] = " ";
                }
            }
        }

        static bool Eredmeny()
        {
            eredmeny = false;
            //elso sor
            if ((tabla[0,0]!=" ")&&(tabla[0,0]==tabla[0,1])&&(tabla[0,1]==tabla[0,2]))
            {
                eredmeny = true;
                if (tabla[0,0]=="X")
                {
                    if (elsoj==0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            //masodik sor
            else if ((tabla[1, 0] != " ") && (tabla[1, 0] == tabla[1, 1]) && (tabla[1, 1] == tabla[1, 2]))
            {
                eredmeny = true;
                if (tabla[1, 0] == "X")
                {
                    if (elsoj == 0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            //harmadik sor
            else if ((tabla[2, 0] != " ") && (tabla[2, 0] == tabla[2, 1]) && (tabla[2, 1] == tabla[2, 2]))
            {
                eredmeny = true;
                if (tabla[2, 0] == "X")
                {
                    if (elsoj == 0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            //elso oszlop
            else if ((tabla[0, 0] != " ") && (tabla[0, 0] == tabla[1,0]) && (tabla[1, 0] == tabla[2, 0]))
            {
                eredmeny = true;
                if (tabla[0, 0] == "X")
                {
                    if (elsoj == 0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            //masodik oszlop
            else if ((tabla[0, 1] != " ") && (tabla[0, 1] == tabla[1, 1]) && (tabla[1, 1] == tabla[2, 1]))
            {
                eredmeny = true;
                if (tabla[0, 1] == "X")
                {
                    if (elsoj == 0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            //harmadik oszlop
            else if ((tabla[0, 2] != " ") && (tabla[0, 2] == tabla[1, 2]) && (tabla[1, 2] == tabla[2, 2]))
            {
                eredmeny = true;
                if (tabla[0, 2] == "X")
                {
                    if (elsoj == 0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            //perjel
            else if ((tabla[0, 0] != " ") && (tabla[0, 0] == tabla[1, 1]) && (tabla[1, 1] == tabla[2, 2]))
            {
                eredmeny = true;
                if (tabla[0, 0] == "X")
                {
                    if (elsoj == 0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            //vissza perjel
            else if ((tabla[0, 2] != " ") && (tabla[0, 2] == tabla[1, 1]) && (tabla[1, 1] == tabla[2, 0]))
            {
                eredmeny = true;
                if (tabla[0, 2] == "X")
                {
                    if (elsoj == 0)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
                else
                {
                    if (elsoj == 1)
                    {
                        Console.WriteLine("Az első játékos nyert!");
                    }
                    else
                    {
                        Console.WriteLine("A második játékos nyert!");
                    }
                }
            }
            else
            {
                int valami = 0;
                for (int i=0;i<3;i++)
                {
                    for (int j=0;j<3;j++)
                    {
                        if(tabla[i,j]!=" ")
                        {
                            valami++;
                        }
                    }
                }
                if(valami==9)
                {
                    Console.WriteLine("Döntetlen!");
                    eredmeny = true;
                }
            }
            return eredmeny;
        }
        
        static bool isMoveLeft(string[,] t)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (t[i,j]==" ")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static int evaluate(string[,] t)
        {
            player = jatekelem[elsoj];
            ai = jatekelem[1 - elsoj];
            //soronkent
            for (int i = 0; i < 3; i++)
            {
                if (t[i,0] == t[i,1] && t[i,1]==t[i,2])
                {
                    if (t[i,0]==player)
                    {
                        return -10;
                    }
                    else if(t[i,0]==ai)
                    {
                        return 10;
                    }
                }
            }
            //oszloponkent
            for (int i = 0; i < 3; i++)
            {
                if (t[0, i] == t[1, i] && t[1, i] == t[2, i])
                {
                    if (t[0, i] == player)
                    {
                        return -10;
                    }
                    else if (t[0, i] == ai)
                    {
                        return 10;
                    }
                }
            }

            //keresztbe
            if (t[0, 0] == t[1, 1] && t[1, 1] == t[2, 2])
            {
                if (t[0, 0] == player)
                    return -10;
                else if (t[0, 0] == ai)
                    return +10;
            }

            if (t[0, 2] == t[1, 1] && t[1, 1] == t[2, 0])
            {
                if (t[0, 2] == player)
                    return -10;
                else if (t[0, 2] == ai)
                    return +10;
            }

            return 0;
        }

        static int minimax(string[,] t,int depth,bool isMaximiser)
        {
            int score = evaluate(t);

            if (score==10)
            {
                return score;
            }

            if (score == -10)
            {
                return score;
            }

            if (!isMoveLeft(t))
            {
                return 0;
            }

            if (isMaximiser)
            {
                int best = -1000;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabla[i, j] == " ")
                        {
                            t[i, j] = ai;
                            best = Math.Max(best, minimax(t, depth + 1, !isMaximiser));
                            t[i, j] = " ";
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (t[i, j] == " ")
                        {
                            t[i, j] = player;
                            best = Math.Min(best, minimax(t, depth + 1, !isMaximiser));
                            t[i, j] = " ";
                        }
                    }
                }
                return best;
            }
        }

        class Move
        {
            public int row, col;
        }

        static Move findbBestMove(string[,] t)
        {
            int bestVal = -1000;
            Move bestMove = new Move();
            bestMove.row=-1;
            bestMove.col = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (t[i, j] == " ")
                    {
                        t[i, j] = ai;

                        int moveVal = minimax(t, 0, false);

                        t[i, j] = " ";
                        if (moveVal > bestVal)
                        {
                            bestMove.row = i;
                            bestMove.col = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }

            return bestMove;
        }

        static void aiMove(string [,] t)
        {
            Move bm = findbBestMove(t);
            t[bm.row, bm.col]=ai;
            Console.WriteLine("A számítógép lépett.");
            Tabla();
        }
    }
}
