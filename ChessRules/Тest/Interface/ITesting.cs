using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    interface ITesting
    {
        bool ZeroTest(int val);

        bool FirstTest(int val);

        bool SecondTest(int val);

        bool ThirdTest(int val);
    }
}
