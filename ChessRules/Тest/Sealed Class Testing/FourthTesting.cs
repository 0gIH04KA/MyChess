using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// Четвертое Тестирование
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// 
    /// глубина рекурсивного тестирования
    /// 
    /// глубиа: 1   =   44
    ///         2   =   1486
    ///         3   =   62379
    /// 
    /// </returns>
    sealed class FourthTesting : Test, ITesting
    {
        #region ---===   Private   ===---

        private static readonly string testingFEN = "rnbq1k1r/pp1Pbppp/2p5/8/2B5/8/PPP1NnPP/RNBQK2R w KQ - 1 8 ";

        #endregion

        #region ---===   Constant Testing   ===---

        private const int depthTest_0 = 1;
        private const int depthTest_1 = 44;
        private const int depthTest_2 = 1506; //1486;
        private const int depthTest_3 = 62379;

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
