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
    public class Not : Element, IConditionalType, IValueType
    {
        [RequiredParameter]
        public IConditionalType Condition;

        protected override string Template
        {
            get 
            {
                return "NOT({Condition})";
            }
        }

        /// <summary>
        /// Used to create: NOT({Condition})
        /// </summary>
        public Not(IConditionalType condition)
        {
            this.Condition = condition;
        }   
     
        /// <summary>
        /// Used to create: NOT({Condition})
        /// </summary>
        public Not(System.Linq.Expressions.Expression<Func<string>> conditionalExpression)
        {
            this.Condition = new Expression(conditionalExpression);
        }
    }
}
