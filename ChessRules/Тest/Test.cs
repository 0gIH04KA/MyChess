using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// https://www.chessprogramming.org/Perft_Results
    /// 
    /// </summary>
    public class Test
    {
        #region ---===   Type FEN   ===---

        /// <summary>
        /// 
        /// первый фен для тестирования
        /// 
        /// </summary>
        private const string firstTestFEN = "r3k2r/p1ppqpb1/bn2pnp1/3PN3/1p2P3/2N2Q1p/PPPBBPPP/R3K2R w KQkq - 0 1";

        /// <summary>
        /// 
        /// второй фен для тестирования
        /// 
        /// </summary>
        private const string secondTestFEN = "8/2p5/3p4/KP5r/1R3p1k/8/4P1P1/8 w - - 0 1";

        /// <summary>
        /// 
        /// третий фен для тестирования
        /// 
        /// </summary>
        private const string thirdTestFEN = "r3k2r/Pppp1ppp/1b3nbN/nP6/BBP1P3/q4N2/Pp1P2PP/R2Q1RK1 w kq - 0 1";

        /// <summary>
        /// 
        /// четвертый фен для тестирования
        /// 
        /// </summary>
        private const string fourthTestFEN = "rnbq1k1r/pp1Pbppp/2p5/8/2B5/8/PPP1NnPP/RNBQK2R w KQ - 1 8 ";

        /// <summary>
        /// 
        /// пятый фен для тестирования
        /// 
        /// </summary>
        private const string fiveTestFEN = "r4rk1/1pp1qppp/p1np1n2/2b1p1B1/2B1P1b1/P1NP1N2/1PP1QPPP/R4RK1 w - - 0 10 ";

        #endregion

        #region ---===   Prevate Methods   ===---

        /// <summary>
        /// 
        /// рекурсивное тестирование шахматного движка
        /// 
        /// </summary>
        /// 
        /// <param name="step">
        /// 
        /// глубина тестирования
        /// 
        /// </param>
        /// 
        /// <param name="chess">
        /// 
        /// FEN позиция игры
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращает колличество возможных ходов для проверки с ресурсом тестирования
        /// 
        /// </returns>
        private static int NextMoves(int step, Chess chess)
        {
            if (step == 0)
            {
                return 1;
            }

            int count = 0;
            foreach (string moves in chess.YieldValidMoves())
            {
                count += NextMoves(step - 1, chess.Move(moves));
            }

            return count;
        }

        #endregion

        #region ---===   Standart Test    ===---

        /// <summary>
        /// 
        /// Тестирование стандартного FEN
        /// 
        /// </summary>
        /// 
        /// <param name="val">
        /// 
        /// глубина рекурсивного тестирования
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// глубиа: 0   =   1
        ///         1   =   20
        ///         2   =   400
        ///         3   =   8902
        /// 
        /// </returns>
        public static int StandartTest(int val)
        {
            Chess chess = new Chess(Constant.startingFEN);

            return (NextMoves(val, chess));
        }

        #endregion

        #region ---===   First Test   ===---

        /// <summary>
        /// 
        /// Первое Тестирование
        /// 
        /// </summary>
        /// 
        /// <param name="val">
        /// 
        /// глубина рекурсивного тестирования
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// глубиа: 1   =   48
        ///         2   =   2039
        ///         3   =   97862
        /// 
        /// </returns>
        public static int FirstTest(int val)
        {
            Chess chess = new Chess(firstTestFEN);

            return (NextMoves(val, chess));
        }

        #endregion

        #region ---===   Second Test   ===---

        /// <summary>
        /// 
        /// Второе Тестирование
        /// 
        /// </summary>
        /// 
        /// <param name="val">
        /// 
        /// глубина рекурсивного тестирования
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// глубиа: 1   =   14
        ///         2   =   191
        ///         3   =   2812
        ///         4   =   43238
        /// 
        /// </returns>
        public static int SecondTest(int val)
        {
            Chess chess = new Chess(secondTestFEN);

            return (NextMoves(val, chess));
        }

        #endregion

        #region ---===   Third Test   ===---

        /// <summary>
        /// 
        /// Третье Тестирование
        /// 
        /// </summary>
        /// 
        /// <param name="val">
        /// 
        /// глубина рекурсивного тестирования
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// глубиа: 1   =   6
        ///         2   =   264
        ///         3   =   9467
        /// 
        /// </returns>
        public static int ThirdTest(int val)
        {
            Chess chess = new Chess(thirdTestFEN);

            return (NextMoves(val, chess));
        }

        #endregion

        #region ---===   Fourth Test   ===---

        /// <summary>
        /// 
        /// Четвертое Тестирование
        /// 
        /// </summary>
        /// 
        /// <param name="val">
        /// 
        /// глубина рекурсивного тестирования
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// глубиа: 1   =   44
        ///         2   =   1486
        ///         3   =   62379
        /// 
        /// </returns>
        public static int FourthTest(int val)
        {
            Chess chess = new Chess(fourthTestFEN);

            return (NextMoves(val, chess));
        }
        #endregion

        #region ---===   Five Test   ===---

        /// <summary>
        /// 
        /// Пятое Тестирование
        /// 
        /// </summary>
        /// 
        /// <param name="val">
        /// 
        /// глубина рекурсивного тестирования
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// глубиа: 0   =   1
        ///         1   =   46
        ///         2   =   2079
        ///         3   =   89890
        /// 
        /// </returns>
        public static int FiveTest(int val)
        {
            Chess chess = new Chess(fiveTestFEN);

            return (NextMoves(val, chess));
        }

        #endregion

    }
}
