﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    /// <summary>
    /// 
    /// класс для визуализации шахмат в консоли
    /// 
    /// </summary>
    public class UI_Console
    {
        #region ---===   Public Method   ===---

        /// <summary>
        /// 
        /// метод формирует строчное представление игровой доски 
        /// 
        /// </summary>
        /// 
        /// <param name="chess">
        /// 
        /// используется для полуение фигуры в указаных кооординатах игры
        /// 
        /// </param>
        /// 
        /// <returns>
        /// 
        /// возвращает строковое представление игровой доски
        /// 
        /// </returns>
        public static string ChessToAscii(Chess chess)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  +-----------------+");

            for (int y = 7; y >= 0; y--)
            {
                sb.Append(y + 1);
                sb.Append(" | ");

                for (int x = 0; x < 8; x++)
                {
                    sb.Append(chess.GetFigureAt(x, y) + " ");
                }

                sb.AppendLine("|");
            }

            sb.AppendLine("  +-----------------+");
            sb.AppendLine("    a b c d e f g h  ");

            if (chess.IsCheck)
            {
                sb.AppendLine("Is Check");
            }

            //if (chess.IsCheckMate)
            //{
            //    sb.AppendLine("Is Check Mate");
            //}

            //if (chess.IsStealMate)
            //{
            //    sb.AppendLine("Is Steal Mate");
            //}

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// метод для отприсвки строкового представления шахмат в консоли
        /// 
        /// </summary>
        /// 
        /// <param name="text">
        /// 
        /// полученое строковое представление
        /// 
        /// </param>
        public static void Print(string text)
        {
            ConsoleColor old = Console.ForegroundColor;

            foreach (char x in text)
            {
                if (x >= 'a' && x <= 'z' || char.IsDigit(x))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    if (x >= 'A' && x <= 'Z')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }

                Console.Write(x);
            }

            Console.ForegroundColor = old;
        }

        public static void PrintColorPlayer(Chess chess)
        {
            ConsoleColor old = Console.ForegroundColor;

            Console.Write("    Now Move: " + SelectionPlayerColor(chess.ColorMove));            

            Console.ForegroundColor = old;
        }

        

        public static void PrintMakeMove()
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\nPlease Make Move: ");

            Console.ForegroundColor = old;

        }

        #endregion

        #region ---===    Private Method   ===---

        private static string SelectionPlayerColor(string colorPlayer)
        {
            StringBuilder playerColor = new StringBuilder();

            switch (colorPlayer)
            {
                case "white":

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    playerColor.Append("White\n");

                    break;

                case "black":

                    Console.ForegroundColor = ConsoleColor.Magenta;

                    playerColor.Append("Black\n");

                    break;
            }

            return playerColor.ToString();
        }

        #endregion

    }
}
