using System.Collections.Generic;
using System.Linq;

namespace CsvProblem
{
    public class SurveyResponse
    {
        public SurveyResponse(string site, Dictionary<ProgrammingLanguage, int> results)
        {
            _results = results;
            Site = site;
        }

        public string Site { get; private set; }
        private readonly Dictionary<ProgrammingLanguage, int> _results;

        public int GetResult(ProgrammingLanguage language)
        {
            return _results.ContainsKey(language) ? _results[language] : 0;
        }

        public string ToCsv()
        {
            return Site + Enum<ProgrammingLanguage>.Values.Select(GetResult).Aggregate("", (s, i) => s + "," + i);
        }
    }
}