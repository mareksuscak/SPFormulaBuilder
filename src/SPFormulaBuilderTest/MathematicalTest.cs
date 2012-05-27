using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Expirio.Sharepoint;
using Expirio.Sharepoint.Elements;
using Expirio.Sharepoint.Elements.Basic;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Elements.Mathematical;
using Expirio.Sharepoint.Elements.Conditional;

namespace SPFormulaBuilderTest
{
    /// <summary>
    /// Test cases from official documentation: http://msdn.microsoft.com/en-us/library/bb862071.aspx
    /// </summary>
    [TestClass]
    public class MathematicalTest
    {
        [TestMethod]
        public void AddNumbersExpressionTree()
        {
            Assert.AreEqual("=Column1+Column2+Column3",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        () => new ColumnReference("Column1") + new ColumnReference("Column2") + new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void AddNumbersSum()
        {
            Assert.AreEqual("=SUM(Column1,Column2,Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Sum(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void AddNumbersSumIf()
        {
            Assert.AreEqual("=SUM(IF(Column1>Column2,Column1-Column2,10),Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Sum(
                        new If(
                            () => new ColumnReference("Column1") > new ColumnReference("Column2"),
                            () => new ColumnReference("Column1") - new ColumnReference("Column2"),
                            new NumberLiteral<Decimal>(10)
                        ),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void SubtractNumbersExpressionTree()
        {
            Assert.AreEqual("=Column1-Column2",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        () => new ColumnReference("Column1") - new ColumnReference("Column2")
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateDifferenceBetweenNumberAndPercentage()
        {
            Assert.AreEqual("=(Column2-Column1)/ABS(Column1)",
                SPFormulaBuilder.CreateFormula(
                    () => new Group(() => new ColumnReference("Column2") - new ColumnReference("Column1")) / new Abs(new ColumnReference("Column1"))
                )
            );
        }

        [TestMethod]
        public void MultiplyNumbersExpressionTree()
        {
            Assert.AreEqual("=Column1*Column2",
                SPFormulaBuilder.CreateFormula(
                     () => new ColumnReference("Column1") * new ColumnReference("Column2")
                )
            );
        }

        [TestMethod]
        public void MultiplyNumbersProduct()
        {
            Assert.AreEqual("=PRODUCT(Column1,Column2,2)",
                SPFormulaBuilder.CreateFormula(
                    new Product(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new NumberLiteral<Decimal>(2)
                    )
                )
            );
        }

        [TestMethod]
        public void DivideNumbersExpressionTree()
        {
            Assert.AreEqual("=(Column1+10000)/Column2",
                SPFormulaBuilder.CreateFormula(
                    () => new Group(() => new ColumnReference("Column1") + new NumberLiteral<Decimal>(10000)) / new ColumnReference("Column2")
                )
            );
        }

        [TestMethod]
        public void CalculateAverageOfNumbers()
        {
            Assert.AreEqual("=AVERAGE(Column1,Column2,Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Average(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateMedian()
        {
            Assert.AreEqual("=MEDIAN(Column1,Column2,Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Median(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateSmallestNumberInRange()
        {
            Assert.AreEqual("=MIN(Column1,Column2,Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Min(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateLargestNumberInRange()
        {
            Assert.AreEqual("=MAX(Column1,Column2,Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Max(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void CountValues()
        {
            Assert.AreEqual("=COUNT(Column1,Column2,Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Count(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new ColumnReference("Column3")
                    )
                )
            );
        }

        [TestMethod]
        public void IncreaseOrDescreaseByPercentage()
        {
            Assert.AreEqual("=Column1*(1+5%)",
                SPFormulaBuilder.CreateFormula(
                    () => new ColumnReference("Column1") * new Group(() => new NumberLiteral<Decimal>(1) + new PercentageLiteral(new NumberLiteral<Decimal>(5)))
                )
            );
        }

        [TestMethod]
        public void RaiseNumberPower()
        {
            Assert.AreEqual("=POWER(Column1,Column2)",
                SPFormulaBuilder.CreateFormula(
                    new Power(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2")
                    )
                )
            );
        }

        [TestMethod]
        public void RaiseNumber()
        {
            Assert.AreEqual("=Column1^Column2",
                SPFormulaBuilder.CreateFormula(
                    () => new ColumnReference("Column1") ^ new ColumnReference("Column2")
                )
            );
        }

        [TestMethod]
        public void RoundUp()
        {
            Assert.AreEqual("=ROUNDUP(Column1,2)",
                SPFormulaBuilder.CreateFormula(
                    new RoundUp(
                        new ColumnReference("Column1"),
                        new NumberLiteral<Decimal>(2)
                    )
                )
            );
        }

        [TestMethod]
        public void RoundDown()
        {
            Assert.AreEqual("=ROUNDDOWN(Column1,2)",
                SPFormulaBuilder.CreateFormula(
                    new RoundDown(
                        new ColumnReference("Column1"),
                        new NumberLiteral<Decimal>(2)
                    )
                )
            );
        }

        [TestMethod]
        public void Len()
        {
            Assert.AreEqual("=ROUND(Column1,3-LEN(INT(Column1)))",
                SPFormulaBuilder.CreateFormula(
                    new Round(
                        new ColumnReference("Column1"),
                        new Expression(
                            () => new NumberLiteral<Decimal>(3) - new Len(new Int(new ColumnReference("Column1")))
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void Even()
        {
            Assert.AreEqual("=EVEN(Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Even(
                        new ColumnReference("Column1")
                    )
                )
            );
        }

        [TestMethod]
        public void Odd()
        {
            Assert.AreEqual("=ODD(Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Odd(
                        new ColumnReference("Column1")
                    )
                )
            );
        }
    }
}
