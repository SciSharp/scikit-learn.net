using NumSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SciSharpLearn.Core.linear_model
{
    public class LinearRegression
    {
        /// <summary>
        /// Fit linear model.
        /// </summary>
        /// <param name="X">Training data</param>
        /// <param name="y">Target values. Will be cast to X’s dtype if necessary</param>
        public LinearRegression fit(NDArray X, NDArray y)
        {
            return this;
        }
    }
}
