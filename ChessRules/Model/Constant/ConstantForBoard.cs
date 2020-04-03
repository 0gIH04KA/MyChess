using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    public static class ConstantForBoard
    {
        /// <summary>
        /// 
        /// Ширина игровой доски
        /// 
        /// </summary>
        public const int WIDTH = 8;

        /// <summary>
        /// 
        /// Высота игровой доски
        /// 
        /// </summary>
        public const int HEIGHT = 8;

        /// <summary>
        /// 
        /// Максимум фигур на одной линии 
        /// 
        /// </summary>
        public const int MAX_FIGURES_ON_LINE = 8;

        /// <summary>
        /// 
        /// первая горизонталь на доке, начиная с нуля
        /// 
        /// </summary>
        public const int FIRST_HORIZONTAL = 0;

        /// <summary>
        /// 
        /// последняя горизонталь на доке, начиная с нуля
        /// 
        /// </summary>
        public const int LAST_HORIZONTAL = 7;
    }
}
