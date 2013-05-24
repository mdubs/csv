using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace CsvProblem
{
    class MyTests
    {
        [Test]
        public void FullTest()
        {
            var results1 = new Dictionary<ProgrammingLanguage, int> {{ProgrammingLanguage.CSharp, 3}, {ProgrammingLanguage.FSharp, 1}, {ProgrammingLanguage.Haskell, 0}};
            var site1 = new SurveyResponse("site1", results1);

            var results2 = new Dictionary<ProgrammingLanguage, int> {{ProgrammingLanguage.CSharp, 3}, {ProgrammingLanguage.Ruby, 5}};
            var site2 = new SurveyResponse("site2", results2);

            var results3 = new Dictionary<ProgrammingLanguage, int> {{ProgrammingLanguage.Ruby, 7}, {ProgrammingLanguage.JavaScript, 4}};
            var site3 = new SurveyResponse("site3", results3);

            const string expected = @"site,csharp,fsharp,haskell,ruby,javascript
site1,3,1,0,0,0
site2,3,0,0,5,0
site3,0,0,0,7,4";

            new [] {site1, site2, site3}.ToCsv().ShouldBe(expected);
        }

        [Test]
        public void WhenGettingAllLanguages()
        {
            Enum<ProgrammingLanguage>.Values.ShouldBe(new List<ProgrammingLanguage> { ProgrammingLanguage.CSharp, ProgrammingLanguage.FSharp, ProgrammingLanguage.Haskell, ProgrammingLanguage.Ruby, ProgrammingLanguage.JavaScript });
        }

        [Test]
        public void WhenGettingHeader()
        {
            SurveyResposeExtensions.GetHeader().ShouldBe("site,csharp,fsharp,haskell,ruby,javascript");
        }

        [Test]
        public void WhenGettingRow()
        {
            var results = new Dictionary<ProgrammingLanguage, int> {{ProgrammingLanguage.Haskell, 3}, {ProgrammingLanguage.JavaScript, 1}};
            var site3 = new SurveyResponse("blah", results);
            site3.ToCsv().ShouldBe("blah,0,0,3,0,1");
        }

        [Test]
        public void WhenGettingResultForLanguage()
        {
            var results = new Dictionary<ProgrammingLanguage, int> { { ProgrammingLanguage.Haskell, 3 }, { ProgrammingLanguage.JavaScript, 1 } };
            var surveyResponse = new SurveyResponse("blah", results);

            surveyResponse.GetResult(ProgrammingLanguage.Haskell).ShouldBe(3);
            surveyResponse.GetResult(ProgrammingLanguage.CSharp).ShouldBe(0);
        }
    }
}
