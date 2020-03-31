using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// Первое Тестирование
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// 
    /// глубина рекурсивного тестирования
    /// 
    /// глубиа: 1   =   48
    ///         2   =   2039
    ///         3   =   97862
    /// 
    /// </returns>
    sealed class FirstTesting : Test, ITesting
    {
        #region ---===   Private   ===---

        private static readonly string testingFEN = "r3k2r/p1ppqpb1/bn2pnp1/3PN3/1p2P3/2N2Q1p/PPPBBPPP/R3K2R w KQkq - 0 1";

        #endregion

        #region ---===   Constant Testing   ===---

        private const int depthTest_0 = 1;
        private const int depthTest_1 = 48;
        private const int depthTest_2 = 2039;
        private const int depthTest_3 = 97862;

        #endregion

        #region ---===   IStartTesting   ===---

        public bool StartTest()
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
