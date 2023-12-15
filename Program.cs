using System;
using System.Collections.Generic;
using System.Threading;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Border();
            PaketInfo();
            List<int> Sejarah = new List<int>(10);
            int Score = 0;
            UpdateScore(Score);
            string UlangTidak = "";

            /*  ----------
                |  |  |  | ---> [0][0] [0][1] [0][2] 
                ----------
                |  |  |  | ---> [1][0] [1][1] [1][2]
                ----------
                |  |  |  | ---> [2][0] [2][1] [2][2]
                ----------
            SEMUA BERNILAI 0, JIKA USER PILIH MAKA BERNILAI 1, JIKA KOMPUTER PILIH BERNILAI 2
            
            */
            // X User
            // O Komputer
            //Membuat Grid 3*3 sebagai dasar permainan

            for (; ; )
            {
                if( UlangTidak == " Tidak" || UlangTidak == "tidak")
                {
                    break;
                }
                //Start/End Loop
                Console.SetCursorPosition(3, 2);
                Console.WriteLine("Ketik \"Start\" untuk mulai !!");
                Console.SetCursorPosition(3, 3);
                Console.WriteLine("Ketik \"End\" untuk berhenti !!");
                Console.SetCursorPosition(3, 5);
                string MulaiTidak = Console.ReadLine();
                if (MulaiTidak == "Start" || MulaiTidak == "start")
                {
                    bool Loop = true;
                    Console.SetCursorPosition(3, 5);
                    Console.WriteLine("            ");
                    for (; Loop; )
                    {
                        // Game Loop
                        int AksiKe = 0;
                        int[][] Board = new int[3][];
                        Board[0] = new int[3] { 0, 0, 0 };
                        Board[1] = new int[3] { 0, 0, 0 };
                        Board[2] = new int[3] { 0, 0, 0 };
                        List<int> SudahBerisi = new List<int>(9);

                        for (; ; )
                        {
                            UlangTidak = "";
                            UpdateBoard(Board);
                            int AngkaAksiUser, AngkaAksiKomputer;

                            if (SiapaDuluan())
                            {
                                Console.SetCursorPosition((Console.WindowWidth - 19) / 2, 5);
                                Console.WriteLine("Aksi Pertama : User");
                                AksiKe++;
                                //User Duluan
                                AngkaAksiUser = CariAksiUser(SudahBerisi);
                                // Aksi User dilakukan
                                SudahBerisi.Add(AngkaAksiUser);
                                Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                UpdateBoard(Board);

                                if (AngkaAksiUser == 1 || AngkaAksiUser == 3 || AngkaAksiUser == 7 || AngkaAksiUser == 9)
                                {
                                    AksiKe++;
                                    AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 5);
                                    SudahBerisi.Add(AngkaAksiKomputer);
                                    Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                    Console.WriteLine(AngkaAksiKomputer);
                                    UpdateBoard(Board);

                                    AksiKe++;
                                    AngkaAksiUser = CariAksiUser(SudahBerisi);
                                    SudahBerisi.Add(AngkaAksiUser);
                                    Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                    UpdateBoard(Board);

                                    if ((AngkaAksiUser == 1 && Board[2][2] == 1) || (AngkaAksiUser == 3 && Board[2][0] == 1) || (AngkaAksiUser == 7 && Board[0][2] == 1) || (AngkaAksiUser == 9 && Board[0][0] == 1))
                                    {
                                        AksiKe++;
                                        AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 2, 4, 6, 8);
                                        SudahBerisi.Add(AngkaAksiKomputer);
                                        Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                        Console.WriteLine(AngkaAksiKomputer);
                                        UpdateBoard(Board);

                                        AksiKe++;
                                        AngkaAksiUser = CariAksiUser(SudahBerisi);
                                        SudahBerisi.Add(AngkaAksiUser);
                                        Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                        UpdateBoard(Board);
                                        if (CekMenang(Board) > -1) { break; }

                                        //Masuk ke otomatis Blokir menang
                                        for (; AksiKe < 9;)
                                        {
                                            AksiKe++;
                                            if (AksiKe % 2 == 0)
                                            {
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                            else
                                            {
                                                AngkaAksiUser = CariAksiUser(SudahBerisi);
                                                SudahBerisi.Add(AngkaAksiUser);
                                                Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        //Masuk ke otomatis Blokir menang
                                        for (; AksiKe < 9;)
                                        {
                                            AksiKe++;
                                            if (AksiKe % 2 == 0)
                                            {
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                            else
                                            {
                                                AngkaAksiUser = CariAksiUser(SudahBerisi);
                                                SudahBerisi.Add(AngkaAksiUser);
                                                Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (AngkaAksiUser == 5)
                                    {
                                        AksiKe++;
                                        AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 1, 3, 7, 9);
                                        SudahBerisi.Add(AngkaAksiKomputer);
                                        Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                        Console.WriteLine(AngkaAksiKomputer);
                                        UpdateBoard(Board);

                                        AksiKe++;
                                        AngkaAksiUser = CariAksiUser(SudahBerisi);
                                        SudahBerisi.Add(AngkaAksiUser);
                                        Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                        UpdateBoard(Board);
                                        if ((AngkaAksiKomputer == 1 && AngkaAksiUser ==9 )|| (AngkaAksiKomputer == 3 && AngkaAksiUser == 7) || (AngkaAksiKomputer == 7 && AngkaAksiUser == 3) || (AngkaAksiKomputer == 9 && AngkaAksiUser == 1))
                                        {
                                            if ((AngkaAksiKomputer == 1 && AngkaAksiUser == 9) || (AngkaAksiKomputer == 9 && AngkaAksiUser == 1))
                                            {
                                                AksiKe++;
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 3,7);
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                            }
                                            else
                                            {
                                                AksiKe++;
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 1,9);
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                            }
                                            //Masuk ke otomatis Blokir menang
                                            for (; AksiKe < 9;)
                                            {
                                                AksiKe++;
                                                if (AksiKe % 2 == 0)
                                                {
                                                    AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                                    SudahBerisi.Add(AngkaAksiKomputer);
                                                    Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                    Console.WriteLine(AngkaAksiKomputer);
                                                    UpdateBoard(Board);
                                                    if (CekMenang(Board) > -1) { break; }
                                                }
                                                else
                                                {
                                                    AngkaAksiUser = CariAksiUser(SudahBerisi);
                                                    SudahBerisi.Add(AngkaAksiUser);
                                                    Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                                    UpdateBoard(Board);
                                                    if (CekMenang(Board) > -1) { break; }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //Masuk ke otomatis Blokir menang
                                            for (; AksiKe < 9;)
                                            {
                                                AksiKe++;
                                                if (AksiKe % 2 == 0)
                                                {
                                                    AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                                    SudahBerisi.Add(AngkaAksiKomputer);
                                                    Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                    Console.WriteLine(AngkaAksiKomputer);
                                                    UpdateBoard(Board);
                                                    if (CekMenang(Board) > -1) { break; }
                                                }
                                                else
                                                {
                                                    AngkaAksiUser = CariAksiUser(SudahBerisi);
                                                    SudahBerisi.Add(AngkaAksiUser);
                                                    Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                                    UpdateBoard(Board);
                                                    if (CekMenang(Board) > -1) { break; }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        AksiKe++;
                                        AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 5);
                                        SudahBerisi.Add(AngkaAksiKomputer);
                                        Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                        Console.WriteLine(AngkaAksiKomputer);
                                        UpdateBoard(Board);

                                        AksiKe++;
                                        AngkaAksiUser = CariAksiUser(SudahBerisi);
                                        SudahBerisi.Add(AngkaAksiUser);
                                        Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                        UpdateBoard(Board);

                                        //Masuk ke otomatis Blokir menang
                                        for (; AksiKe < 9;)
                                        {
                                            AksiKe++;
                                            if (AksiKe % 2 == 0)
                                            {
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                            else
                                            {
                                                AngkaAksiUser = CariAksiUser(SudahBerisi);
                                                SudahBerisi.Add(AngkaAksiUser);
                                                Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Komputer Duluan
                                Console.SetCursorPosition((Console.WindowWidth - 23) / 2, 5);
                                Console.WriteLine("Aksi Pertama : Komputer");
                                AksiKe++;
                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 1, 3, 7, 9);
                                SudahBerisi.Add(AngkaAksiKomputer);
                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                Console.WriteLine(AngkaAksiKomputer);
                                UpdateBoard(Board);

                                AksiKe++;
                                AngkaAksiUser = CariAksiUser(SudahBerisi);
                                SudahBerisi.Add(AngkaAksiUser);
                                Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                UpdateBoard(Board);

                                if (AngkaAksiKomputer == 1 || AngkaAksiKomputer == 9)
                                {
                                    if (AngkaAksiKomputer == 1)
                                    {
                                        if (AngkaAksiUser != 9)
                                        {
                                            AksiKe++;
                                            AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 9);
                                            SudahBerisi.Add(AngkaAksiKomputer);
                                            Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                            Console.WriteLine(AngkaAksiKomputer);
                                            UpdateBoard(Board);
                                        }
                                        else
                                        {
                                            AksiKe++;
                                            AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 3, 7);
                                            SudahBerisi.Add(AngkaAksiKomputer);
                                            Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                            Console.WriteLine(AngkaAksiKomputer);
                                            UpdateBoard(Board);
                                        }
                                    }
                                    else
                                    {
                                        if (AngkaAksiUser != 1)
                                        {
                                            AksiKe++;
                                            AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 1);
                                            SudahBerisi.Add(AngkaAksiKomputer);
                                            Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                            Console.WriteLine(AngkaAksiKomputer);
                                            UpdateBoard(Board);
                                        }
                                        else
                                        {
                                            AksiKe++;
                                            AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 3, 7);
                                            SudahBerisi.Add(AngkaAksiKomputer);
                                            Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                            Console.WriteLine(AngkaAksiKomputer);
                                            UpdateBoard(Board);
                                        }
                                    }
                                    //Masuk ke otomatis Blokir menang
                                    for (; AksiKe < 9;)
                                    {
                                        AksiKe++;
                                        if (AksiKe % 2 == 1)
                                        {
                                            AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                            SudahBerisi.Add(AngkaAksiKomputer);
                                            Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                            Console.WriteLine(AngkaAksiKomputer);
                                            UpdateBoard(Board);
                                            if (CekMenang(Board) > -1) { break; }
                                        }
                                        else
                                        {
                                            AngkaAksiUser = CariAksiUser(SudahBerisi);
                                            SudahBerisi.Add(AngkaAksiUser);
                                            Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                            UpdateBoard(Board);
                                            if (CekMenang(Board) > -1) { break; }
                                        }
                                    }
                                }
                                else
                                {
                                    if (AngkaAksiKomputer == 3 || AngkaAksiKomputer == 7)
                                    {
                                        if (AngkaAksiKomputer == 3)
                                        {
                                            if (AngkaAksiUser != 7)
                                            {
                                                AksiKe++;
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 7);
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                            }
                                            else
                                            {
                                                AksiKe++;
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 1, 9);
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                            }
                                        }
                                        else
                                        {
                                            if (AngkaAksiUser != 3)
                                            {
                                                AksiKe++;
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 7);
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                            }
                                            else
                                            {
                                                AksiKe++;
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, 1, 9);
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                            }
                                        }
                                        //Masuk ke otomatis Blokir menang
                                        for (; AksiKe < 9;)
                                        {
                                            AksiKe++;
                                            if (AksiKe % 2 == 1)
                                            {
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                            else
                                            {
                                                AngkaAksiUser = CariAksiUser(SudahBerisi);
                                                SudahBerisi.Add(AngkaAksiUser);
                                                Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (; AksiKe < 9;)
                                        {
                                            AksiKe++;
                                            if (AksiKe % 2 == 1)
                                            {
                                                AngkaAksiKomputer = CariAksiKomputer(SudahBerisi, OtomaticNyerangBlokir(Board, SudahBerisi));
                                                SudahBerisi.Add(AngkaAksiKomputer);
                                                Board = LakukanAksi(Board, AngkaAksiKomputer, 2);
                                                Console.WriteLine(AngkaAksiKomputer);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                            else
                                            {
                                                AngkaAksiUser = CariAksiUser(SudahBerisi);
                                                SudahBerisi.Add(AngkaAksiUser);
                                                Board = LakukanAksi(Board, AngkaAksiUser, 1);
                                                UpdateBoard(Board);
                                                if (CekMenang(Board) > -1) { break; }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                        Score = TambahKurangScore(Sejarah, Score, Board);
                        UpdateScore(Score);
                        UpdateSejarah(Sejarah);
                        ResetInfoAksi(1);
                        Console.SetCursorPosition(59, 15);
                        Thread.Sleep(750);
                        for (; ; )
                        {
                            Console.SetCursorPosition((Console.WindowWidth - 16) / 2, 19);
                            Console.WriteLine("Mulai lagi ?");
                            Console.SetCursorPosition((Console.WindowWidth - 16) / 2, 20);
                            Console.Write("Ya/Tidak : ");
                            UlangTidak = Console.ReadLine();
                            Console.SetCursorPosition((Console.WindowWidth - 16) / 2, 20);
                            Console.Write("Ya/Tidak :                ");
                            if (UlangTidak == "Tidak" || UlangTidak == "tidak")
                            {
                                Loop = false;
                                break;
                            }
                            else
                            {
                                if(UlangTidak == "Ya" || UlangTidak == "ya")
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (MulaiTidak == "End" || MulaiTidak == "end" )
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(3, 5);
                        Console.WriteLine("                       ");
                    }
                }
            } 
        }

        static bool SiapaDuluan()
        // True jika User duluan, False jika Komputer duluan
        {   
            Random AngkaAsal = new Random();
            if (AngkaAsal.Next(2) == 1)
                return true;
            else return false;
        }

        static int[][] LakukanAksi(int[][] Board, int AngkaAksi, int UserAtauKomputer)
        // Masukan input ke dalam Board
        {
            switch (AngkaAksi)
            {
                case 1: Board[0][0] = UserAtauKomputer; break;
                case 2: Board[0][1] = UserAtauKomputer; break;
                case 3: Board[0][2] = UserAtauKomputer; break;
                case 4: Board[1][0] = UserAtauKomputer; break;
                case 5: Board[1][1] = UserAtauKomputer; break;
                case 6: Board[1][2] = UserAtauKomputer; break;
                case 7: Board[2][0] = UserAtauKomputer; break;
                case 8: Board[2][1] = UserAtauKomputer; break;
                case 9: Board[2][2] = UserAtauKomputer; break;
            }
            return Board;
        }

        static int CariAksiKomputer(List<int> SudahBerisi,params int[] pilihan)
        // Minta apa saja yang bisa dipilih dan memberi nilai acak dari pilihan
        {
            Random AngkaAsal = new Random();
            Console.SetCursorPosition(62, 16);
            Console.ForegroundColor =ConsoleColor.Red;
            int x = pilihan[AngkaAsal.Next(pilihan.Length-1)];
            SudahBerisi.Add(x);
            return x;
        }

        static int CariAksiUser(List<int> SudahBerisi)
        // Minta aksi dari User kemudian dicek bisa ngga aksi tersebut
        {
            int AngkaAksiUser;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(59, 15);
            for (; ; )
            //Cek Angka sudah terisi / bukan format angka
            {
                AngkaAksiUser = CekAngkaBukan(Console.ReadLine());
                if (AngkaAksiUser == -1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(38, 18);
                    Console.WriteLine("--ERROR ... harus ANGKA 1-9--");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    ResetInfoAksi(0);
                    Thread.Sleep(750);
                    ResetInfoAksi(2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(59, 15);
                }
                else
                {
                    if (SudahBerisi.Contains(AngkaAksiUser))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(38, 18);
                        Console.WriteLine("--Tempat sudah BERISI pilih ANGKA LAIN--");
                        Console.ResetColor();
                        Console.SetCursorPosition(59, 15);
                        Thread.Sleep(1000);
                        ResetInfoAksi(0);    
                        Thread.Sleep(750);
                        ResetInfoAksi(2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(59, 15);
                    }
                    else { Console.ResetColor(); ResetInfoAksi(0); break; }
                }
            }
            Console.SetCursorPosition(59, 15);
            return AngkaAksiUser;
        }

        static int CekMenang(int[][]Board)
        // Return 1 jika user menang, 2 jika komputer menang, 0 jika seri, -1 jika belum ada menang
        {
            // 3 sama dalam satu baris / kolom
            for (int i = 0; i < 3; i++)
            {
                if (Board[i][0] == Board[i][1] && Board[i][1] == Board[i][2] && Board[i][0] != 0)
                {
                    if (Board[i][0] == 1) { return 1; } else { return 2; }
                }
                if (Board[0][i] == Board[1][i] && Board[1][i] == Board[2][i] && Board[0][i] != 0)
                {
                    if (Board[0][i] == 1) { return 1; } else { return 2; }
                }
            }

            //3 sama secara diagonal
            if (Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2]&& Board[1][1]!=0)
            {
                if (Board[0][0] == 1) { return 1; } else { return 2; }
            }
            if (Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0] && Board[1][1] != 0)
            {
                if (Board[0][2] == 1) { return 1; } else { return 2; }
            }
            //jika full semua jadi seri
            if ((Board[0][0]!=0 && Board[0][1] != 0)&& (Board[0][2] != 0 && Board[1][0] != 0) && (Board[1][1] != 0 && Board[1][2] != 0) && (Board[2][0] != 0 && Board[2][1] != 0) && Board[2][2] != 0)
            {
                return 0;
            }
            return -1;
        }
        
        static int CekAngkaBukan(string x)
        //Cek Jika string itu angka atau bukan JIka Bukan nilai = -1 
        {
            try
            {
                int n = Convert.ToInt32(x);
                if (n > 0 && n < 10)
                    return n;
                else return -1;
            }
            catch(FormatException)
            {
                return -1; 
            }
        }

        static int TambahKurangScore(List<int> Sejarah, int Score, int[][] Board)
        //Cek menang dan penambahan pada score serta Display Menang/Kalah
        {

            int Cek = CekMenang(Board);
            if (Sejarah.Count == 10) { Sejarah.RemoveAt(9); }
            if (Cek > -1)
            {
                if (Cek == 1)
                {
                    // User Menang
                    Sejarah.Add(Cek);
                    Score += 10;
                }
                else
                {
                    if (Cek == 0)
                    {
                        // Seri  
                        Sejarah.Add(Cek);
                    }
                    else
                    {
                        // Komputer Menang
                        Sejarah.Add(Cek);
                        Score--;
                    }
                }
            }
            return Score;
        }

        static int OtomaticNyerangBlokir(int[][] Board, List<int> SudahBerisi)
        //AI UNTUK KOMPUTER
        {
            // Otomatis jika bisa menang
            for (int i = 0; i < 3; i++)
            {
                if (((Board[0][i] == 2 && Board[1][i] == 2) && Board[2][i] == 0) || ((Board[0][i] == 2 && Board[2][i] == 2) && Board[1][i] == 0) || ((Board[1][i] == 2 && Board[2][i] == 2) && Board[0][i] == 0))
                {
                    //Kolom menang
                    if (Board[0][i] == 2 && Board[1][i] == 2)
                    {
                        return i + 7;
                    }
                    else
                    {
                        if (Board[0][i] == 2 && Board[2][i] == 2)
                        {
                            return i + 4;
                        }
                        else { return i + 1; }
                    }
                }
                else
                {
                    if (((Board[i][0] == 2 && Board[i][1] == 2) && Board[i][2] == 0) || ((Board[i][0] == 2 && Board[i][2] == 2) && Board[i][1] == 0) || ((Board[i][1] == 2 && Board[i][2] == 2) && Board[i][0] == 0))
                    {
                        //Baris Menang
                        if (Board[i][0] == 2 && Board[i][1] == 2)
                        {
                            return (i * 3) + 3;
                        }
                        else
                        {
                            if (Board[i][0] == 2 && Board[i][2] == 2)
                            {
                                return (i * 3) + 2;
                            }
                            else { return (i * 3) + 1; }
                        }
                    }
                }
            }
            if (((Board[0][0] == 2 && Board[1][1] == 2) && Board[2][2] == 0) || ((Board[0][0] == 2 && Board[2][2] == 2) && Board[1][1] == 0) || ((Board[1][1] == 2 && Board[2][2] == 2) && Board[0][0] == 0))
            {
                //Diagonal keKanan menang
                if (Board[0][0] == 2 && Board[1][1] == 2)
                {
                    return 9;
                }
                else
                {
                    if (Board[0][0] == 2 && Board[2][2] == 2)
                    {
                        return 5;
                    }
                    else { return 1; }
                }
            }
            else
            {
                if (((Board[0][2] == 2 && Board[1][1] == 2) && Board[2][0] == 0) || ((Board[0][2] == 2 && Board[2][0] == 2) && Board[1][1] == 0) || ((Board[1][1] == 2 && Board[2][0] == 2) && Board[0][2] == 0))
                {
                    //Diagonal keKiri menang
                    if (Board[0][2] == 2 && Board[1][1] == 2)
                    {
                        return 7;
                    }
                    else
                    {
                        if (Board[0][2] == 2 && Board[2][0] == 2)
                        {
                            return 5;
                        }
                        else { return 3; }
                    }
                }
            }
            // Otomatis mencegah menang
            for (int i = 0; i < 3; i++)
            {
                if (((Board[0][i] == 1 && Board[1][i] == 1) && Board[2][i] == 0) || ((Board[0][i] == 1 && Board[2][i] == 1) && Board[1][i] == 0) || ((Board[1][i] == 1 && Board[2][i] == 1) && Board[0][i] == 0))
                {
                    //Kolom menang
                    if (Board[0][i] == 1 && Board[1][i] == 1)
                    {
                        return i + 7;
                    }
                    else
                    {
                        if (Board[0][i] == 1 && Board[2][i] == 1)
                        {
                            return i + 4;
                        }
                        else { return i + 1; }
                    }
                }
                else
                {
                    if (((Board[i][0] == 1 && Board[i][1] == 1) && Board[i][2] == 0) || ((Board[i][0] == 1 && Board[i][2] == 1) && Board[i][1] == 0) || ((Board[i][1] == 1 && Board[i][2] == 1) && Board[i][0] == 0))
                    {
                        //Baris Menang
                        if (Board[i][0] == 1 && Board[i][1] == 1)
                        {
                            return (i * 3) + 3;
                        }
                        else
                        {
                            if (Board[i][0] == 1 && Board[i][2] == 1)
                            {
                                return (i * 3) + 2;
                            }
                            else { return (i * 3) + 1; }
                        }
                    }
                }
            }
            if (((Board[0][0] == 1 && Board[1][1] == 1) && Board[2][2] == 0) || ((Board[0][0] == 1 && Board[2][2] == 1) && Board[1][1] == 0) || ((Board[1][1] == 1 && Board[2][2] == 1) && Board[0][0] == 0))
            {
                //Diagonal keKanan menang
                if (Board[0][0] == 1 && Board[1][1] == 1)
                {
                    return 9;
                }
                else
                {
                    if (Board[0][0] == 1 && Board[2][2] == 1)
                    {
                        return 5;
                    }
                    else { return 1; }
                }
            }
            else
            {
                if (((Board[0][2] == 1 && Board[1][1] == 1) && Board[2][0] == 0) || ((Board[0][2] == 1 && Board[2][0] == 1) && Board[1][1] == 0) || ((Board[1][1] == 1 && Board[2][0] == 1) && Board[0][2] == 0))
                {
                    //Diagonal keKiri menang
                    if (Board[0][2] == 1 && Board[1][1] == 1)
                    {
                        return 7;
                    }
                    else
                    {
                        if (Board[0][2] == 1 && Board[2][0] == 1)
                        {
                            return 5;
                        }
                        else { return 3; }
                    }
                }
            }
            if(Board[0][0]==0 && ((Board[0][1] == 1 && Board[0][2] == 0) || (Board[0][2] == 1 && Board[0][1] == 0)) && ((Board[1][0] == 1 && Board[2][0] == 0) || (Board[1][0] == 0 && Board[2][0] == 1)))
            {
                return 1;
            }
            else
            {
                if (Board[0][2] == 0 && ((Board[0][0] == 1 && Board[0][1] == 0) || (Board[0][1] == 1 && Board[0][0] == 0)) && ((Board[1][2] == 1 && Board[2][2] == 0) || (Board[1][2] == 0 && Board[2][2] == 1)))
                {
                    return 3;
                }
                else
                {
                    if (Board[2][0] == 0 && ((Board[0][0] == 1 && Board[1][0] == 0) || (Board[1][0] == 1 && Board[0][0] == 0)) && ((Board[2][1] == 1 && Board[2][2] == 0) || (Board[2][1] == 0 && Board[2][2] == 1)))
                    {
                        return 7;
                    }
                    else
                    {
                        if (Board[2][2] == 0 && ((Board[0][2] == 1 && Board[1][2] == 0) || (Board[1][2] == 1 && Board[0][2] == 0)) && ((Board[2][0] == 1 && Board[2][1] == 0) || (Board[2][0] == 0 && Board[2][1] == 1)))
                        {
                            return 9;
                        }
                    }
                }
            }
            
                
            
            // Otomatis nyerang
            Random AngkaAcak = new Random();
            List<int> AngkaYangMenyerang = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                // Potensi nyerang dalam baris
                if ((Board[i][0] == 2) && (Board[i][1] == 0 && Board[i][2] == 0))
                {
                    AngkaYangMenyerang.Add(2 + 3*i);
                    AngkaYangMenyerang.Add(3 + 3 * i);
                }
                if ((Board[i][1] == 2) && (Board[i][0] == 0 && Board[i][2] == 0))
                {
                    AngkaYangMenyerang.Add(1 + 3 * i);
                    AngkaYangMenyerang.Add(3 + 3 * i);
                }
                if ((Board[i][2] == 2) && (Board[i][0] == 0 && Board[i][1] == 0))
                {
                    AngkaYangMenyerang.Add(1 + 3 * i);
                    AngkaYangMenyerang.Add(2 + 3 * i);
                }
                //Potensi nyerang dalam kolom
                if ((Board[0][i] == 2) && (Board[1][i] == 0 && Board[2][i] == 0))
                {
                    AngkaYangMenyerang.Add(4+i);
                    AngkaYangMenyerang.Add(7+i);
                }
                if ((Board[1][i] == 2) && (Board[0][i] == 0 && Board[2][i] == 0))
                {
                    AngkaYangMenyerang.Add(1+i);
                    AngkaYangMenyerang.Add(7+i);
                }
                if ((Board[2][i] == 2) && (Board[1][i] == 0 && Board[0][i] == 0))
                {
                    AngkaYangMenyerang.Add(1+i);
                    AngkaYangMenyerang.Add(4+i);
                }
            }
            //Potensi Nyerang Diagonal KeKanan
            if ((Board[0][0] == 2) && (Board[1][1] == 0 && Board[2][2] == 0))
            {
                AngkaYangMenyerang.Add(5);
                AngkaYangMenyerang.Add(9);
            }
            if ((Board[1][1] == 2) && (Board[0][0] == 0 && Board[2][2] == 0))
            {
                AngkaYangMenyerang.Add(1);
                AngkaYangMenyerang.Add(9);
            }
            if ((Board[2][2] == 2) && (Board[1][1] == 0 && Board[0][0] == 0))
            {
                AngkaYangMenyerang.Add(1);
                AngkaYangMenyerang.Add(5);
            }
            // Potensi Nyerang Diagonal KeKiri
            if ((Board[0][2] == 2) && (Board[1][1] == 0 && Board[2][0] == 0))
            {
                AngkaYangMenyerang.Add(5);
                AngkaYangMenyerang.Add(7);
            }
            if ((Board[1][1] == 2) && (Board[0][2] == 0 && Board[2][0] == 0))
            {
                AngkaYangMenyerang.Add(3);
                AngkaYangMenyerang.Add(7);
            }
            if ((Board[2][2] == 2) && (Board[1][1] == 0 && Board[0][0] == 0))
            {
                AngkaYangMenyerang.Add(3);
                AngkaYangMenyerang.Add(5);
            }

            if (AngkaYangMenyerang.Count > 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("ERORR");
                return AngkaYangMenyerang[AngkaAcak.Next(AngkaYangMenyerang.Count)];
            }
            else 
            {
                List<int> TidakBerisi = new List<int>();
                for(int x = 1; x < 10; x++)
                {
                    if (!SudahBerisi.Contains(x))
                    {
                        TidakBerisi.Add(x);
                    }
                }
                return TidakBerisi[AngkaAcak.Next(TidakBerisi.Count)]; 
            }
        }

        static void UpdateScore(int Score)
        {
            Console.SetCursorPosition(89,6);
            if(Score == 0) 
            { 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(0+"    "); 
            }
            else { 
                if (Score > 0) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Score + "    ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Score + "    ");
                } 
            } Console.ForegroundColor = ConsoleColor.White;
        }

        static void UpdateSejarah(List<int> Sejarah)
        {
            int index = 0;
            foreach (int x in Sejarah)
            {

                Console.SetCursorPosition(85, 10 + index);
                if (x != 0)
                {
                    if (x == 1)
                    {
                        // User menang
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("MENANG GA MUNGKIN");
                    }
                    else
                    {
                        // Komputer menang
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("KALAH CUPU");
                    }
                }
                else
                {
                    // Seri
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("SERI SANTUY");
                }
                index++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void UpdateBoard(int[][] Board)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(19, 6);
            Console.WriteLine("-----------");
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(20, 8 + (2 * i - 1));
                if (Board[i][0] != 0)
                {
                    if (Board[i][0] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("X"); 
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                    }
                }
                else { Console.ForegroundColor = ConsoleColor.White; Console.Write("#"); }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
                if (Board[i][1] != 0)
                {
                    if (Board[i][1] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("X");
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                    }
                }
                else { Console.ForegroundColor = ConsoleColor.White; Console.Write("#"); }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" | ");
                if (Board[i][2] != 0)
                {
                    if (Board[i][2] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("X");
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                    }
                }
                else { Console.ForegroundColor = ConsoleColor.White; Console.Write("#"); }
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(19, 8 + 2 * i);
                Console.WriteLine("-----------");
            }
        }

        static void ResetInfoAksi(int x)
        {
            if (x == 0)
            {
                Console.SetCursorPosition(40, 15);
                Console.WriteLine(" Ketik Aksi Anda :                                  ");
            }
            else
            {
                if (x == 2)
                {
                    Console.SetCursorPosition(36, 18);
                    Console.WriteLine("                                                ");
                }
                else
                {
                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine(" Ketik Aksi Anda :                                  ");
                    Console.SetCursorPosition(40, 16);
                    Console.WriteLine(" Aksi oleh Komputer :                                ");
                }
            }
        }

        static void Border()
        // Pembuat Border atas dan bawah
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("");
            Console.SetCursorPosition(0, 1);

        }

        static void PaketInfo()
        // UI -- Menulis Judul, Score, Score Streak, Histori Menang Kalah
        {
            Console.SetCursorPosition((Console.WindowWidth - 28) / 2, 3);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("-[ Tic Tac Toe - The Game ]-");
            Console.ResetColor();
            Console.SetCursorPosition(80, 6);
            Console.WriteLine("Score :  0");
            Console.SetCursorPosition(80, 8);
            Console.WriteLine("Sejarah : ");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine(" Ketik Aksi Anda : ");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine(" Aksi oleh Komputer : ");

        }
            
    }
}
