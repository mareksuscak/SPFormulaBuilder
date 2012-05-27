using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base;

namespace Expirio.Sharepoint.Elements.Basic
{
    public class Expression : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public string Value;

        private string BinaryOperator;
        private string ComparisonOperator;
        private string UnaryOperator;

        protected override string Template
        {
            get 
            {
                return "{Value}";
            }
        }

        /// <summary>
        /// Used to create: {Value[0]}{BinaryOperator}{Value[1]}...{Value[n]}
        /// </summary>
        public Expression(BinaryOperation binaryOperation, params IValueType[] value)
        {
            this.BinaryOperator = Operation.GetBinaryOperator(binaryOperation);

            StringBuilder sb = new StringBuilder(512);

            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(value[i].ToString());

                if ((i + 1) < value.Length)
                {
                    sb.Append(this.BinaryOperator);
                }
            }

            this.Value = sb.ToString();
        }

        /// <summary>
        /// Used to create: {UnaryOperation}{Value}
        /// </summary>
        public Expression(UnaryOperation unaryOperation, IValueType value)
        {
            StringBuilder sb = new StringBuilder(512);

            this.UnaryOperator = Operation.GetUnaryOperator(unaryOperation);
            
            sb.Append(this.UnaryOperator);
            sb.Append(value.ToString());

            this.Value = sb.ToString();
        }

        /// <summary>
        /// Used to create: {ValueLeft}{ComparisonOperator}{ValueRight}
        /// </summary>
        public Expression(ComparisonOperation comparisonOperation, IValueType valueLeft, IValueType valueRight)
        {
            StringBuilder sb = new StringBuilder(512);

            this.ComparisonOperator = Operation.GetComparisonOperator(comparisonOperation);

            sb.Append(valueLeft.ToString());
            sb.Append(this.ComparisonOperator);
            sb.Append(valueRight.ToString());

            this.Value = sb.ToString();
        }

        /// <summary>
        /// Used to create: {Value}
        /// </summary>
        public Expression(IValueType value)
        {
            this.Value = value.ToString();
        }

        /// <summary>
        /// Used to create: {ValueLeft}{ComparisonOperator}{ValueRight}
        /// Used to create: {UnaryOperation}{Value}
        /// Used to create: {Value[0]}{BinaryOperator}{Value[1]}...{Value[n]}
        /// </summary>
        public Expression(System.Linq.Expressions.Expression<Func<string>> operationExpression)
        {
            Func<string> deleg = operationExpression.Compile();
            this.Value = deleg();
        }
    }
}
