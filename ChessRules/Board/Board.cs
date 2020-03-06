using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// класс который описывает игровую доску
    /// 
    /// </summary>
    class Board
    {
        #region ---===   Private   ===---

        private string _fen;
        private Color _moveColor;

        private bool _canCastleA1;  //возможность рокировка K
        private bool _canCastleH1;  //возможность рокировка Q
        private bool _canCastleA8;  //возможность рокировка k
        private bool _canCastleH8;  //возможность рокировка q

        private Square _enpassant;  //клетка битого поля

        private int _drawNumber;    //номер хода для проверки правила 50 ходов
        private int _moveNumber;

        #endregion

        #region ---===   Protected   ===---

        /// <summary>
        /// 
        /// матрица которая описывает игровую доску
        /// 
        /// </summary>
        protected Figure[,] _figures;

        #endregion

        #region ---===   Get / Set   ===---

        public string Fen
        {
            get 
            {
                return _fen;
            }
            protected set
            {
                _fen = value;
            }
        }

        public Color MoveColor
        {
            get 
            { 
                return _moveColor;
            }
            protected set
            {
                _moveColor = value;
            }
        }

        /// <summary>
        /// 
        /// индексатор))
        /// 
        /// </summary>
        /// 
        /// <param name="square">
        /// 
        /// передаваемая клетка
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращает или устанавливает фигуру 
        /// 
        /// </returns>
        public Figure this[Square square]
        {
            get
            {
                if (!square.OnBoard())
                {
                    return Figure.none;
                }

                return _figures[square.X, square.Y];
            }
            protected set
            {
                if (square.OnBoard())
                {
                    _figures[square.X, square.Y] = value;
                }
            }
        }

        public bool CanCastleA1
        {
            get 
            {
                return _canCastleA1;
            }
            protected set 
            {
                _canCastleA1 = value;
            }
        }

        public bool CanCastleH1
        {
            get
            {
                return _canCastleH1;
            }
            protected set
            {
                _canCastleH1 = value;
            }
        }

        public bool CanCastleA8
        {
            get
            {
                return _canCastleA8;
            }
            protected set
            {
                _canCastleA8 = value;
            }
        }

        public bool CanCastleH8
        {
            get
            {
                return _canCastleH8;
            }
            protected set
            {
                _canCastleH8 = value;
            }
        }

        public Square Enpassant
        {
            get
            {
                return _enpassant;
            }
            protected set
            {
                _enpassant = value;
            }
        }

        public int DrawNumber
        {
            get
            {
                return _drawNumber;
            }
            protected set
            {
                _drawNumber = value;
            }
        }

        public int MoveNumber
        {
            get
            {
                return _moveNumber;
            }
            protected set
            {
                _moveNumber = value;
            }
        }



        #endregion

        #region ---===   Ctor   ===---

        public Board(string fen)
        {
            _fen = fen;
            _figures = new Figure[8, 8];  //ToDo: заменить магические значения на константы
            Init();
        }

        #endregion

        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// метод которы отвечает за движение фигур по игровой доске
        /// 
        /// </summary>
        /// 
        /// <param name="figureMoving">
        /// 
        /// фигура которая совершает ход
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращает новую игровую доску
        /// 
        /// </returns>
        public Board Move(FigureMoving figureMoving)
        {
            return new NextBoard(_fen, figureMoving);
        }

        /// <summary>
        /// 
        /// перебора всех фигур текущего игрока на игровой доске 
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает все фигуры текущего игрока
        /// 
        /// </returns>
        public IEnumerable<FigureOnSquare> YieldFiguresOnSquare()
        {
            foreach (Square square in Square.YieldBoardSquare())
            {
                if (GetFigureAt(square).GetColor() == MoveColor)
                {
                    yield return new FigureOnSquare(GetFigureAt(square), square);
                }
            }
        }

        /// <summary>
        /// 
        /// метод для получения фигуры на клетки игровой доски
        /// 
        /// </summary>
        /// 
        /// <param name="square">
        /// 
        /// клетка с которой нужно вернуть фигуру
        /// 
        /// </param>
        /// <returns>
        /// 
        /// возвращает фигуру стоящую на клетки 
        /// если клетка находится за пределами 
        /// доски возращает пустую фигуру 
        /// 
        /// </returns>
        public Figure GetFigureAt(Square square)
        {
            return this[square];
        }

        /// <summary>
        /// 
        /// метод для проверка шага для нашего короля
        /// 
        /// </summary>
        public bool IsCheck()
        {
            return IsCheckAfter(FigureMoving.None);
        }

        /// <summary>
        /// 
        /// метод проверки шага королю после выполнения хода
        /// 
        /// </summary>
        /// 
        /// <param name="figureMoving"> 
        /// 
        /// фигура которая совершает ход
        /// 
        /// </param>
        public bool IsCheckAfter(FigureMoving figureMoving)
        {
            Board after = Move(figureMoving);

            return after.CanEatKing();
        }

        #endregion

        #region ---===   Private Method   ===---

        /// <summary>
        /// 
        /// метод для инициализации FENa (парсинг)
        /// 
        /// </summary>
        private void Init()
        {
            //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
            //0                                           1 2    3 4 5

            string[] parts = _fen.Split();
            InitFigures(parts[0]);
            InitMoveColor(parts[1]);
            InitCastleFlags(parts[2]);
            InitEnpassant(parts[3]);
            InitDrawNumber(parts[4]);
            InitMoveNumber(parts[5]);
        }

        /// <summary>
        /// 
        /// алгоритм проверки возможности сьедения вражеского короля
        /// 
        /// </summary>
        private bool CanEatKing()
        {
            Square badKing = FindBadKing();
            Moves move = new Moves(this);

            foreach (FigureOnSquare figureOnSquare in YieldFiguresOnSquare())
            {
                if (move.CanMove(new FigureMoving (figureOnSquare, badKing)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// метод поиска вражеского короля на игровой доске
        /// 
        /// </summary>
        private Square FindBadKing()
        {
            Figure badKing = MoveColor == Color.white
                    ? Figure.blackKing
                    : Figure.whiteKing;

            foreach (Square square in Square.YieldBoardSquare())
            {
                if (GetFigureAt(square) == badKing)
                {
                    return square;
                }
            }

            return Square.None;
        }

        #endregion

        #region ---===   Init_FEN   ===---

        /// <summary>
        /// 
        /// метод для инициализации фигур используя 0 часть FENa
        /// 
        /// </summary>
        /// 
        /// <param name="parts_0">
        /// 
        /// часть FENa в которой распологаются фигуры
        /// 
        /// </param>
        private void InitFigures(string parts_0)
        {
            parts_0 = ParseFEN_AndReplaceOnFigureNone(parts_0);

            string[] lines = parts_0.Split('/');

            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    _figures[x, y] = (Figure)lines[7 - y][x];
                }
            }
        }

        /// <summary>
        /// 
        /// метод для парсинга пустых ячеек на игровом поле используя FEN 
        /// 
        /// </summary>
        /// 
        /// <param name="str">
        /// 
        /// 
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращает строку в которой пустые елементы заменены на Отсутствие фигуры
        /// 
        /// </returns>
        private static string ParseFEN_AndReplaceOnFigureNone(string str)
        {
            // 8 --> 71 --> 611 -->> 1111_1111
            for (int j = 8; j >= 2; j--)
            {
                str = str.Replace(j.ToString(), (j - 1).ToString() + "1");
            }

            str = str.Replace('1', (char)Figure.none);

            return str;
        }

        /// <summary>
        /// 
        /// метод для инициализации цвета игрока
        /// 
        /// </summary>
        /// 
        /// <param name="parts_1">
        /// 
        /// часть FENa где располагается цвет игрока который сейчас совершает ход
        /// 
        /// </param>
        private void InitMoveColor(string parts_1)
        {
            if (parts_1 == "b")
            {
                _moveColor = Color.black;
            }
            else
            {
                _moveColor = Color.white;
            }
        }

        /// <summary>
        /// 
        /// метод для инициализации возможности рокировки 
        /// 
        /// </summary>
        /// 
        /// <param name="parts_2">
        /// 
        /// часть FENa где располагается возможность совершения рокировки
        /// 
        /// </param>
        private void InitCastleFlags(string parts_2)
        {
            _canCastleA1 = parts_2.Contains("Q");
            _canCastleH1 = parts_2.Contains("K");
            _canCastleA8 = parts_2.Contains("q");
            _canCastleH8 = parts_2.Contains("k");
        }

        /// <summary>
        /// 
        /// метод который инициализирует возможность взятие на проходе
        /// 
        /// </summary>
        /// 
        /// <param name="part_3">
        /// 
        /// часть FENa где располагается возможность взятия пешки на проходе
        /// 
        /// </param>
        private void InitEnpassant(string part_3)
        {
            _enpassant = new Square(part_3);
        }

        /// <summary>
        /// 
        /// метод который инициализирует номер хода для определения ничьи
        /// 
        /// </summary>
        /// 
        /// <param name="part_4">
        /// 
        /// часть FENa где располагается счётчик полуходов. 
        /// Число полуходов, прошедших с последнего хода пешки или взятия фигуры. 
        /// используется для определения применения правила 50 ходов.
        /// 
        /// </param>
        private void InitDrawNumber(string part_4)
        {
            _drawNumber = int.Parse(part_4);
        }

        /// <summary>
        /// 
        /// метод который инициализирует текуший номер хода  
        /// 
        /// </summary>
        /// 
        /// <param name="part_5">
        /// 
        /// часть FENa где располагается текуший номер хода.
        /// счётчик увеличивается на 1 после каждого хода чёрных.
        /// 
        /// </param>
        private void InitMoveNumber(string part_5)
        {
            _moveNumber = int.Parse(part_5);
        }

        #endregion

    }
}
