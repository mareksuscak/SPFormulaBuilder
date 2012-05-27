using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Expirio.Sharepoint;
using Expirio.Sharepoint.Elements;
using Expirio.Sharepoint.Elements.Basic;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Elements.Conditional;
using System.Collections.Generic;
using Expirio.Sharepoint.Base.Interfaces;

namespace SPFormulaBuilderTest
{
    /// <summary>
    /// Test cases from official documentation: http://msdn.microsoft.com/en-us/library/bb862071.aspx
    /// </summary>
    [TestClass]
    public class ConditionalTest
    {
        [TestMethod]
        public void ValueGreaterThan()
        {
            Assert.AreEqual("=Column1>Column2",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        ComparisonOperation.GreaterThan,
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2")
                    )
                )
            );
        }

        [TestMethod]
        public void ValueGreaterThanExpressionTree()
        {
            Assert.AreEqual("=Column1>Column2",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        () => new ColumnReference("Column1") > new ColumnReference("Column2")
                    )
                )
            );
        }

        [TestMethod]
        public void ValueLessThanOrEqualIf()
        {
            Assert.AreEqual("=IF(Column1<=Column2,\"OK\",\"Not OK\")",
                SPFormulaBuilder.CreateFormula(
                    new If( 
                        new Expression(
                            ComparisonOperation.LessThanOrEqual,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column2")
                        ), 
                        new StringLiteral("OK"),
                        new StringLiteral("Not OK")
                    )
                )
           );
        }

        [TestMethod]
        public void ReturnLogicalValueAnd()
        {
            Assert.AreEqual("=AND(Column1>Column2,Column1<Column3)",
                SPFormulaBuilder.CreateFormula(
                    new And(
                        new Expression(
                            ComparisonOperation.GreaterThan,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column2")
                        ),
                        new Expression(
                            ComparisonOperation.LessThan,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column3")
                        )
                    )
                )
           );
        }

        [TestMethod]
        public void ReturnLogicalValueOr()
        {
            Assert.AreEqual("=OR(Column1>Column2,Column1<Column3)",
                SPFormulaBuilder.CreateFormula(
                    new Or(
                        new Expression(
                            ComparisonOperation.GreaterThan,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column2")
                        ),
                        new Expression(
                            ComparisonOperation.LessThan,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column3")
                        )
                    )
                )
           );
        }

        [TestMethod]
        public void ReturnLogicalValueNot()
        {
            Assert.AreEqual("=NOT(Column1+Column2=24)",
                SPFormulaBuilder.CreateFormula(
                    new Not(
                        new Expression(
                            ComparisonOperation.Equal,
                            new Expression(
                                BinaryOperation.Add,
                                new ColumnReference("Column1"),
                                new ColumnReference("Column2")
                            ),
                            new NumberLiteral<Decimal>(24)
                        )
                    )
                )
           );
        }

        [TestMethod]
        public void DisplayZeroesAsBlanks()
        {
            Assert.AreEqual("=Column1-Column2",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        BinaryOperation.Subtract,
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2")
                    )
                )
           );
        }

        [TestMethod]
        public void DisplayZeroesAsDashes()
        {
            Assert.AreEqual("=IF(Column1-Column2,Column1-Column2,\" - \")",
                SPFormulaBuilder.CreateFormula(
                    new If(
                        new Expression(
                            BinaryOperation.Subtract,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column2")
                        ),
                        new Expression(
                            
                            BinaryOperation.Subtract,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column2")
                        ),
                        new StringLiteral(" - ")
                    )
                )
           );
        }

        [TestMethod]
        public void HideErrorValuesInColumnsDiv()
        {
            Assert.AreEqual("=Column1/Column2",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        BinaryOperation.Divide,
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2")
                    )
                )
           );
        }

        [TestMethod]
        public void HideErrorValuesInColumnsIsErrorNA()
        {
            Assert.AreEqual("=IF(ISERROR(Column1/Column2),\"NA\",Column1/Column2)",
                SPFormulaBuilder.CreateFormula(
                    new If(
                        new IsError(new Expression(
                                BinaryOperation.Divide,
                                new ColumnReference("Column1"),
                                new ColumnReference("Column2")
                            )
                        ),
                        new StringLiteral("NA"),
                        new Expression(
                            BinaryOperation.Divide,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column2")
                        )
                    )
                )
           );
        }

        [TestMethod]
        public void HideErrorValuesInColumnsIsErrorDash()
        {
            Assert.AreEqual("=IF(ISERROR(Column1/Column2),\"-\",Column1/Column2)",
                SPFormulaBuilder.CreateFormula(
                    new If(
                        new IsError(new Expression(
                                BinaryOperation.Divide,
                                new ColumnReference("Column1"),
                                new ColumnReference("Column2")
                            )
                        ),
                        new StringLiteral("-"),
                        new Expression(
                            BinaryOperation.Divide,
                            new ColumnReference("Column1"),
                            new ColumnReference("Column2")
                        )
                    )
                )
           );
        }

        [TestMethod]
        public void Switch()
        {
            Assert.AreEqual("=IF(Column1=\"Y\",\"YES\",IF(Column1=\"N\",\"NO\",\"\"))",
                SPFormulaBuilder.CreateFormula(
                    new Switch(
                        new StringLiteral(""),
                        new KeyValuePair<System.Linq.Expressions.Expression<Func<string>>, IValueType>(() => new ColumnReference("Column1") == new StringLiteral("Y"), new StringLiteral("YES")),
                        new KeyValuePair<System.Linq.Expressions.Expression<Func<string>>, IValueType>(() => new ColumnReference("Column1") == new StringLiteral("N"), new StringLiteral("NO")) 
                    )
                )
           );
        }
    }
}
