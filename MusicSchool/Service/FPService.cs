using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fpxml.Service
{
    internal static class FPService
    {

        public static Func<List<string>, bool> AnyStartsWithA = (list) => 
            list.Any(x => x.StartsWith("a"));

        public static Func<List<string>, bool> AnyEmptyString = (list) =>
            list.Any(string.IsNullOrWhiteSpace);

        public static Func<List<string>, bool> AllContainsA = (list) =>
            list.All(x => x.Contains("a"));

        // Lits<T> => List<R>

        public static Func<List<string>,List<string>> UpperMany = (list) =>
            list.Select(x => x.ToUpper()).ToList();

        public static Func<List<string>, List<string>> UpperManyQuery = (list) =>
            (from str in list select str.ToUpper()).ToList();

        public static Func<List<string>, List<string>> OnlyLenAbove3 = (list) =>
            list.Where(x => x.Length > 3).ToList();

        public static Func<List<string>, List<string>> OnlyLenAbove3Query = (list) =>
            (from str in list where str.Length > 3 select str).ToList();

        public static Func<List<string>, string> StringifyList = (list) =>
            list.Aggregate(string.Empty, (acc, n) => $"{acc} {n}");
        // " alef" => " alef omer" => " alef omer enosh"

        public static Func<List<string>, int> SumLengths = (list) =>
            list.Aggregate(0, (acc, n) => acc + n.Length);

        public static Func<List<string>, List<string>> WhereAbove3 = (list) =>
            list.Aggregate(new List<string>(), (acc, n) => n.Length > 3 ? [.. acc, n] : acc);

        // ["ar", "aron", "a"]
        // [] => [] => [aron] =>

        public static Func<List<string>, List<int>> SelectLengths = (list) =>
            list.Aggregate(new List<int>(), (acc, n) => [.. acc, n.Length]);
    }
}
