using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// Пятое Тестирование
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// 
    /// глубина рекурсивного тестирования
    /// 
    /// глубиа: 0   =   1
    ///         1   =   46
    ///         2   =   2079
    ///         3   =   89890
    /// 
    /// </returns>
    sealed class FiveTesting : Test, ITesting
    {
        #region ---===   Private   ===---

        private static readonly string testingFEN = "r4rk1/1pp1qppp/p1np1n2/2b1p1B1/2B1P1b1/P1NP1N2/1PP1QPPP/R4RK1 w - - 0 10 ";

        #endregion

        #region ---===   Constant Testing   ===---

        private const int depthTest_0 = 1;
        private const int depthTest_1 = 46;
        private const int depthTest_2 = 2079;
        private const int depthTest_3 = 89890;

        #endregion

        #region ---===   Override Method   ===---

        protected override bool StartTest()
        {
            return ZeroTest() && FirstTest() && SecondTest() && ThirdTest();
        }

        #endregion

        #region ---===   ITesting   ===---

        public bool ZeroTest(int val = 0)
        {
            try
            {
                int zeroTest = StandartTest(val, testingFEN);

                if (zeroTest != depthTest_0)
                {
                    throw new ZeroTestException($"Count on Testing = {zeroTest}. Desired Result = {depthTest_0}");
                }
            }
            catch (CheckMateException)
            {

            }
            catch (StealMateException)
            {

            }

            return true;

        }

        public bool FirstTest(int val = 1)
        {
            try
            {
                int firstTest = StandartTest(val, testingFEN);

                if (firstTest != depthTest_1)
                {
                    throw new FirstTestException($"Count on Testing = {firstTest}. Desired Result = {depthTest_1}");
                }
            }
            catch (CheckMateException)
            {

            }
            catch (StealMateException)
            {

            }

            return true;
        }

        public bool SecondTest(int val = 2)
        {
            try
            {
                int secondTest = StandartTest(val, testingFEN);

                if (secondTest != depthTest_2)
                {
                    throw new SecondTestException($"Count on Testing = {secondTest}. Desired Result = {depthTest_2}");
                }
            }
            catch (CheckMateException)
            {

            }
            catch (StealMateException)
            {

            }

            return true;
        }

        public bool ThirdTest(int val = 3)
        {
            try
            {
                int thirdTest = StandartTest(val, testingFEN);

                if (thirdTest != depthTest_3)
                {
                    throw new ThirdTestException($"Count on Testing = {thirdTest}. Desired Result = {depthTest_3}");
                }
            }
            catch (CheckMateException)
            {

            }
            catch (StealMateException)
            {

            }

            return true;
        }

        #endregion
    }
}
