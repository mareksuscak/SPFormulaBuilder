using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expirio.Sharepoint;
using Expirio.Sharepoint.Elements;
using Expirio.Sharepoint.Elements.Basic;

namespace SPFormulaBuilderTest
{
    [TestClass]
    public class SPFormulaBuilderTest
    {
        [TestMethod]
        public void CreateFormulaTest()
        {
            Assert.AreEqual("=\"StringLiteral\"",
                SPFormulaBuilder.CreateFormula(new StringLiteral("StringLiteral"))
            );
        }

        [TestMethod]
        public void CreateLongAndShortFormula()
        {
            Assert.Inconclusive("Not implemented test method.");
        }
    }
}
