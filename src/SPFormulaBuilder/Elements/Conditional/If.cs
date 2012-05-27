using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Elements.Basic;

namespace Expirio.Sharepoint.Elements.Conditional
{
    public class If : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IConditionalType Condition;

        [RequiredParameter]
        public IValueType CaseTrue;

        [RequiredParameter]
        public IValueType CaseFalse;

        protected override string Template
        {
            get 
            {
                return "IF({Condition}" + SPFormulaBuilder.SectionSeparator + "{CaseTrue}" + SPFormulaBuilder.SectionSeparator + "{CaseFalse})";
            }
        }

        /// <summary>
        /// Used to create: IF({Condition}, {CaseTrue}, {CaseFalse})
        /// </summary>
        public If(IConditionalType condition, IValueType caseTrue, IValueType caseFalse)
        {
            this.Condition = condition;
            this.CaseTrue = caseTrue;
            this.CaseFalse = caseFalse;
        }

        /// <summary>
        /// Used to create: IF({Condition}, {CaseTrue}, {CaseFalse})
        /// </summary>
        public If(System.Linq.Expressions.Expression<Func<string>> conditionalExpression, IValueType caseTrue, IValueType caseFalse)
        {
            this.Condition = new Expression(conditionalExpression);
            this.CaseTrue = caseTrue;
            this.CaseFalse = caseFalse;
        }

        /// <summary>
        /// Used to create: IF({Condition}, {CaseTrue}, {CaseFalse})
        /// </summary>
        public If(System.Linq.Expressions.Expression<Func<string>> conditionalExpression, System.Linq.Expressions.Expression<Func<string>> expressionTrue, IValueType caseFalse)
        {
            this.Condition = new Expression(conditionalExpression);
            this.CaseTrue = new Expression(expressionTrue);
            this.CaseFalse = caseFalse;
        }

        /// <summary>
        /// Used to create: IF({Condition}, {CaseTrue}, {CaseFalse})
        /// </summary>
        public If(System.Linq.Expressions.Expression<Func<string>> conditionalExpression, System.Linq.Expressions.Expression<Func<string>> expressionTrue, System.Linq.Expressions.Expression<Func<string>> expressionFalse)
        {
            this.Condition = new Expression(conditionalExpression);
            this.CaseTrue = new Expression(expressionTrue);
            this.CaseFalse = new Expression(expressionFalse);
        }   
    }
}
