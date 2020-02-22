using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    enum Figure
    {
        none,

        whiteKing   = 'K', // \u2654
        whiteQueen  = 'Q', // \u2655
        whiteRook   = 'R', // \u2656
        whiteBishop = 'B', // \u2657
        whiteKnight = 'N', // \u2658
        whitePawn   = 'P', // \u2659

        blackKing   = 'k', // \u265A
        blackQueen  = 'q', // \u265B
        blackRook   = 'r', // \u265C
        blackBishop = 'b', // \u265D
        blackKnight = 'n', // \u265E
        blackPawn   = 'p', // \u265F
    }
}
