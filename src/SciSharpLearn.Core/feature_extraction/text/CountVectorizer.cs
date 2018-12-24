using NumSharp.Core;
using SciSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected int max_df;
        protected Dictionary<string, int> vocabulary_;

        public CountVectorizer(string analyzer = "word", int max_df = 1, int min_df = 1)
        {
            this.analyzer = analyzer;
            this.max_df = max_df;
            this.min_df = min_df;
        }

        public (Dictionary<string, int>, csr_matrix) _count_vocab(string[] raw_documents)
        {
            var vocabulary = new Dictionary<string, int>();

            var analyze = build_analyzer();
            int feature_idx_all = 0;
            string doc = String.Empty;

            var values = new List<double>();
            var j_indices = new List<int>();
            var indptr = new List<int>() { 0 };

            for (int i = 0; i < raw_documents.Length; i++)
            {
                doc = raw_documents[i];
                var feature_counter = new Dictionary<int, double>();

                foreach (string feature in analyze.analyze(doc))
                {
                    if (!vocabulary.ContainsKey(feature))
                    {
                        vocabulary[feature] = feature_idx_all++;
                    }

                    int feature_idx = vocabulary[feature];
                    if (feature_counter.ContainsKey(feature_idx))
                    {
                        feature_counter[feature_idx] += 1;
                    }
                    else
                    {
                        feature_counter[feature_idx] = 1;
                    }
                }

                j_indices.AddRange(feature_counter.Keys);
                values.AddRange(feature_counter.Values);
                indptr.Add(j_indices.Count);
            }

            vocabulary = vocabulary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            var data1 = np.array(values.ToArray(), np.int32);
            var indices1 = np.array(j_indices.ToArray(), np.int32);
            var indptr1 = np.array(indptr.ToArray(), np.int32);

            var X = new csr_matrix(data1, indices1, indptr1,
                new Shape(indptr.Count - 1, vocabulary.Count),
                np.float64);

            X.sort_indices();

            vocabulary_ = vocabulary;

            return (vocabulary, X);
        }

        public csr_matrix _sort_features(csr_matrix X, Dictionary<string, int> vocabulary)
        {
            var mapping = new Dictionary<int, int>();
            for (int i = 0; i < vocabulary.Count; i++)
            {
                var element = vocabulary.ElementAt(i);
                mapping[element.Value] = i;
                vocabulary[element.Key] = i;
            }

            for (int i = 0; i < X.indices.size; i++)
            {
                X.indices.Data<int>()[i] = mapping[X.indices.Data<int>()[i]];
            }

            return X;
        }

        public (csr_matrix, Dictionary<string, int>) _limit_features(csr_matrix X, Dictionary<string, int> vocabulary, int hight = -1, int low = -1, int limit = -1)
        {
            if(hight == -1 && low == -1 && limit == -1)
            {
                return (X, vocabulary);
            }

            var dfs = TextHelper._document_frequency(X);
            NDArray tfs = null;// np.asarray(X.sum(axis: 0)).ravel();

            var mask = np.ones((Shape)dfs.Storage.Shape, dtype: typeof(bool));
            return (X, vocabulary);
        }

        public string[] get_feature_names()
        {
            return vocabulary_.Select(x => x.Key).ToArray();
        }
    }
}
