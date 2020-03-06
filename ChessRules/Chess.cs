using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    public class Chess
    {
        #region ---===   Private   ===---

        private Board _board;
        private Moves _moves;

        private bool _isCheck;
        private bool _isCheckMate;
        private bool _isStealMate;

        #endregion

        #region ---===   Get / Set   ===---

        public string Fen 
        {
            get
            {
                return _board.Fen;
            }
        }

        public bool IsCheck
        {
            get 
            {
                return _isCheck;
            }
        }

        public bool IsCheckMate
        {
            get
            {
                return _isCheckMate;
            }
        }

        public bool IsStealMate
        {
            get
            {
                return _isStealMate;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        public Chess(string fen = Constant.startingFEN)
        {
            _board = new Board(fen);
            _moves = new Moves(_board);

            SetCheckFlags();
        }

        private Chess(Board board)
        {
            _board = board;
            _moves = new Moves(board);

            SetCheckFlags();
        }

        #endregion

        #region ---===   Public Method   ===---

        #endregion


        /// <summary>
        /// 
        /// проверка возможности следующего хода
        /// 
        /// </summary>
        /// 
        /// <param name="move">
        /// 
        /// строковое представление хода
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращаем новую доску с текущим ходом
        /// 
        /// </returns>
        public Chess Move(string move)
        {
            FigureMoving figureMoving = new FigureMoving(move);

            /// <summary>
            /// 
            /// если нельзя совершить указаный ход
            /// 
            /// </summary>
            /// 
            /// <returns>
            /// 
            /// возвращаем текущее расположение шахмат
            /// 
            /// </returns>
            if (!_moves.CanMove(figureMoving))
            {
                return this;
            }

            Board nextBoard = _board.Move(figureMoving);
            Chess nextChess = new Chess(nextBoard);

            return nextChess;
        }

        /// <summary>
        /// 
        /// получение фигуры в указаных координатах
        /// 
        /// </summary>
        /// 
        /// <param name="x"> позиция по Х </param>
        /// <param name="y"> позиция по У </param>
        /// 
        /// <returns>
        /// 
        /// вернуть символ фигуры
        /// 
        /// </returns>
        public char GetFigureAt(int x, int y)
        {
            Square square = new Square(x, y);
            Figure figure = _board.GetFigureAt(square);

            char thisFigure = '.';
            if (figure != Figure.none)
            {
                thisFigure = (char)figure;
            }

            return thisFigure;
        }

        /// <summary>
        /// 
        /// перебор всех фигур текущего игрока которые могут совершить ход на игровой доске
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает все фигуры которые могут совершть ход
        /// 
        /// </returns>
        public IEnumerable<string> YieldValidMoves()
        {
            foreach (FigureOnSquare figureOnSquare in _board.YieldFiguresOnSquare())
            {
                foreach (Square to in Square.YieldBoardSquare())
                {
                    foreach (Figure promotion in figureOnSquare.FigurE.YeldPromotions(to))
                    {
                        FigureMoving figureMoving = new FigureMoving(figureOnSquare, to, promotion);

                        if (_moves.CanMove(figureMoving))
                        {
                            if (!_board.IsCheckAfter(figureMoving))
                            {
                                yield return figureMoving.ToString();
                            }
                        }
                    }
                }
            }
        }

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// установка флагов для проверки шага, мата, пата
        /// 
        /// </summary>
        private void SetCheckFlags()
        {
            _isCheck = _board.IsCheck();
            _isCheckMate = false;
            _isStealMate = false;

            foreach (string moves in YieldValidMoves())
            {
                return;
            }

            if (_isCheck)
            {
                _isCheckMate = true;
            }
            else
            {
                _isStealMate = true;
            }
        }

        #endregion

    }
}
