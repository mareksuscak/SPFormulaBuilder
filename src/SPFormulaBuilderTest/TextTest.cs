using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Expirio.Sharepoint;
using Expirio.Sharepoint.Elements;
using Expirio.Sharepoint.Elements.Basic;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Elements.Text;
using Expirio.Sharepoint.Elements.Conditional;
using Expirio.Sharepoint.Elements.Mathematical;

namespace SPFormulaBuilderTest
{
    /// <summary>
    /// Test cases from official documentation: http://msdn.microsoft.com/en-us/library/bb862071.aspx
    /// </summary>
    [TestClass]
    public class TextTest
    {
        [TestMethod]
        public void Upper()
        {
            Assert.AreEqual("=UPPER(Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Upper(new ColumnReference("Column1"))
                )
            );
        }

        [TestMethod]
        public void Lower()
        {
            Assert.AreEqual("=LOWER(Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Lower(new ColumnReference("Column1"))
                )
            );
        }

        [TestMethod]
        public void Proper()
        {
            Assert.AreEqual("=PROPER(Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Proper(new ColumnReference("Column1"))
                )
            );
        }

        [TestMethod]
        public void CombineFirstAndLastNames()
        {
            Assert.AreEqual("=Column2&\", \"&Column1",
                SPFormulaBuilder.CreateFormula(
                    () => new ColumnReference("Column2") & new StringLiteral(", ") & new ColumnReference("Column1")
                )
            );
        }

        [TestMethod]
        public void CombineFirstAndLastNamesConcatenate()
        {
            Assert.AreEqual("=CONCATENATE(Column2,\", \",Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Concatenate(
                        new ColumnReference("Column2"),
                        new StringLiteral(", "),
                        new ColumnReference("Column1")
                    )
                )
            );
        }

        [TestMethod]
        public void CombineTextAndNumbers()
        {
            Assert.AreEqual("=Column1&\" sold \"&TEXT(Column2,\"0%\")&\" of the total sales.\"",
                SPFormulaBuilder.CreateFormula(
                    () => new ColumnReference("Column1") & new StringLiteral(" sold ") & new Text(new ColumnReference("Column2"), new StringLiteral("0%")) & new StringLiteral(" of the total sales.")
                )
            );
        }

        [TestMethod]
        public void CombineTextAndDate()
        {
            Assert.AreEqual("=\"Statement date: \"&TEXT(Column2,\"d-mmm-yyyy\")",
                SPFormulaBuilder.CreateFormula(
                    () => new StringLiteral("Statement date: ") & new Text(new ColumnReference("Column2"), new StringLiteral("d-mmm-yyyy"))
                )
            );
        }

        [TestMethod]
        public void Exact()
        {
            Assert.AreEqual("=EXACT(Column1,Column2)",
                SPFormulaBuilder.CreateFormula(
                    new Exact(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2")
                    )
                )
            );
        }

        [TestMethod]
        public void DetermineWhetherColumnValueMatchesText()
        {
            Assert.AreEqual("=IF(ISNUMBER(FIND(\"v\",Column1)),\"OK\",\"Not OK\")",
                SPFormulaBuilder.CreateFormula(
                    new If(
                        new IsNumber(
                            new Find(
                                new StringLiteral("v"),
                                new ColumnReference("Column1")
                            )
                        ),
                        new StringLiteral("OK"),
                        new StringLiteral("Not OK")
                    )
                )
            );
        }

        [TestMethod]
        public void Counta()
        {
            Assert.AreEqual("=COUNTA(Column1,Column2,Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Counta(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void Left()
        {
            Assert.AreEqual("=LEFT(Column1,LEN(Column1)-2)",
                SPFormulaBuilder.CreateFormula(
                    new Left(
                        new ColumnReference("Column1"),
                        new Expression(
                            () => new Len(new ColumnReference("Column1")) - new NumberLiteral<Decimal>(2)
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void Right()
        {
            Assert.AreEqual("=RIGHT(Column1,LEN(Column1)-8)",
                SPFormulaBuilder.CreateFormula(
                    new Right(
                        new ColumnReference("Column1"),
                        new Expression(
                            () => new Len(new ColumnReference("Column1")) - new NumberLiteral<Decimal>(8)
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void Trim()
        {
            Assert.AreEqual("=TRIM(Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Trim(
                        new ColumnReference("Column1")
                    )
                )
            );
        }

        [TestMethod]
        public void Rept()
        {
            Assert.AreEqual("=REPT(\"-\",10)",
                SPFormulaBuilder.CreateFormula(
                    new Rept(
                        new StringLiteral("-"),
                        new NumberLiteral<Decimal>(10)
                    )
                )
            );
        }
    }
}
