using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace sklearn.UnitTest.model_selection
{
    /// <summary>
    /// Split arrays or matrices into random train and test subsets
    /// https://scikit-learn.org/stable/modules/generated/sklearn.model_selection.train_test_split.html
    /// </summary>
    [TestClass]
    public class SplitTest
    {
        [TestMethod]
        public void split()
        {
            var (X, y) = (np.arange(10).reshape(5, 2), new int[] { 0, 1, 2, 3, 4 });
        }
    }
}
