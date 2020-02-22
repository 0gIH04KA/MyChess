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
            var chess = new Chess(Constant.startingFEN);

            while (true)
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

                chess = chess.Move(move);
            }
        }
        
    }
}
