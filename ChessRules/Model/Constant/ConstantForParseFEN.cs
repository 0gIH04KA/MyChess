using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    public static class ConstantForParseFEN
    {
        /// <summary>
        /// 
        /// обозначение пустой клетки в нотации Форсайта-Эдвардса
        /// 
        /// </summary>
        public const char SYMBOL_EMPTY_CELL_ON_FEN = '1';

        /// <summary>
        /// 
        /// сокращенное обозначение цвета игрока 
        /// 
        /// </summary>
        public const char BLACK_PLAYER = 'b';

        /// <summary>
        /// 
        /// сокращенное обозначение цвета игрока 
        /// 
        /// </summary>
        public const char WHITE_PLAYER = 'w';
    }
}
