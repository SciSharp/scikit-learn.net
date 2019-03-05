using System;
using System.Collections.Generic;
using System.Text;

namespace sklearn.feature_extraction.text
{
    public interface ITextAnalyzer
    {
        string[] analyze(string doc);
    }
}
