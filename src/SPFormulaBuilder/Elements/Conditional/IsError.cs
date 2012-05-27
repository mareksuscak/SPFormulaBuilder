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
    public class IsError : Element, IConditionalType, IValueType
    {
        [RequiredParameter]
        public IConditionalType Condition;

        protected override string Template
        {
            get 
            {
                return "ISERROR({Condition})";
            }
        }

        /// <summary>
        /// Used to create: ISERROR({Condition})
        /// </summary>
        public IsError(IConditionalType condition)
        {
            this.Condition = condition;
        }  
      
        /// <summary>
        /// Used to create: ISERROR({Condition})
        /// </summary>
        public IsError(System.Linq.Expressions.Expression<Func<string>> conditionalExpression)
        {
            this.Condition = new Expression(conditionalExpression);
        }
    }
}
