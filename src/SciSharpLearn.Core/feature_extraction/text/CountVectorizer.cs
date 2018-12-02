using SciSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
{
    /// <summary>
    /// Convert a collection of text documents to a matrix of token counts
    /// This implementation produces a sparse representation of the counts using scisharp.sparse.csr_matrix.
    /// </summary>
    public class CountVectorizer : VectorizerMixin
    {
        protected int min_df;

        public CountVectorizer(string analyzer = "word", int min_df = 1)
        {
            this.analyzer = analyzer;
            this.min_df = min_df;
        }

        public (Dictionary<string, int>, csr_matrix) _count_vocab(string[] raw_documents)
        {
            var vocabulary = new Dictionary<string, int>();
            var X = new csr_matrix();

            string doc = String.Empty;
            for (int i = 0; i < raw_documents.Length; i++)
            {
                doc = raw_documents[i];

            }

            return (vocabulary, X);
        }
    }
}
