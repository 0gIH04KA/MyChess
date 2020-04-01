using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChessRules;


namespace MyChess
{
    /// <summary>
    /// 
    /// для начала данная игра реализуется в консоли
    /// дальнейшее развитие проекта...
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region ---===   Testing   ==---

            ITestModel test = new Test();

            Console.WriteLine("Loading Game....\n");

            try
            {
                UI_Console.PrintColorMassage(string.Format($"{test.ToString() + "  -->  " + test.ModelTesting() + "\n" }"), ConsoleColor.Green);
            }
            catch (Exception e)
            {
                UI_Console.PrintColorMassage(string.Format($"В процессе загрузки игры произошла ошибка\n\n" + e.Message + "\n\n"), ConsoleColor.Red);

                Console.WriteLine("Для продолжения нужно обновить игру (:\n");
                Console.WriteLine("Что бы загрузить обновление нажмите Enter иначе приложение будет закрыто");

                ConsoleKeyInfo goToUpdate = Console.ReadKey(true);
               
                if (goToUpdate.Key == ConsoleKey.Enter)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    Console.Clear();
                  
                    Console.WriteLine("\nОжидание освобождения ресурсов\n");

                    System.Threading.Thread.Sleep(3000);

                    UI_Console.PrintColorMassage("Ресурсы успешно освобождены \n", ConsoleColor.Green);
                    Console.WriteLine("Для продолжения нажмите любую кнопку");

                    Console.ReadKey();

                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }

            }           

            Console.WriteLine("Для начала игры нажмите любую кнопку\n");

            Console.ReadKey();

            #endregion  

            Chess chess = new Chess(Constant.startingFEN);

            while (!chess.IsGameOver)
            {
                Console.Clear();

                UI_Console.PrintColorPlayer(chess);
#if DEBUG
                UI_Console.PrintColorMassage(chess.Fen, ConsoleColor.Blue);
#endif

                UI_Console.Print(UI_Console.ChessToAscii(chess));

#if DEBUG
                foreach (string moves in chess.YieldValidMoves())
                {
                    UI_Console.PrintColorMassage(moves, ConsoleColor.Gray);
                }
#endif
                UI_Console.PrintMakeMove();
                string move = Console.ReadLine();

                if (move == "" )
                {
                    break;
                }

                try
                {
                    chess = chess.Move(move);
                }
                catch (CheckMateException e)
                {
                    UI_Console.PrintColorMassage(e.Message, ConsoleColor.Red);

                    break;
                }
                catch (StealMateException e)
                {
                    UI_Console.PrintColorMassage(e.Message, ConsoleColor.Red);

                    break;
                }
            }

            Console.ReadKey();
        }

    }
}
