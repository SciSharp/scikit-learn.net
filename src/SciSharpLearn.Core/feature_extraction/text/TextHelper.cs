using NumSharp.Core;
using SciSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
{
    public class TextHelper
    {
        private static NumPy np = new NumPy();

        public static NDArray _document_frequency(csr_matrix X)
        {
            var dfs = X.indices.int32.GroupBy(x => x)
                .Select(x => new
                {
                    key = x.Key,
                    total = x.Count()
                }).OrderBy(x => x.key).Select(x => x.total).ToArray();

            return np.array(dfs);
        }
    }
}
