using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fpxml.Service
{
    internal static class PracticeService
    {
    
        public static Func<int, int> Add10 = (num) => num + 10;

        public static Func<List<string>, bool> isSomething = (list) =>
            list.Any(x => string.IsNullOrEmpty(x));

        public static Func<List<int>, string> ToSum = (list) => // [1, 3, 4, 5]
            list.Aggregate("", (res, nextEl) => $"{res} + {nextEl}"); // " + 1 + 3"

        public static Func<List<string>, List<string>> CrazyEnosh = (list) =>
        (
            from str in list
            where str == "enosh"
            select $"{str} hahaha!"
        ).ToList();
    }
}
