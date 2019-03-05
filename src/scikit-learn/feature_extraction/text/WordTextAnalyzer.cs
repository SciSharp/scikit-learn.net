using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace sklearn.feature_extraction.text
{
    public class WordTextAnalyzer : ITextAnalyzer
    {
        public string[] analyze(string doc)
        {
            var _regex = new Regex(@"\b\w\w+\b");

            var matches = _regex.Matches(doc).Cast<Match>().Select(x => x.Value.ToLower()).ToArray();

            return matches;
        }
    }
}
