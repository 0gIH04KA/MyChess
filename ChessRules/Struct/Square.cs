using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// структура для описания клетки игрового поля
    /// 
    /// </summary>

    #region Pragma Warning Disable

    /// <summary>
    /// 
    /// отсутствует переопределение Object.Equals(object o)
    /// 
    /// </summary>
#pragma warning disable 660

    /// <summary>
    /// 
    /// отсутствует переопределение Object.GetHashCode()
    /// 
    /// </summary>
    /// 
#pragma warning disable 661

    #endregion

    struct Square
    {
        #region ---===   Private   ===---

        /// <summary>
        /// 
        /// none - отсутсвующая координата на игровой доске
        /// 
        /// </summary>
        private static Square none = new Square(-1, -1);

        private int _x;
        private int _y;

        #endregion

        #region ---===   Get / Set   ===---

        public int X
        {
            get
            {
                return _x;
            }
            private set 
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            private set
            {
                _y = value;
            }
        }

        public static Square None
        {
            get 
            {
                return none;
            }
        }

        /// <summary>
        /// 
        /// получение имени координаты в игровом пространстве
        /// 
        /// </summary>
        public string Name
        {
            get 
            {
                if (OnBoard())
                {
                    return (((char)('a' + _x)).ToString()
                            + (_y + 1).ToString());    //ToDo: заменить магические значения на константы
                }
                else
                {
                    return "-";
                }
               
            }
        }

        #endregion

        #region ---===   Ctor   ===---

        /// <summary>
        /// 
        /// стандартный конструктор для установки координат
        /// через целочисленное значение
        /// 
        /// </summary>
        /// 
        /// <param name="x">
        /// 
        /// координата по Х
        /// 
        /// </param>
        /// 
        /// <param name="y">
        /// 
        /// координата по Х
        /// 
        /// </param>
        public Square(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// 
        /// дополнительный конструктор для установки координат 
        /// через строковое представление
        /// 
        /// </summary>
        /// 
        /// <param name="name">
        /// 
        /// строковое представление координаты на игровом поле
        /// 
        /// </param>
        public Square(string name)
        {
            if (name.Length == 2
             && name[0] >= 'a' && name[0] <= 'h'
             && name[1] >= '1' && name[1] <= '8')   //ToDo: заменить магические значения на константы
            {
                _x = name[0] - 'a';
                _y = name[1] - '1';
            }
            else
            {
                this = none;
            }
        }

        #endregion

        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// проверка координаты в пределах игрового поля
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 
        /// возвращает логическое значение нахождения клетки в пределах игрового поля
        /// 
        /// </returns>
        public bool OnBoard() //ToDo: заменить магические значения на константы
        {
            return (_x >= 0 && _x < 8)
                && (_y >= 0 && _y < 8);
        }

        /// <summary>
        /// 
        /// перебора всех клеток игрового поля
        /// 
        /// </summary>
        public static IEnumerable<Square> YieldBoardSquare()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    yield return new Square(x, y);
                }
            }
        }

        #endregion

        #region ---===   Overloading Operator   ===---

        public static bool operator ==(Square a, Square b)
        {
            return a.X == b.X
                && a.Y == b.Y;
        }

        public static bool operator !=(Square a, Square b)
        {
            return !(a == b);
        }

        #endregion

    }
}
 