using System.Collections.Generic;

namespace DavesCsvProblem
{
    class SurveyResponse
    {
        public SurveyResponse(string site)
        {
            Site = site;
        }

        public string Site { get; private set; }
        private Dictionary<ProgrammingLanguage, int> _results = new Dictionary<ProgrammingLanguage, int>();
        public Dictionary<ProgrammingLanguage, int> Results
        {
            get { return _results; }
            set { _results = value; }
        }
    }
}