using SciSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
{
    public class TfidfTransformer
    {
        public void fit(csr_matrix X)
        {
            var (n_samples, n_features) = X.shape.BiShape;
        }
    }
}
