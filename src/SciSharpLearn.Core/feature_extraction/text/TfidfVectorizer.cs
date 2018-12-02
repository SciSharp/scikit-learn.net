using SciSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
{
    public class TfidfVectorizer : CountVectorizer
    {
        public TfidfVectorizer()
        {

        }

        public csr_matrix fit_transform(string[] corpus)
        {
            var (vocabulary, X) = _count_vocab(corpus);
            return X;
        }
    }
}
