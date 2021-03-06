﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// Третье Тестирование
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// 
    /// глубина рекурсивного тестирования
    /// 
    /// глубиа: 1   =   6
    ///         2   =   264
    ///         3   =   9467
    /// 
    /// </returns>
    sealed class ThirdTesting : Test, ITesting
    {
        #region ---===   Private   ===---

        private static readonly string testingFEN = "r3k2r/Pppp1ppp/1b3nbN/nP6/BBP1P3/q4N2/Pp1P2PP/R2Q1RK1 w kq - 0 1";

        #endregion

        #region ---===   Constant Testing   ===---

        private const int depthTest_0 = 1;
        private const int depthTest_1 = 6;
        private const int depthTest_2 = 264;
        private const int depthTest_3 = 9467;

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
            int zeroTest = StandartTest(val, testingFEN);

            if (zeroTest != depthTest_0)
            {
                throw new ZeroTestException($"Count on Testing = {zeroTest}. Desired Result = {depthTest_0}");
            }
            
            return true;

        }

        public bool FirstTest(int val = 1)
        {
            int firstTest = StandartTest(val, testingFEN);

            if (firstTest != depthTest_1)
            {
                throw new FirstTestException($"Count on Testing = {firstTest}. Desired Result = {depthTest_1}");
            }
            
            return true;
        }

        public bool SecondTest(int val = 2)
        {
            int secondTest = StandartTest(val, testingFEN);

            if (secondTest != depthTest_2)
            {
                throw new SecondTestException($"Count on Testing = {secondTest}. Desired Result = {depthTest_2}");
            }
            
            return true;
        }

        public bool ThirdTest(int val = 3)
        {
            int thirdTest = StandartTest(val, testingFEN);

            if (thirdTest != depthTest_3)
            {
                throw new ThirdTestException($"Count on Testing = {thirdTest}. Desired Result = {depthTest_3}");
            }
            
            return true;
        }

        #endregion

    }
}
