using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Expirio.Sharepoint;
using Expirio.Sharepoint.Elements;
using Expirio.Sharepoint.Elements.Basic;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Elements.DateTime;

namespace SPFormulaBuilderTest
{
    /// <summary>
    /// Test cases from official documentation: http://msdn.microsoft.com/en-us/library/bb862071.aspx
    /// </summary>
    [TestClass]
    public class DateTimeTest
    {
        [TestMethod]
        public void AddDatesPlus()
        {
            Assert.AreEqual("=Column1+Column2",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        BinaryOperation.Add,
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2")
                    )
                )
            );
        }

        [TestMethod]
        public void AddDatesDateFunctionAddMonth()
        {
            Assert.AreEqual("=DATE(YEAR(Column1),MONTH(Column1)+Column2,DAY(Column1))",
                SPFormulaBuilder.CreateFormula(
                    new Date(
                        new Year(new ColumnReference("Column1")),
                        new Expression(
                            BinaryOperation.Add,
                            new Month(new ColumnReference("Column1")),
                            new ColumnReference("Column2")
                        ),
                        new Day(new ColumnReference("Column1"))
                    )
                )
            );
        }

        [TestMethod]
        public void AddDatesDateFunctionAddYear()
        {
            Assert.AreEqual("=DATE(YEAR(Column1)+Column2,MONTH(Column1),DAY(Column1))",
                SPFormulaBuilder.CreateFormula(
                    new Date(
                        new Expression(
                            BinaryOperation.Add,
                            new Year(new ColumnReference("Column1")),
                            new ColumnReference("Column2")
                        ),
                        new Month(new ColumnReference("Column1")),
                        new Day(new ColumnReference("Column1"))
                    )
                )
            );
        }

        [TestMethod]
        public void AddDatesDateFunctionAddNumber()
        {
            Assert.AreEqual("=DATE(YEAR(Column1)+3,MONTH(Column1)+1,DAY(Column1)+5)",
                SPFormulaBuilder.CreateFormula(
                    new Date(
                        new Expression(
                            BinaryOperation.Add,
                            new Year(new ColumnReference("Column1")),
                            new NumberLiteral<Decimal>(3)
                        ),
                        new Expression(
                            BinaryOperation.Add,
                            new Month(new ColumnReference("Column1")),
                            new NumberLiteral<Decimal>(1)
                        ),
                        new Expression(
                            BinaryOperation.Add,
                            new Day(new ColumnReference("Column1")),
                            new NumberLiteral<Decimal>(5)
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoDates()
        {
            Assert.AreEqual("=DATEDIF(Column1,Column2,\"d\")",
                SPFormulaBuilder.CreateFormula(
                    new DateDiff(
                        new ColumnReference("Column1"),
                        new ColumnReference("Column2"),
                        new StringLiteral("d")
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoTimes()
        {
            Assert.AreEqual("=TEXT(Column2-Column1,\"h\")",
                SPFormulaBuilder.CreateFormula(
                    new Text(
                        new Expression(
                            BinaryOperation.Subtract,
                            new ColumnReference("Column2"),
                            new ColumnReference("Column1")
                        ),
                        new StringLiteral("h")
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoTimesInt()
        {
            Assert.AreEqual("=INT((Column2-Column1)*24)",
                SPFormulaBuilder.CreateFormula(
                    new Int(
                        new Expression(
                            BinaryOperation.Multiply,
                            new Group(
                                new Expression(
                                    BinaryOperation.Subtract,
                                    new ColumnReference("Column2"),
                                    new ColumnReference("Column1")
                                )
                            ),
                            new NumberLiteral<Decimal>(24)
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoTimesHour()
        {
            Assert.AreEqual("=HOUR(Column2-Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Hour(
                        new Expression(
                            BinaryOperation.Subtract,
                            new ColumnReference("Column2"),
                            new ColumnReference("Column1")
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoTimesMinute()
        {
            Assert.AreEqual("=MINUTE(Column2-Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Minute(
                        new Expression(
                            BinaryOperation.Subtract,
                            new ColumnReference("Column2"),
                            new ColumnReference("Column1")
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoTimesSecond()
        {
            Assert.AreEqual("=SECOND(Column2-Column1)",
                SPFormulaBuilder.CreateFormula(
                    new Second(
                        new Expression(
                            BinaryOperation.Subtract,
                            new ColumnReference("Column2"),
                            new ColumnReference("Column1")
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void ConvertTimes()
        {
            Assert.AreEqual("=(Column1-INT(Column1))*24",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        BinaryOperation.Multiply,
                        new Group(
                             new Expression(
                                 BinaryOperation.Subtract,
                                 new ColumnReference("Column1"),
                                 new Int(new ColumnReference("Column1"))
                             )
                        ),
                        new NumberLiteral<Decimal>(24)
                    )
                )
            );
        }

        [TestMethod]
        public void ConvertTimesText()
        {
            Assert.AreEqual("=TEXT(Column1/24,\"hh:mm:ss\")",
                SPFormulaBuilder.CreateFormula(
                    new Text(
                        new Expression(
                            BinaryOperation.Divide,
                            new ColumnReference("Column1"),
                            new NumberLiteral<Decimal>(24)
                        ),
                        new StringLiteral("hh:mm:ss")
                    )
                )
            );
        }

        [TestMethod]
        public void InsertJulianDates()
        {
            Assert.AreEqual("=TEXT(Column1,\"yy\")&TEXT((Column1-DATEVALUE(\"1/1/\"&TEXT(Column1,\"yy\"))+1),\"000\")",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        BinaryOperation.LogicalAnd,
                        new Text(
                            new ColumnReference("Column1"),
                            new StringLiteral("yy")
                        ),
                        new Text(
                            new Group(
                                new Expression(
                                    BinaryOperation.Subtract,
                                    new ColumnReference("Column1"),
                                    new Expression(
                                        BinaryOperation.Add,
                                        new DateValue(
                                            new Expression(
                                                BinaryOperation.LogicalAnd,
                                                new StringLiteral("1/1/"),
                                                new Text(
                                                    new ColumnReference("Column1"),
                                                    new StringLiteral("yy")
                                                )
                                            )
                                        ),
                                        new NumberLiteral<Decimal>(1)
                                    )
                                )
                            ),
                            new StringLiteral("000")
                        )
                    )
                )
            );
        }

        [TestMethod]
        public void InsertJulianDatesInAstronomy()
        {
            Assert.AreEqual("=Column1+2415018.5",
                SPFormulaBuilder.CreateFormula(
                    new Expression(
                        BinaryOperation.Add,
                        new ColumnReference("Column1"),
                        new NumberLiteral<Double>(2415018.50)
                    )
                )
            );
        }

        [TestMethod]
        public void ShowDatesAsTheDayOfWeek()
        {
            Assert.AreEqual("=TEXT(WEEKDAY(Column1),\"dddd\")",
                SPFormulaBuilder.CreateFormula(
                    new Text(
                        new WeekDay(new ColumnReference("Column1")),
                        new StringLiteral("dddd")
                    )
                )
            );
        }
    }
}
