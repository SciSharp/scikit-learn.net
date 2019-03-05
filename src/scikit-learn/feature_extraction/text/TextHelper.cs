using NumSharp.Core;
using NumSharp.Core.Sparse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciSharpLearn.Core.feature_extraction.text
{
    public class TextHelper
    {
        public static NDArray _document_frequency(csr_matrix X)
        {
            var dfs = X.indices.Data<int>().GroupBy(x => x)
                .Select(x => new
                {
                    key = x.Key,
                    total = x.Count()
                }).OrderBy(x => x.key).Select(x => x.total).ToArray();

            return np.array(dfs);
        }
    }
}
