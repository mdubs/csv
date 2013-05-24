using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvProblem
{
    public static class SurveyResposeExtensions
    {
        public static string ToCsv(this IEnumerable<SurveyResponse> responses)
        {
            var rows = String.Join("\r\n", responses.Select(x => x.ToCsv()));
            return GetHeader() + "\r\n" + rows;
        }

        public static string GetHeader()
        {
            return "site" + Enum<ProgrammingLanguage>.Values.Aggregate("", (s, value) => s + "," + value.ToString().ToLowerInvariant());
        }
    }
}