using System;
using System.Collections.Generic;
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

            Test test = new Test();

            Console.WriteLine("Loading Game....\n");

            Console.WriteLine(string.Format($"{test.ToString() + "  -->  " + test.ModelTesting()}" + "\n"));

            Console.WriteLine("Для начала игры нажмите любую кнопку\n");

            Console.ReadKey();

            #endregion

            Chess chess = new Chess(Constant.startingFEN);

            while (!chess.IsGameOver)
            {
#if DEBUG
                Console.WriteLine(chess.Fen);
#endif

                UI_Console.Print(UI_Console.ChessToAscii(chess));

                foreach (string moves in chess.YieldValidMoves())
                {
                    Console.WriteLine(moves);
                }

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
                    ConsoleColor temp = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = temp;

                    break;
                }
                catch (StealMateException e)
                {
                    ConsoleColor temp = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = temp;

                    break;
                }
            }

            Console.ReadKey();
        }

    }
}
