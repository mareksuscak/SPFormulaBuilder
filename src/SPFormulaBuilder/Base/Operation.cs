using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expirio.Sharepoint.Base
{
    public enum UnaryOperation
    {
        Minus,
    }

    public enum BinaryOperation
    {
        Square,
        LogicalAnd,
        Subtract,
        Add,
        Multiply,
        Divide,
    }

    public enum ComparisonOperation
    {
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Equal,
    }

    class Operation
    {
        private static Dictionary<ComparisonOperation, string> ComparisonOperators = new Dictionary<ComparisonOperation, string>()
        {
            {ComparisonOperation.GreaterThan, ">"},
            {ComparisonOperation.GreaterThanOrEqual, ">="},
            {ComparisonOperation.LessThan, "<"},
            {ComparisonOperation.LessThanOrEqual, "<="},
            {ComparisonOperation.Equal, "="},
        };

        private static Dictionary<UnaryOperation, string> UnaryOperators = new Dictionary<UnaryOperation, string>()
        {
            {UnaryOperation.Minus, "-"},
        };

        private static Dictionary<BinaryOperation, string> BinaryOperators = new Dictionary<BinaryOperation, string>()
        {
            {BinaryOperation.Square, "^"},
            {BinaryOperation.LogicalAnd, "&"},
            {BinaryOperation.Subtract, "-"},
            {BinaryOperation.Add, "+"},
            {BinaryOperation.Multiply, "*"},
            {BinaryOperation.Divide, "/"},
        };

        public static string GetBinaryOperator(BinaryOperation binaryOperation)
        {
            if (!BinaryOperators.Keys.Contains(binaryOperation))
            {
                throw new InvalidOperationException("Required operation was not recognized.");
            }

            return BinaryOperators[binaryOperation];
        }

        public static string GetComparisonOperator(ComparisonOperation comparisonOperation)
        {
            if (!ComparisonOperators.Keys.Contains(comparisonOperation))
            {
                throw new InvalidOperationException("Required operation was not recognized.");
            }

            return ComparisonOperators[comparisonOperation];
        }

        public static string GetUnaryOperator(UnaryOperation unaryOperation)
        {
            if (!UnaryOperators.Keys.Contains(unaryOperation))
            {
                throw new InvalidOperationException("Required operation was not recognized.");
            }

            return UnaryOperators[unaryOperation];
        }
    }
}
