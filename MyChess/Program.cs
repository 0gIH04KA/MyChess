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
            // var chess = new Chess(Constant.startingFEN);
            var chess = new Chess("7K/8/5k2/8/8/8/6q1/8 b - - 0 0");

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
