using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    public static class ConstantForCastle
    {
        #region ---===   Symbol for Castle   ===---

        /// <summary>
        /// 
        /// символ короткой рокировки для белых фигур
        /// 
        /// </summary>
        public const char SHORT_CASTLE_WHITE = 'K';

        /// <summary>
        /// 
        /// символ длинной рокировки для белых фигур
        /// 
        /// </summary>
        public const char LONG_CASTLE_WHITE = 'Q';

        /// <summary>
        /// 
        /// символ короткой рокировки для черных фигур
        /// 
        /// </summary>
        public const char SHORT_CASTLE_BLACK = 'k';

        /// <summary>
        /// 
        /// символ длинной рокировки для черных фигур
        /// 
        /// </summary>
        public const char LONG_CASTLE_BLACK = 'q';

        #endregion

        #region ---===   Location white figure on Board   ===---

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит левая белая Ладья
        /// 
        /// </summary>
        public const string CELL_WHITE_LEFT_ROOK = "a1";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит левый белый Конь
        /// 
        /// </summary>
        public const string CELL_WHITE_LEFT_KNIGHT = "b1";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит левый белый Слон
        /// 
        /// </summary>
        public const string CELL_WHITE_LEFT_BISHOP = "c1";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит белая Королева
        /// 
        /// </summary>
        public const string CELL_WHITE_QUEEN = "d1";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит белый Король
        /// 
        /// </summary>
        public const string CELL_WHITE_KING = "e1";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит перавый белый Слон
        /// 
        /// </summary>
        public const string CELL_WHITE_RIGHT_BISHOP = "f1";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит правый белый Конь
        /// 
        /// </summary>
        public const string CELL_WHITE_RIGHT_KNIGHT = "g1";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит правая белая Ладья
        /// 
        /// </summary>
        public const string CELL_WHITE_RIGHT_ROOK = "h1";

        #endregion

        #region ---===   Location black figure on Board   ===---

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит левая черная Ладья
        /// 
        /// </summary>
        public const string CELL_BLACK_LEFT_ROOK = "a8";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит левый черный Конь
        /// 
        /// </summary>
        public const string CELL_BLACK_LEFT_KNIGHT = "b8";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит левый черный Слон
        /// 
        /// </summary>
        public const string CELL_BLACK_LEFT_BISHOP = "c8";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит черная Королева
        /// 
        /// </summary>
        public const string CELL_BLACK_QUEEN = "d8";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит черный Король
        /// 
        /// </summary>
        public const string CELL_BLACK_KING = "e8";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит перавый черный Слон
        /// 
        /// </summary>
        public const string CELL_BLACK_RIGHT_BISHOP = "f8";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит правый черный Конь
        /// 
        /// </summary>
        public const string CELL_BLACK_RIGHT_KNIGHT = "g8";

        /// <summary>
        /// 
        /// буквенная запись клетки на которой стоит правая черная Ладья
        /// 
        /// </summary>
        public const string CELL_BLACK_RIGHT_ROOK = "h8";

        #endregion

    }
}
