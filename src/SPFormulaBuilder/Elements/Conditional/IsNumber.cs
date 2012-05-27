using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Elements.Basic;

namespace Expirio.Sharepoint.Elements.Conditional
{
    public class IsNumber : Element, IConditionalType, IValueType
    {
        [RequiredParameter]
        public IConditionalType Condition;

        protected override string Template
        {
            get 
            {
                return "ISNUMBER({Condition})";
            }
        }

        /// <summary>
        /// Used to create: ISNUMBER({Condition})
        /// </summary>
        public IsNumber(IConditionalType condition)
        {
            this.Condition = condition;
        }  
      
        /// <summary>
        /// Used to create: ISNUMBER({Condition})
        /// </summary>
        public IsNumber(System.Linq.Expressions.Expression<Func<string>> conditionalExpression)
        {
            this.Condition = new Expression(conditionalExpression);
        }
    }
}
