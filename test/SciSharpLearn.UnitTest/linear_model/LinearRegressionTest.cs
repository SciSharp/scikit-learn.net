using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.UnitTest.linear_model
{
    [TestClass]
    public class LinearRegressionTest
    {
        NumPy np = new NumPy();

        [TestMethod]
        public void LRTest()
        {
            var X = np.array(new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 1, 2 },
                new int[] { 2, 2 },
                new int[] { 2, 3 }
            });

            var y = np.dot(X, np.array(new int[] { 1, 2 })) + 3;

            //var reg = LinearRegression().fit(X, y);
        }
    }
}
