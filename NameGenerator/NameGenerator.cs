using System;
using System.Collections.Generic;
using System.Threading;
namespace NameGenerator
{

    class TempNames
    {
        public List<string> FirstNames = new List<string>()
    {
        "Sergio",
        "Daniel",
        "Carolina",
        "David",
        "Reina",
        "Saul",
        "Bernard",
        "Danny",
        "Dimas",
        "Yuri",
        "Ivan",
        "Laura"
    };

        public List<string> LastNamesA = new List<string>()
    {
        "Tapia",
        "Gutierrez",
        "Rueda",
        "Galviz",
        "Yuli",
        "Rivera",
        "Mamami",
        "Saucedo",
        "Dominguez",
        "Escobar",
        "Martin",
        "Crespo"
    };

        public List<string> LastNamesB = new List<string>()
    {
        "Johnson",
        "Williams",
        "Jones",
        "Brown",
        "David",
        "Miller",
        "Wilson",
        "Anderson",
        "Thomas",
        "Jackson",
        "White",
        "Robinson"
    };
    }

    public static class NameGenerator
    {
        static TempNames temp = new TempNames();
        private static readonly Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
        public static T GetRandom<T>(this List<T> ts)
        {
            return ts[rnd.Next(ts.Count - 1)];
        }
        public static string GenerateName(this string str)
        {
            str += temp.FirstNames.GetRandom()+" "+temp.LastNamesA.GetRandom()+" "+temp.LastNamesB.GetRandom();
            return str;
        }
    }

        

}
