using Microsoft.VisualStudio.TestTools.UnitTesting;
using SciSharpLearn.Core.feature_extraction.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciSharpLearn.UnitTest.feature_extraction.text
{
    [TestClass]
    public class TfidfVectorizerTest
    {
        string[] corpus = new string[]
        {
            "This is the first document.",
            "This document is the second document.",
            "And this is the third one.",
            "Is this the first document?"
        };

        [TestMethod]
        public void CountVectorizer()
        {
            var vectorizer = new TfidfVectorizer();

            var X = vectorizer.fit_transform(corpus);
            var features = vectorizer.get_feature_names();

            Assert.IsTrue(Enumerable.SequenceEqual(features, new string[]
            {
                "and", "document", "first", "is", "one", "second", "the", "third", "this"
            }));

            Assert.IsTrue(Enumerable.SequenceEqual(X.shape.Shapes.ToArray(), new int[] { 4, 9 }));
        }
    }
}
