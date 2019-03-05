using System;
using System.Collections.Generic;
using System.Text;

namespace sklearn.feature_extraction.text
{
    /// <summary>
    /// Provides common code for text vectorizers (tokenization logic).
    /// </summary>
    public class VectorizerMixin
    {
        protected string analyzer { get; set; }

        public string decode(string doc)
        {
            return doc;
        }

        public ITextAnalyzer build_analyzer()
        {
            ITextAnalyzer analyzer = null;

            switch (this.analyzer)
            {
                case "word":
                    analyzer = new WordTextAnalyzer();
                    break;
            }

            return analyzer;
        }

        protected string[] _word_ngrams(string[] tokens)
        {
            return tokens;
        }
    }
}
