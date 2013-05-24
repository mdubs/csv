using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvProblem
{
    public class Enum<T> where T : struct
    {
        public static IEnumerable<T> Values
        {
            get { return Enum.GetValues(typeof(T)).Cast<T>(); }
        }
    }
}