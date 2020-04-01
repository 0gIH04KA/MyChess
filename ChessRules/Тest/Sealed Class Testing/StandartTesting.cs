using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// Тестирование стандартного FEN
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// 
    /// глубина рекурсивного тестирования
    /// 
    /// глубиа: 0   =   1
    ///         1   =   20
    ///         2   =   400
    ///         3   =   8902
    /// 
    /// </returns>
    sealed class StandartTesting : Test, ITesting
    {
        #region ---===   Private   ===---

        private static readonly string testingFEN = Constant.startingFEN;

        #endregion

        #region ---===   Constant Testing   ===---

        private const int depthTest_0 = 1;
        private const int depthTest_1 = 20;
        private const int depthTest_2 = 400;
        private const int depthTest_3 = 8902;

        #endregion

        #region ---===   IStartTesting   ===---

        public bool StartTest()
        {
            try
            {
                return ZeroTest() && FirstTest() && SecondTest() && ThirdTest();
            }
            catch (ZeroTestException)
            {

                throw new FailSecondTestException("Zero Test is Fail");
            }
            catch (FirstTestException)
            {

                throw new FailSecondTestException("First Test is Fail");
            }
            catch (SecondTestException)
            {

                throw new FailSecondTestException("Second Test is Fail");
            }
            catch (ThirdTestException)
            {

                throw new FailSecondTestException("Third Test is Fail");
            }
            
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
