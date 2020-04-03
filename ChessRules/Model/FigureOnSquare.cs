using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// класс который описывает фигуру на клетке
    /// 
    /// </summary>
    class FigureOnSquare
    {
        #region ---===   Private   ===---

        private Figure _figure;
        private Square _square;

        #endregion

        #region ---===   Get / Set   ===---

        public Figure FigurE
        {
            get 
            {
                return _figure;
            }
            private set
            {
                _figure = value;
            }
        }

        public Square SquarE
        {
            get
            {
                return _square;
            }
            private set
            {
                _square = value;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        public FigureOnSquare(Figure figure, Square square)
        {
            _figure = figure;
            _square = square;
        }

        #endregion

    }
}
