using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    class Consts
    {
        public static readonly string SIGN_SEPARATOR = " ";

        public static readonly Dictionary<char, int> OP_PRIORITY = new Dictionary<char, int>() {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 },
            { '(', 3 },
            { ')', 3 },
        };
    }
}
