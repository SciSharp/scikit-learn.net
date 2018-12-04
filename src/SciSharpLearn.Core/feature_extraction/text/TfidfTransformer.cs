using NumSharp.Core;
using SciSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
{
    public class TfidfTransformer
    {
        private bool smooth_idf;
        protected csr_matrix _idf_diag;

        NumPy np = new NumPy();
        sparse sp = new sparse();

        public TfidfTransformer(bool smooth_idf = true)
        {
            this.smooth_idf = smooth_idf;
        }

        public TfidfTransformer fit(csr_matrix X)
        {
            var (n_samples, n_features) = X.shape.BiShape;
            var df = TextHelper._document_frequency(X);

            // perform idf smoothing if required
            df += smooth_idf ? 1 : 0;
            n_samples += smooth_idf ? 1 : 0;

            // log+1 instead of log makes sure terms with zero idf don't get suppressed entirely.

            var idf = np.log(n_samples / df) + 1;
            _idf_diag = sp.diags(new NDArray[] { idf },
                offsets: new int[] { 0 },
                shape: new Shape(n_features, n_features),
                format: "csr",
                dtype: np.float64);

            return this;
        }

        public TfidfTransformer transform(csr_matrix X)
        {
            var (n_samples, n_features) = X.shape.BiShape;

            return this;
        }
    }
}
