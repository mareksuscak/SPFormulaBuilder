using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Elements.Basic;

namespace Expirio.Sharepoint.Elements.Conditional
{
    public class And : Element, IConditionalType, IValueType
    {
        [RequiredParameter]
        public string Conditions;

        protected override string Template
        {
            get 
            {
                return "AND({Conditions})";
            }
        }

        /// <summary>
        /// Used to create: AND({Condition1},{Condition2}...)
        /// </summary>
        public And(params IConditionalType[] conditions)
        {
            StringBuilder sb = new StringBuilder(512);

            for (int i = 0; i < conditions.Length; i++)
            {
                sb.AppendFormat(conditions[i].ToString());

                if ((i + 1) < conditions.Length)
                {
                    sb.Append(SPFormulaBuilder.SectionSeparator);
                }
            }

            this.Conditions = sb.ToString();
        }    
    
        /// <summary>
        /// Used to create: AND({Condition1}, {Condition2})
        /// </summary>
        public And(params System.Linq.Expressions.Expression<Func<string>>[] conditionalExpressions)
        {
            StringBuilder sb = new StringBuilder(512);

            for (int i = 0; i < conditionalExpressions.Length; i++)
            {
                sb.AppendFormat(new Expression(conditionalExpressions[i]).ToString());

                if ((i + 1) < conditionalExpressions.Length)
                {
                    sb.Append(SPFormulaBuilder.SectionSeparator);
                }
            }

            this.Conditions = sb.ToString();
        }
    }
}
