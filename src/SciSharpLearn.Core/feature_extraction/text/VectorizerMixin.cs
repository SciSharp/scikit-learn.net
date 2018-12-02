using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
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
    }
}
