using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// статический класс который расширяет Enum Figure
    /// 
    /// </summary>
    static class FigureMethods
    {
        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// метод для получения цвета фигуры
        /// 
        /// </summary>
        /// 
        /// <param name="figure">
        /// 
        /// текущая фигура
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// цвет фигуры, default = Color.none;
        /// 
        /// </returns>
        public static Color GetColor(this Figure figure)
        {
            Color color = Color.none;

            switch (figure)
            {
                case Figure.whiteKing:
                case Figure.whiteQueen:
                case Figure.whiteRook:
                case Figure.whiteBishop:
                case Figure.whiteKnight:
                case Figure.whitePawn:

                    color = Color.white;

                    break;

                case Figure.blackKing:
                case Figure.blackQueen:
                case Figure.blackRook:
                case Figure.blackBishop:
                case Figure.blackKnight:
                case Figure.blackPawn:

                    color = Color.black;

                    break;
            }

            return color;
        }

        /// <summary>
        /// 
        /// метод который описывает варианты превращения пешки
        /// 
        /// </summary>
        /// 
        /// <param name="figure">
        /// 
        /// текущая фигура
        /// 
        /// </param>
        /// 
        /// <param name="to">
        /// 
        /// клетка на которой стоит данная фигура
        /// 
        /// </param>
        /// <returns>
        /// 
        /// возвращает варианты превращения пешки
        /// 
        /// </returns>
        public static IEnumerable<Figure> YeldPromotions(this Figure figure, Square to)
        {
            if (figure == Figure.whitePawn 
               && to.Y == ConstantForBoard.LAST_HORIZONTAL)
            {
                yield return Figure.whiteQueen;
                yield return Figure.whiteRook;
                yield return Figure.whiteBishop;
                yield return Figure.whiteKnight;
            }
            else
            {
                if (figure == Figure.blackPawn 
                   && to.Y == ConstantForBoard.FIRST_HORIZONTAL)
                {
                    yield return Figure.blackQueen;
                    yield return Figure.blackRook;
                    yield return Figure.blackBishop;
                    yield return Figure.blackKnight;
                }
                else
                {
                    yield return Figure.none;
                }
            }
        }

        #endregion

    }
}
