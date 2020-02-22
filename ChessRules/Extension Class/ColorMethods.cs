using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// статический класс расширение для Enum Color
    /// 
    /// </summary>
    static class ColorMethods
    {
        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// метод для смены цвета игрока
        /// 
        /// </summary>
        /// 
        /// <param name="color">
        /// 
        /// цвет текущего игрока 
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// цвет игрока противника 
        /// 
        /// </returns>
        public static Color FlipColor(this Color color)
        {
            switch (color)
            {
                case Color.white:

                    return Color.black;

                case Color.black:

                    return Color.white;

                default:
                    return color;
            }
        }

        #endregion

    }
}
