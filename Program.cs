using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Speech.Synthesis;
using System.Threading.Tasks;


namespace CampoMinato
{
    class Program
    {
        //Stampa il campo aggiornato
        static void Stampa(Tessera[,] griglia)
        {
            Console.Clear();
            for (int i = 0; i < griglia.GetLength(0); i++)
            {
                for (int j = 0; j < griglia.GetLength(1); j++)
                {
                    if (griglia[i, j].CellaScoperta == false)
                    {
                        if (griglia[i, j].Bandiera == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("[■]");
                        }
                        else
                        {
                            Console.Write("[");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("F");
                            Console.ResetColor();
                            Console.Write("]");
                        }
                    }
                    else
                    {
                        if (griglia[i, j].Bomba == true)
                        {
                            Console.Write("[");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("*");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("]");
                            Console.Beep(1000, 1000);
                            Console.Beep(800, 1000);
                            Console.Beep(500, 800);
                            SpeechSynthesizer voice = new SpeechSynthesizer();
                            voice.Speak("Game Over.");
                            //////////////////////////////////////////////////////////////////////////////
                        }
                        else if (griglia[i, j].BombeAdiacenti != 0)
                        {
                            if (griglia[i, j].BombeAdiacenti == 1)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                            if (griglia[i, j].BombeAdiacenti == 2)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                            if (griglia[i, j].BombeAdiacenti == 3)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                            if (griglia[i, j].BombeAdiacenti == 4)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                            if (griglia[i, j].BombeAdiacenti == 5)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                            if (griglia[i, j].BombeAdiacenti == 6)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                            if (griglia[i, j].BombeAdiacenti == 7)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                            if (griglia[i, j].BombeAdiacenti == 8)
                            {
                                Console.Write("[");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write(griglia[i, j].BombeAdiacenti);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("]");
                            }
                        }
                        else
                        {
                            Console.Write("[ ]");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        //calcola le bombe adiacenti rispetto alla posizione dell'utente
        static void BombeAd(Tessera[,] Griglia)
        {
            for (int i = 0; i < Griglia.GetLength(0); i++)
            {
                for (int j = 0; j < Griglia.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        if (Griglia[i + 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (i == 0 && j == Griglia.GetLength(1) - 1)
                    {
                        if (Griglia[i + 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (j == Griglia.GetLength(1) - 1 && i == Griglia.GetLength(0) - 1)
                    {
                        if (Griglia[i - 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (i == 0 && j == Griglia.GetLength(1) - 1)
                    {
                        if (Griglia[i - 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (i == 0 && j < Griglia.GetLength(1) - 1 && j > 0)
                    {
                        if (Griglia[i + 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (j == 0 &&  i > 0 && i < Griglia.GetLength(0) - 1 )
                    {
                        if (Griglia[i + 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (i == Griglia.GetLength(0) - 1 && j > 0 && j < Griglia.GetLength(1) - 1)
                    {
                        if (Griglia[i - 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (i > 0 && i < Griglia.GetLength(0) - 1 && j == Griglia.GetLength(1) - 1)
                    {
                        if (Griglia[i - 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                    else if (i != 0 && i != Griglia.GetLength(0) - 1 && j != 0 && j != Griglia.GetLength(1) - 1)
                    {
                        if (Griglia[i - 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i - 1, j + 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                        if (Griglia[i + 1, j - 1].Bomba == true)
                            Griglia[i, j].BombeAdiacenti++;
                    }
                }
            }
        }
        //richiamo il metodo per lo sbiancamento
        static void LiberaCella(Tessera[,] griglia, int row, int col)
        {
            Sbianca(griglia, row, col);
        }
        //effettua lo sbiancamento delle celle 
        static void Sbianca(Tessera[,] griglia, int row, int col)
        {
            if (griglia[row, col].CellaScoperta == false)
                griglia[row, col].CellaScoperta = true;
            else
                return;
            if (griglia[row, col].BombeAdiacenti == 0 && !griglia[row,col].Bomba)
            {
                if(row == 0 && col == 0)
                {
                    Sbianca(griglia,row + 1, col);
                    Sbianca(griglia,row, col + 1);
                    Sbianca(griglia,row + 1, col + 1);
                }
                else if (col == griglia.GetLength(1) - 1 && row == 0)
                {
                    Sbianca(griglia, row + 1, col);
                    Sbianca(griglia, row, col - 1);
                    Sbianca(griglia, row + 1, col - 1);
                }
                else if (row == griglia.GetLength(0) - 1 && col == griglia.GetLength(1) - 1)
                {
                    Sbianca(griglia, row - 1, col);
                    Sbianca(griglia, row, col - 1);
                    Sbianca(griglia, row - 1, col - 1);
                }
                else if (row == 0 && col == griglia.GetLength(1) - 1)
                {
                    Sbianca(griglia, row - 1, col);
                    Sbianca(griglia, row, col + 1);
                    Sbianca(griglia, row - 1, col + 1);
                }
                else if (row == 0 && col > 0 && col < griglia.GetLength(1) - 1)
                {
                    Sbianca(griglia, row + 1, col);
                    Sbianca(griglia, row + 1, col + 1);
                    Sbianca(griglia, row + 1, col - 1);
                    Sbianca(griglia, row, col + 1);
                    Sbianca(griglia, row, col - 1);
                }
                else if (row > 0 && row < griglia.GetLength(0) - 1 && col == 0)
                {
                    Sbianca(griglia, row + 1, col);
                    Sbianca(griglia, row - 1, col);
                    Sbianca(griglia, row + 1, col + 1);
                    Sbianca(griglia, row - 1, col + 1);
                    Sbianca(griglia, row, col + 1);
                }
                else if (row == griglia.GetLength(0) - 1 && col > 0 && col < griglia.GetLength(1) - 1)
                {
                    Sbianca(griglia, row - 1, col);
                    Sbianca(griglia, row, col + 1);
                    Sbianca(griglia, row, col - 1);
                    Sbianca(griglia, row - 1, col + 1);
                    Sbianca(griglia, row - 1, col + 1);
                }
                else if (row > 0 && row < griglia.GetLength(0) - 1 && col == griglia.GetLength(1) - 1)
                {
                    Sbianca(griglia, row - 1, col);
                    Sbianca(griglia, row + 1, col);
                    Sbianca(griglia, row + 1, col - 1);
                    Sbianca(griglia, row - 1, col - 1);
                    Sbianca(griglia, row, col - 1);
                }
                else if (row != 0 && row != griglia.GetLength(0) - 1 && col != 0 && col != griglia.GetLength(1) - 1)
                {
                    Sbianca(griglia, row - 1, col);
                    Sbianca(griglia, row + 1, col);
                    Sbianca(griglia, row, col - 1);
                    Sbianca(griglia, row, col + 1);
                    Sbianca(griglia, row - 1, col - 1);
                    Sbianca(griglia, row + 1, col + 1);
                    Sbianca(griglia, row + 1, col - 1);
                    Sbianca(griglia, row - 1, col + 1);
                }
            }
            else
            {
                return;
            }
        }
        //switch con le frecce e invio
        static void Mossa(Tessera[,] campo, int height, int width, int row, int col)
        {
            Stampa(campo);
            int posRow = 0;
            int posCol = 0;
            //int row = 0;
            //int col = 1;
            Console.SetCursorPosition(col, row);
            bool leggiTastitera = false;
            while (!leggiTastitera)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (posRow < height - 1)
                        {
                            Console.SetCursorPosition(col, row + 1);
                            row += 1;
                            posRow++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (row >= 1)
                        {
                            Console.SetCursorPosition(col, row - 1);
                            row -= 1;
                            posRow--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (col >= 4)
                        {
                            Console.SetCursorPosition(col - 3, row);
                            col -= 3;
                            posCol--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (posCol < width - 1)
                        {
                            Console.SetCursorPosition(col + 3, row);
                            col += 3;
                            posCol++;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        if (campo[posRow, posCol].CellaScoperta == false)
                        {
                            if (campo[posRow, posCol].Bandiera == false)
                            {
                                campo[posRow, posCol].Bandiera = true;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("F");
                            }
                            else
                            {
                                campo[posRow, posCol].Bandiera = false;
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (campo[posRow, posCol].Bandiera == false)
                        {
                            if (campo[posRow, posCol].CellaScoperta == false)
                                LiberaCella(campo, posRow, posCol);
                            Stampa(campo);
                        }
                        //Stampa(campo);
                        break;
                }
            }
        }
        //mossa che precede la generazione casuale delle bombe
        static void MossaGeneraBomba(Tessera[,] griglia, int height, int width)
        {
            Stampa(griglia);
            int posRow = 0;
            int posCol = 0;
            int row = 0;
            int col = 1;
            Console.SetCursorPosition(col, row);
            bool enterPress = false;
            while (!enterPress)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (posRow < height - 1)
                        {
                            Console.SetCursorPosition(col, row + 1);
                            row += 1;
                            posRow++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (row >= 1)
                        {
                            Console.SetCursorPosition(col, row - 1);
                            row -= 1;
                            posRow--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (col >= 4)
                        {
                            Console.SetCursorPosition(col - 3, row);
                            col -= 3;
                            posCol--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (posCol < width - 1)
                        {
                            Console.SetCursorPosition(col + 3, row);
                            col += 3;
                            posCol++;
                        }
                        break;
                    case ConsoleKey.B:
                        if (griglia[posRow, posCol].CellaScoperta == false)
                        {
                            if (griglia[posRow, posCol].Bandiera == true)
                                griglia[posRow, posCol].Bandiera = false;
                            else
                                griglia[posRow, posCol].Bandiera = true;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (griglia[posRow, posCol].Bandiera == false)
                        {
                            if (griglia[posRow, posCol].CellaScoperta == false)
                                griglia[posRow, posCol].CellaScoperta = true;
                        }
                        enterPress = true;
                        break;
                }
            }
            Stampa(griglia);
        }
        //controllo se ho vinto
        static bool Vittoria(Tessera[,] campo,int bombe)
        {
            bool vincita = false; 
            int contatore = 0;
            for (int i = 0; i < campo.GetLength(0); i++)
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    if (campo[i, j].Bomba == true && campo[i, j].Bandiera == true)
                        contatore++;
                }
            }
            if (contatore == bombe)
                vincita = true;
            return vincita;
        }
        //controllo se ho preso una bomba
        static bool Sconfitta(Tessera[,] campo)
        {
            bool sconfitta = false;
            int i = 0;
            while (!sconfitta && i < campo.GetLength(0))
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    if (campo[i, j].Bomba == true && campo[i, j].CellaScoperta == true)
                        sconfitta = true;
                }
                i++;
            }
            return sconfitta;
        }

        public struct Tessera
        {
            public bool CellaScoperta;
            public bool Bomba;
            public bool Bandiera;
            public int BombeAdiacenti;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"     ██████╗ █████╗ ███╗   ███╗██████╗  ██████╗       
    ██╔════╝██╔══██╗████╗ ████║██╔══██╗██╔═══██╗      
    ██║     ███████║██╔████╔██║██████╔╝██║   ██║      
    ██║     ██╔══██║██║╚██╔╝██║██╔═══╝ ██║   ██║      
    ╚██████╗██║  ██║██║ ╚═╝ ██║██║     ╚██████╔╝      
     ╚═════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝      ╚═════╝       
                                                      
    ███╗   ███╗██╗███╗   ██╗ █████╗ ████████╗ ██████╗ 
    ████╗ ████║██║████╗  ██║██╔══██╗╚══██╔══╝██╔═══██╗
    ██╔████╔██║██║██╔██╗ ██║███████║   ██║   ██║   ██║
    ██║╚██╔╝██║██║██║╚██╗██║██╔══██║   ██║   ██║   ██║
    ██║ ╚═╝ ██║██║██║ ╚████║██║  ██║   ██║   ╚██████╔╝
    ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ");
            Console.ResetColor();
            int riga = 0;
            int colonne = 0;
            int numBombe = 0;
            string difficoltà = "";
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("In che difficoltà vuoi giocare?");
            Console.SetCursorPosition(30, 22);
            Console.ResetColor();
            difficoltà = Console.ReadLine();
            if (difficoltà.Contains("facile"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" _____  _____    ____    _   _        _____");
                Console.WriteLine(@"/    / /  _  \  /   _\  / \ / \      /  __/");
                Console.WriteLine(@"| __\  | / \ |  |  /    | | | |      |  \ ");
                Console.WriteLine(@"| |    | | | |  |  \_   | | | |____  |  /_");
                Console.WriteLine(@"\_/    \_/ \ |  \____/  \_/ \____ /  \____\");
                                 
                Console.WriteLine("- 9 righe");
                Console.WriteLine("- 9 colonne");
                Console.WriteLine("- 10 righe ");
                Thread.Sleep(2000);
                Console.ResetColor();
                riga = 9;
                colonne = 9;
                numBombe = 10;
            }
            if (difficoltà.ToLower().Contains("intermedio"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(@".__        __                                  .___.__        
|__| _____/  |_  ___________  _____   ____   __| _/|__| ____  
|  |/    \   __\/ __ \_  __ \/     \_/ __ \ / __ | |  |/  _ \ 
|  |   |  \  | \  ___/|  | \/  Y Y  \  ___// /_/ | |  (  <_> )
|__|___|  /__|  \___  >__|  |__|_|  /\___  >____ | |__|\____/ 
        \/          \/            \/     \/     \/            ");
                Console.WriteLine(" - 16 righe");
                Console.WriteLine("- 16 colonne");
                Console.WriteLine("- 40 righe ");
                Thread.Sleep(3000);
                Console.ResetColor();
                riga = 16;
                colonne = 16;
                numBombe = 40;
            }
            if (difficoltà.ToLower().Contains("difficile"))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"    .___.__  _____  _____.__       .__.__          
  __| _/|__|/ ____\/ ____\__| ____ |__|  |   ____  
 / __ | |  \   __\\   __\|  |/ ___\|  |  | _/ __ \ 
/ /_/ | |  ||  |   |  |  |  \  \___|  |  |_\  ___/ 
\____ | |__||__|   |__|  |__|\___  >__|____/\___  >
     \/                          \/             \/ ");
                Console.WriteLine("- 30 righe");
                Console.WriteLine("- 16 colonne");
                Console.WriteLine("- 99 righe ");
                Thread.Sleep(3000);
                Console.ResetColor();
                riga = 16;
                colonne = 30;
                numBombe = 99;                
            }
            bool fine = false;
            Tessera[,] campoMinato = new Tessera[riga, colonne];
            //stampo in base alla difficoltà scelta
            Stampa(campoMinato);
            Random gen = new Random();
            //l'utente fa la prima mossa
            MossaGeneraBomba(campoMinato, riga, colonne);
            for (int i = 0; i < numBombe; i++)
            {
                bool bomba = false;
                while (!bomba)
                {
                    int row = gen.Next(0, riga);
                    int col = gen.Next(0, colonne);
                    if (campoMinato[row, col].Bomba == false && campoMinato[row, col].CellaScoperta == false)
                    {
                        campoMinato[row, col].Bomba = true;
                        bomba = true;
                    }
                }
            }
            //Scansiona celle adiacenti
            BombeAd(campoMinato);
            int pos1 = 0;
            int pos2 = 1;
            //ciclo finchè uno dei due non vince
            while (!fine)
            {
                Mossa(campoMinato, riga, colonne, pos1, pos2);
                if (Vittoria(campoMinato, numBombe))
                {
                    Console.WriteLine("You Won!");
                    SpeechSynthesizer voice = new SpeechSynthesizer();
                    voice.Speak("You Won!");
                    fine = true;
                }
                if (Sconfitta(campoMinato))
                {
                    Console.WriteLine("Game over");
                    SpeechSynthesizer voice = new SpeechSynthesizer();
                    voice.Speak("Game Over!");
                    fine = true;
                }
            }
        }
    }
}
