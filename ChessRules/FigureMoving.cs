using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// класс котоырй опичывает движение фигуры
    /// 
    /// </summary>
    class FigureMoving
    {
        #region ---===   Private   ===---

        private Figure _figure;
        private Square _from;
        private Square _to;
        private Figure _promotion;

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

        public Square From
        {
            get
            {
                return _from;
            }
            private set
            {
                _from = value;
            }
        }

        public Square To
        {
            get
            {
                return _to;
            }
            private set
            {
                _to = value;
            }
        }

        public Figure Promotion
        {
            get
            {
                return _promotion;
            }
            private set
            {
                _promotion = value;
            }
        }

        /// <summary>
        /// 
        /// получение DeltaX координат
        /// 
        /// </summary>
        public int DeltaX
        {
            get
            {
                return _to.X - _from.X;
            }
        }

        /// <summary>
        /// 
        /// получение DeltaY координат
        /// 
        /// </summary>
        public int DeltaY
        {
            get
            {
                return _to.Y - _from.Y;
            }
        }

        /// <summary>
        /// 
        /// получение модуля DeltaX координат
        /// 
        /// </summary>
        public int AbsDeltaX
        {
            get
            {
                return Math.Abs(DeltaX);
            }
        }

        /// <summary>
        /// 
        /// получение модуля DeltaY координат
        /// 
        /// </summary>
        public int AbsDeltaY
        {
            get
            {
                return Math.Abs(DeltaY);
            }
        }

        /// <summary>
        /// 
        /// получение знака DeltaX координат
        /// 
        /// </summary>
        public int SignX
        {
            get
            {
                return Math.Sign(DeltaX);
            }
        }

        /// <summary>
        /// 
        /// получение знака DeltaY координат
        /// 
        /// </summary>
        public int SignY
        {
            get
            {
                return Math.Sign(DeltaY);
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        public FigureMoving(FigureOnSquare figureOnSquare, Square to, 
                            Figure promotion = Figure.none)
        {
            _figure = figureOnSquare.FigurE;
            _from = figureOnSquare.SquarE;
            _to = to;
            _promotion = promotion;
        }

        public FigureMoving(string move)    //Pe2e4, Pe7e8Q
                                            //01234  012345
        {
            _figure = (Figure)move[0];
            _from = new Square(move.Substring(1, 2));
            _to = new Square(move.Substring(3, 2));
            
            if (move.Length == 6)
            {
                _promotion = (Figure)move[5];
            }

            _promotion = Figure.none;

        }

        #endregion

        #region ---===   Method   ===---

        #endregion

        #region ---===   Override Method   ===---

        /// <summary>
        /// 
        /// метод записи фигуры 
        /// с какой клетки она идет
        /// и куда она может совершить ход
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает строковое представление
        /// 
        /// </returns>
        public override string ToString()
        {
            return ((char)_figure).ToString() 
                    + _from.Name 
                    + _to.Name
                    + (_promotion == Figure.none ? "" : ((char)_promotion).ToString());
        }

        #endregion
         
    }
}
