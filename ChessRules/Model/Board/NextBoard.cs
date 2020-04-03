using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// класс который может изменять игровую доску
    /// 
    /// </summary>
    class NextBoard : Board
    {
        #region ---===   Private   ===---

        private FigureMoving _figureMoving;

        #endregion

        #region ---===   Ctor   ===---

        public NextBoard(string fen, FigureMoving figureMoving)
            : base(fen)
        {
            _figureMoving = figureMoving;

            MoveFigures();

            DropEnpassant();
            SetEnpassant();

            MoveCastlingRook();
            UpdateCastleFlags();

            UpdateMoveNumber();
            UpdateMoveColor();

            GenerateFEN();
        }

        #endregion

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// метод который реализует движение фигур по игровой доске
        /// 
        /// </summary>
        private void MoveFigures()
        {
            SetFigureAt(_figureMoving.From, Figure.none);
            SetFigureAt(_figureMoving.To, _figureMoving.PlacedFigure);
        }

        /// <summary>
        /// 
        /// метод который реализует взятие пешки на проходе
        /// 
        /// </summary>
        private void DropEnpassant()
        {
            if (_figureMoving.To == Enpassant)
            {
                if (_figureMoving.FigurE == Figure.blackPawn 
                 || _figureMoving.FigurE == Figure.whitePawn)
                {
                    SetFigureAt(new Square(_figureMoving.To.X, _figureMoving.From.Y), Figure.none);
                }
            }
        }

        /// <summary>
        /// 
        /// установка битого поля при движение пешки на 2 клетки
        /// 
        /// </summary>
        private void SetEnpassant()
        {
            Enpassant = Square.None;

            if (_figureMoving.FigurE == Figure.whitePawn)
            {
                if (_figureMoving.From.Y == ConstantForPawn.START_HORIZONTAL_WHITE_PAWN
                 && _figureMoving.To.Y == ConstantForPawn.JUMP_HORIZONTAL_WHITE_PAWN)    
                {
                    Enpassant = new Square(_figureMoving.From.X, ConstantForPawn.HORIZONTAL_WHITE_ENPASSANT);
                }
            }

            if (_figureMoving.FigurE == Figure.blackPawn)
            {
                if (_figureMoving.From.Y == ConstantForPawn.START_HORIZONTAL_BLACK_PAWN
                 && _figureMoving.To.Y == ConstantForPawn.JUMP_HORIZONTAL_BLACK_PAWN)   
                {
                    Enpassant = new Square(_figureMoving.From.X, ConstantForPawn.HORIZONTAL_BLACK_ENPASSANT);
                }
            }
        }

        /// <summary>
        /// 
        /// метод для установки фигуры на игровую клетку 
        /// 
        /// </summary>
        /// 
        /// <param name="square">
        /// 
        /// клетка на которую хотим установить 
        /// 
        /// </param>
        /// 
        /// <param name="figure">
        /// 
        /// фигура которую хотим установить
        /// 
        /// </param>
        private void SetFigureAt(Square square, Figure figure)
        {
            this[square] = figure;
        }

        /// <summary>
        /// 
        /// смена номера хода
        /// 
        /// </summary>
        private void UpdateMoveNumber()
        {
            if (MoveColor == Color.black)
            {
                MoveNumber++;
            }
        }

        /// <summary>
        /// 
        /// смена цвета игрока который совершил ход
        /// 
        /// </summary>
        private void UpdateMoveColor()
        {
            MoveColor = MoveColor.FlipColor();
        }

        /// <summary>
        /// 
        /// алгоритм перемещения ладьи при рокирвоки
        /// 
        /// </summary>
        private void MoveCastlingRook()
        {
            //  перемещение белой ладьи при короткой рокировке
            if (_figureMoving.FigurE == Figure.whiteKing)
            {
                if (_figureMoving.From == new Square(ConstantForCastle.CELL_WHITE_KING))     
                {
                    if (_figureMoving.To == new Square(ConstantForCastle.CELL_WHITE_RIGHT_KNIGHT))
                    {
                        SetFigureAt(new Square(ConstantForCastle.CELL_WHITE_RIGHT_ROOK), Figure.none);
                        SetFigureAt(new Square(ConstantForCastle.CELL_WHITE_RIGHT_BISHOP), Figure.whiteRook);

                        return;
                    }
                }
            }

            //  перемещение белой ладьи при длинной рокировке
            if (_figureMoving.FigurE == Figure.whiteKing)
            {
                if (_figureMoving.From == new Square(ConstantForCastle.CELL_WHITE_KING))
                {
                    if (_figureMoving.To == new Square(ConstantForCastle.CELL_WHITE_LEFT_BISHOP))
                    {
                        SetFigureAt(new Square(ConstantForCastle.CELL_WHITE_LEFT_ROOK), Figure.none);
                        SetFigureAt(new Square(ConstantForCastle.CELL_WHITE_QUEEN), Figure.whiteRook);

                        return;
                    }
                }
            }

            //  перемещение черной ладьи при короткой рокировке
            if (_figureMoving.FigurE == Figure.blackKing)
            {
                if (_figureMoving.From == new Square(ConstantForCastle.CELL_BLACK_KING))
                {
                    if (_figureMoving.To == new Square(ConstantForCastle.CELL_BLACK_RIGHT_KNIGHT))
                    {
                        SetFigureAt(new Square(ConstantForCastle.CELL_BLACK_RIGHT_ROOK), Figure.none);
                        SetFigureAt(new Square(ConstantForCastle.CELL_BLACK_RIGHT_BISHOP), Figure.blackRook);

                        return;
                    }
                }
            }

            //  перемещение черной ладьи при длинной рокировке
            if (_figureMoving.FigurE == Figure.blackKing)
            {
                if (_figureMoving.From == new Square(ConstantForCastle.CELL_BLACK_KING))
                {
                    if (_figureMoving.To == new Square(ConstantForCastle.CELL_BLACK_LEFT_BISHOP))
                    {
                        SetFigureAt(new Square(ConstantForCastle.CELL_BLACK_LEFT_ROOK), Figure.none);
                        SetFigureAt(new Square(ConstantForCastle.CELL_BLACK_QUEEN), Figure.blackRook);

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// алгоритм обновления флагов разрешающие рокировку 
        /// 
        /// </summary>
        private void UpdateCastleFlags()
        {
            switch (_figureMoving.FigurE)
            {

                case Figure.whiteKing:

                    CanCastleA1 = false;
                    CanCastleH1 = false;

                    return;

                case Figure.whiteRook:

                    if (_figureMoving.From == new Square(ConstantForCastle.CELL_WHITE_LEFT_ROOK))
                    {
                        CanCastleA1 = false;
                    }

                    if (_figureMoving.From == new Square(ConstantForCastle.CELL_WHITE_RIGHT_ROOK))
                    {
                        CanCastleH1 = false;
                    }

                    return;

                case Figure.blackKing:

                    CanCastleA8 = false;
                    CanCastleH8 = false;

                    return;
               
                case Figure.blackRook:

                    if (_figureMoving.From == new Square(ConstantForCastle.CELL_BLACK_LEFT_ROOK))
                    {
                        CanCastleA8 = false;
                    }

                    if (_figureMoving.From == new Square(ConstantForCastle.CELL_BLACK_RIGHT_ROOK))
                    {
                        CanCastleH8 = false;
                    }

                    return;

                default: return;
            }
        }

        /// <summary>
        /// 
        /// метод для генерации FENa по текущему расположению фигур
        /// 
        /// </summary>
        private void GenerateFEN()
        {
            Fen = FEN_Figures() + " "
                 + FEN_MoveColor() + " "
                 + FEN_CastleFlags() + " "
                 + FEN_Enpassant() + " "
                 + FEN_DrawNumber() + " "
                 + FEN_MoveNumber();
        }

        #endregion

        #region ---===   Generate_FEN   ===---

        /// <summary>
        /// 
        /// определение позиции фигур по текущему FEN
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает строковое представление фигур
        /// 
        /// </returns>
        private string FEN_Figures()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    sb.Append(_figures[x, y] == Figure.none
                        ? '1'   // особеность добавления пустой фигуры (иначе работает не корректно)
                        : (char)_figures[x, y]);
                }

                if (y > 0)
                {
                    sb.Append("/");
                }
            }

            sb = ConverteToStandartFEN(sb);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// метод для приведения FENa к стандартному виду
        /// 
        /// </summary>
        /// 
        /// <param name="sb">
        /// 
        /// строковое представление текушего FENa
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращает приведенный FEN
        /// 
        /// </returns>
        private static StringBuilder ConverteToStandartFEN(StringBuilder sb)
        {
            string str = "11111111";

            for (int j = 8; j >= 2; j--)
            {
                sb = sb.Replace(str.Substring(0, j), j.ToString());
            }

            return sb;
        }

        /// <summary>
        /// 
        /// определение цвета игрока чей сейчас ход
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// влзврашает строковое представление цвета игровка
        /// 
        /// </returns>
        private string FEN_MoveColor()
        {
            return MoveColor == Color.white ? "w" : "b";
        }

        /// <summary>
        /// 
        /// определение возможности совершить рокировку
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает строковое предствление возможности рокировки
        /// 
        /// </returns>
        private string FEN_CastleFlags()
        {
            string flags =
                (CanCastleA1 ? "K" : "") +
                (CanCastleH1 ? "Q" : "") +
                (CanCastleA8 ? "k" : "") +
                (CanCastleH8 ? "q" : "");

            if (flags == "")
            {
                flags = "-";
            }

            return flags;
        }

        /// <summary>
        /// 
        /// определение возможности взятия пешки на прохоже
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает строковое возможности взтия
        /// 
        /// </returns>
        private string FEN_Enpassant()
        {
            return Enpassant.Name;
        }

        /// <summary>
        /// 
        /// определение номера нечьи
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает строковое представление номера нечьи
        /// 
        /// </returns>
        private string FEN_DrawNumber()
        {
            return DrawNumber.ToString();
        }

        /// <summary>
        /// 
        /// определение номера текущего хода
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает строковое представление номера текущего хода 
        /// 
        /// </returns>
        private string FEN_MoveNumber()
        {
            return MoveNumber.ToString();
        }

        #endregion

    }
}
