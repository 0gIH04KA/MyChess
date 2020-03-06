using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// класс который описывает алгоритм движение фигур по игровому полю
    /// 
    /// </summary>
    class Moves
    {
        #region ---===   Private   ===---

        private FigureMoving _figureMoving;
        private Board _board;

        #endregion

        #region ---===   Get / Set   ===---

        public FigureMoving FigureMovinG
        {
            get
            {
                return _figureMoving;
            }
            private set
            {
                _figureMoving = value;
            }
        }

        public Board BoarD
        {
            get
            {
                return _board;
            }
            private set
            {
                _board = value;
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        public Moves(Board board)
        {
            _board = board;
        }

        #endregion

        #region ---===   Public Methods   ===---

        /// <summary>
        /// 
        /// мметод который описывает движение фигуры по игровой доске
        /// 
        /// </summary>
        /// 
        /// <param name="figureMoving">
        /// 
        /// фиуга которая совершает движение
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение может ли совершить указаная фигура 
        /// совершить данное движение по игровой доске
        /// 
        /// </returns>
        public bool CanMove(FigureMoving figureMoving)
        {
            _figureMoving = figureMoving;

            return CanMoveFrom()
                && CanMoveTo()
                && CanFigureMove();
        }

        #endregion

        #region ---===   Private Methods   ===---

        /// <summary>
        /// 
        /// метод который описывает возможность движения фигуры с клетки
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение может ли данная фигура совершить ход с этой клетки
        /// 
        /// </returns>
        private bool CanMoveTo()
        {
            return _figureMoving.From.OnBoard()
                && _figureMoving.FigurE.GetColor() == _board.MoveColor
                && _board.GetFigureAt(_figureMoving.From) == _figureMoving.FigurE;
        }

        /// <summary>
        /// 
        /// метод который описывает возможность движения фигуры в указаную клетку
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение может ли данная фигура совершить ход в указаную клетку
        /// 
        /// </returns>
        private bool CanMoveFrom()
        {
            return _figureMoving.To.OnBoard()
                && _board.GetFigureAt(_figureMoving.To).GetColor() != _board.MoveColor;
        }

        /// <summary>
        /// 
        /// метод который описывает движение конкретных фигур
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// возвращает логическое знаение возможности совершения движения
        /// 
        /// </returns>
        private bool CanFigureMove()
        {
            switch (_figureMoving.FigurE)
            {
                case Figure.whiteKing:
                case Figure.blackKing:

                    return CanKingMove()
                        || CanKingCastle();

                case Figure.whiteQueen:
                case Figure.blackQueen:

                    return CanStraightMove();

                case Figure.whiteRook:
                case Figure.blackRook:

                    return RestrictionsRook()
                        && CanStraightMove();

                case Figure.whiteBishop:
                case Figure.blackBishop:

                    return RestrictionsBishop()
                       && CanStraightMove();

                case Figure.whiteKnight:
                case Figure.blackKnight:

                    return CanKnightMove();

                case Figure.whitePawn:
                case Figure.blackPawn:

                    return CanPawnMove();

                default:
                    return false;
            }  
        }

        #endregion

        #region ---===   Figure Move   ===---

        /// <summary>
        /// 
        /// метод который описывает алгоритм движение Короля по игровой доске
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение которое описывает 
        /// может ли Король совершить данный ход
        /// 
        /// </returns>
        private bool CanKingMove()
        {
            return (_figureMoving.AbsDeltaX <= 1) 
                && (_figureMoving.AbsDeltaY <= 1);
        }

        /// <summary>
        /// 
        /// метод который описывает алгоритм рокировки Короля
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CanKingCastle()
        {
            //  алгоритм рокировки белого короря
            if (_figureMoving.FigurE == Figure.whiteKing)
            {
                //  короткая рокировка белого короля
                if (_figureMoving.From == new Square("e1"))
                {
                    if (_figureMoving.To == new Square("g1"))
                    {
                        if (_board.CanCastleH1)
                        {
                            if (_board.GetFigureAt(new Square("h1")) == Figure.whiteRook)
                            {
                                if (_board.GetFigureAt(new Square("f1")) == Figure.none)
                                {
                                    if (_board.GetFigureAt(new Square("g1")) == Figure.none)
                                    {
                                        if (!_board.IsCheck())
                                        {
                                            if (!_board.IsCheckAfter(new FigureMoving("Ke1f1")))
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                //  длинная рокировка белого короря
                if (_figureMoving.From == new Square("e1"))
                {
                    if (_figureMoving.To == new Square("c1"))
                    {
                        if (_board.CanCastleA1)
                        {
                            if (_board.GetFigureAt(new Square("a1")) == Figure.whiteRook)
                            {
                                if (_board.GetFigureAt(new Square("b1")) == Figure.none)
                                {
                                    if (_board.GetFigureAt(new Square("c1")) == Figure.none)
                                    {
                                        if (_board.GetFigureAt(new Square("d1")) == Figure.none)
                                        {
                                            if (!_board.IsCheck())
                                            {
                                                if (!_board.IsCheckAfter(new FigureMoving("Ke1d1")))
                                                {
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //  алгоритм рокировки черного короля
            if (_figureMoving.FigurE == Figure.blackKing)
            {
                //  короткая рокировка черного короля
                if (_figureMoving.From == new Square("e8"))
                {
                    if (_figureMoving.To == new Square("g8"))
                    {
                        if (_board.CanCastleH8)
                        {
                            if (_board.GetFigureAt(new Square("h8")) == Figure.blackRook)
                            {
                                if (_board.GetFigureAt(new Square("f8")) == Figure.none)
                                {
                                    if (_board.GetFigureAt(new Square("g8")) == Figure.none)
                                    {
                                        if (!_board.IsCheck())
                                        {
                                            if (!_board.IsCheckAfter(new FigureMoving ("ke8f8")))
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //  длинная рокировка черного короля
                if (_figureMoving.From == new Square("e8"))
                {
                    if (_figureMoving.To == new Square("c8"))
                    {
                        if (_board.CanCastleA8)
                        {
                            if (_board.GetFigureAt(new Square("a8")) == Figure.blackRook)
                            {
                                if (_board.GetFigureAt(new Square("b8")) == Figure.none)
                                {
                                    if (_board.GetFigureAt(new Square("c8")) == Figure.none)
                                    {
                                        if (_board.GetFigureAt(new Square("d8")) == Figure.none)
                                        {
                                            if (!_board.IsCheck())
                                            {
                                                if (!_board.IsCheckAfter(new FigureMoving("ke8d8")))
                                                {
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
           
            return false;
        }

        /// <summary>
        /// 
        /// метод который описывает алгоритм движения Коня по игровой доске
        /// 
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение которое описывает 
        /// может ли Конь совершить данный ход
        /// 
        /// </returns>
        private bool CanKnightMove()
        {
            return (_figureMoving.AbsDeltaX == 1 && _figureMoving.AbsDeltaY == 2)
                || (_figureMoving.AbsDeltaX == 2 && _figureMoving.AbsDeltaY == 1);
        }

        /// <summary>
        /// 
        /// метод который описывает алгоритм движения Фигуры Прямо
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение которое описывает 
        /// может ли Фигура совершить ход прямо
        /// 
        /// </returns>
        private bool CanStraightMove()
        {
            Square at = _figureMoving.From;

            do
            {
                at = new Square(at.X + _figureMoving.SignX,
                                at.Y + _figureMoving.SignY);

                if (at == _figureMoving.To)
                {
                    return true;
                }

            } while (at.OnBoard() 
                  && _board.GetFigureAt(at) == Figure.none);

            return false;
        }

        /// <summary>
        /// 
        /// метод который описывает алгоритм движения Пешки по игровой доске
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение которое описывает 
        /// может ли Пешка совершить ход
        /// 
        /// </returns>
        private bool CanPawnMove()
        {
            if (_figureMoving.From.Y < 1 
             || _figureMoving.From.Y > 6) //ToDo: заменить магические значения на константы
            {   // пешка не может находится на 1 и на 6 
                return false;
            }

            int stepY = _figureMoving.FigurE.GetColor() == Color.white ? +1 : -1;

            return CanpawnGo(stepY)     //+1    
                || CanPawnJump(stepY)   //+2
                || CanPawnEat(stepY)
                || CanPawnEnpassant(stepY);   
        }

        /// <summary>
        /// 
        /// метод который описывает алгоритм движения Пешки прямо
        /// 
        /// </summary>
        private bool CanpawnGo(int stepY)
        {
            if (_board.GetFigureAt(_figureMoving.To) == Figure.none)
            {
                if (_figureMoving.DeltaX == 0)
                {
                    if (_figureMoving.DeltaY == stepY)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// метод который описывает алгоритм прыжка Пешки
        /// 
        /// </summary>
        private bool CanPawnJump(int stepY)
        {
            if (_board.GetFigureAt(_figureMoving.To) == Figure.none)
            {
                if (_figureMoving.From.Y == 1 && stepY == +1
                 || _figureMoving.From.Y == 6 && stepY == -1)
                {
                    if (_figureMoving.DeltaX == 0)
                    {
                        if (_figureMoving.DeltaY == (stepY + stepY))
                        {
                            if (_board.GetFigureAt(new Square(
                                _figureMoving.From.X, 
                                _figureMoving.From.Y + stepY)) 
                             == Figure.none)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// метод который описывает алгоритм взятия Пешки
        /// 
        /// </summary>
        private bool CanPawnEat(int stepY)
        {
            if (_board.GetFigureAt(_figureMoving.To) != Figure.none)
            {
                if (_figureMoving.AbsDeltaX == 1)
                {
                    if (_figureMoving.DeltaY == stepY)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///  
        /// метод который описывает взятие пешки на проходе
        /// 
        /// </summary>
        private bool CanPawnEnpassant(int stepY)
        {
            if (_figureMoving.To == _board.Enpassant)
            {
                if (_board.GetFigureAt(_figureMoving.To) == Figure.none)
                {
                    if (_figureMoving.DeltaY == stepY)
                    {
                        if (_figureMoving.AbsDeltaX == 1)
                        {
                            if (stepY == +1 && _figureMoving.From.Y == 4
                             || stepY == -1 && _figureMoving.From.Y == 3)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// 
        /// метод который ограничивает движение Ладьи по игровому полю
        /// 
        /// </summary>
        private bool RestrictionsRook()
        {
            return (_figureMoving.SignX == 0
                 || _figureMoving.SignY == 0);
        }

        /// <summary>
        /// 
        /// метод который ограничивает движение Слона по игровому полю
        /// 
        /// </summary>
        private bool RestrictionsBishop()
        {
            return (_figureMoving.SignX != 0
                 && _figureMoving.SignY != 0);
        }

        #endregion

    }
}



