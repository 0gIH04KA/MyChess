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
    public class Test : ITestModel
    {
        #region ---===   Static Members   ===---

        public static Random random = new Random();

        #endregion

        #region ---===   Public Methods   ===---

        public bool ModelTesting()
        {
            IStartTesting test = InitRandomTest();

            try
            {
                return test.StartTest();
            }
            catch (FailStandartTestException)
            {

                throw;
            }
            catch (FailFirstTestException)
            {

                throw;
            }
            catch (FailSecondTestException)
            {

                throw;
            }
            catch (FailThridTestException)
            {

                throw;

            }
            catch (FailFourthTestException)
            {

                throw;
            }
            catch (FailFiveTestException)
            {

                throw;
            }

        }

        #endregion

        #region ---===   Protected Methods   ===---

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
        protected static int NextMoves(int step, Chess chess)
        {
            if (step == 0)
            {
                return 1;
            }

            int count = 0;

            foreach (string moves in chess.YieldValidMoves())
            {
                try
                {
                    count += NextMoves(step - 1, chess.Move(moves));
                }
                catch (CheckMateException)
                {
                    count++;

                    continue;
                }
                catch (StealMateException)
                {
                    count++;

                    continue;
                }
                
            }

            return count;
        }

        protected static int StandartTest(int val, string testingFEN)
        {
            Chess chess = new Chess(testingFEN);

            return (NextMoves(val, chess));
        }

        #endregion

        #region ---===   Private Methods   ===---

        private IStartTesting InitRandomTest(int countTest = -1)
        {
            if (countTest < 0 || countTest > ConstantForTest.COUNT_TEST)
            {
                countTest = random.Next(0, ConstantForTest.COUNT_TEST + 1);
            }

            IStartTesting test;

            switch (countTest)
            {
                case 0:
                    test = new StandartTesting();
                    break;

                case 1:
                    test = new FirstTesting();
                    break;

                case 2:
                    test = new SecondTesting();
                    break;

                case 3:
                    test = new ThirdTesting();
                    break;

                case 4:
                    test = new FourthTesting();
                    break;

                case 5:
                    test = new FiveTesting();
                    break;

                default:

                    throw new Exception();
            }

            return test;
        }

        #endregion

        #region ---===   Override Methods   ===---

        public override string ToString()
        {
            return string.Format($"Test");
        }

        #endregion

    }
}
