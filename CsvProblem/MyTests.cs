using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace DavesCsvProblem
{
    class MyTests
    {
        [Test]
        public void FullTest()
        {
            var site1 = new SurveyResponse("site1");
            site1.Results.Add(ProgrammingLanguage.CSharp, 3);
            site1.Results.Add(ProgrammingLanguage.FSharp, 1);
            site1.Results.Add(ProgrammingLanguage.Haskell, 0);
            
            var site2 = new SurveyResponse("site2");
            site2.Results.Add(ProgrammingLanguage.CSharp, 3);
            site2.Results.Add(ProgrammingLanguage.Ruby, 5);

            var site3 = new SurveyResponse("site3");
            site3.Results.Add(ProgrammingLanguage.Ruby, 7);
            site3.Results.Add(ProgrammingLanguage.JavaScript, 4);

            const string expected = @"site,csharp,fsharp,haskell,ruby,javascript
site1,3,1,0,0,0
site2,3,0,0,5,0
site3,0,0,0,7,4";

            SurveyToCsv(new [] {site1, site2, site3}).ShouldBe(expected);
        }

        [Test]
        public void WhenGettingAllLanguages()
        {
            AllProgrammingLanguages().ShouldBe(new List<ProgrammingLanguage> { ProgrammingLanguage.CSharp, ProgrammingLanguage.FSharp, ProgrammingLanguage.Haskell, ProgrammingLanguage.Ruby, ProgrammingLanguage.JavaScript });
        }

        [Test]
        public void WhenGettingHeader()
        {
            GetHeader().ShouldBe("site,csharp,fsharp,haskell,ruby,javascript");
        }

        [Test]
        public void WhenGettingRow()
        {
            var site3 = new SurveyResponse("blah");
            site3.Results.Add(ProgrammingLanguage.Haskell, 3);
            site3.Results.Add(ProgrammingLanguage.JavaScript, 1);
            GetRow(site3).ShouldBe("blah,0,0,3,0,1");
        }

        public string SurveyToCsv(IEnumerable<SurveyResponse> responses)
        {
            var rows = String.Join("\r\n", responses.Select(GetRow));
            return GetHeader() + "\r\n" + rows;
        }

        public string GetHeader()
        {
            var languages = String.Join(",", AllProgrammingLanguages().Select(x => x.ToString().ToLowerInvariant()));
            return "site," + languages;
        }

        public string GetRow(SurveyResponse response)
        {
            var languages = AllProgrammingLanguages();
            return response.Site + "," + String.Join(",", languages.Select(x => response.Results.ContainsKey(x) ? response.Results[x] : 0));
        }

        public IEnumerable<ProgrammingLanguage> AllProgrammingLanguages()
        {
            return Enum.GetValues(typeof(ProgrammingLanguage)).Cast<ProgrammingLanguage>();
        }
    }
}
