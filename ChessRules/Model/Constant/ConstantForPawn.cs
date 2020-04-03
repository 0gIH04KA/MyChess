using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    public static class ConstantForPawn
    {
        /// <summary>
        /// 
        /// начальная горизонталь белой пешки, начиная с 0
        /// 
        /// </summary>
        public const int START_HORIZONTAL_WHITE_PAWN = 1;

        /// <summary>
        /// 
        /// горизонталь белых фигур для звятия пешки на проходе
        /// 
        /// </summary>
        public const int HORIZONTAL_WHITE_ENPASSANT = 2;

        /// <summary>
        /// 
        /// горизонталь на которую может прыгнуть белая пешка
        /// 
        /// </summary>
        public const int JUMP_HORIZONTAL_WHITE_PAWN = 3;

        /// <summary>
        /// 
        /// начальная горизонталь черной пешки, начиная с 0
        /// 
        /// </summary>
        public const int START_HORIZONTAL_BLACK_PAWN = 6;

        /// <summary>
        /// 
        /// горизонталь черных фигур для звятия пешки на проходе
        /// 
        /// </summary>
        public const int HORIZONTAL_BLACK_ENPASSANT = 5;

        /// <summary>
        /// 
        /// горизонталь на которую может прыгнуть черная пешка
        /// 
        /// </summary>
        public const int JUMP_HORIZONTAL_BLACK_PAWN = 4;

        /// <summary>
        /// 
        /// горизонталь на которой не может находится белая пешка
        /// 
        /// </summary>
        public const int CAN_NOT_HORIZONTAL_WHITE = 8;

        /// <summary>
        /// 
        /// горизонталь на которой не может находится черная пешка
        /// 
        /// </summary>
        public const int CAN_NOT_HORIZONTAL_BLACK = 1;
    }
}
