using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;

namespace Expirio.Sharepoint.Elements.Basic
{
    class Formula : Element
    {
        [RequiredParameter]
        public string Text;

        protected override string Template
        {
            get 
            {
                return "={Text}";
            }
        }

        /// <summary>
        /// Used to create: ={Text}
        /// </summary>
        public Formula(IValueType text)
        {
            this.Text = text.ToString();
        }

        /// <summary>
        /// Used to create: ={Text}
        /// </summary>
        public Formula(System.Linq.Expressions.Expression<Func<string>> expression)
        {
            this.Text = new Expression(expression).ToString();
        }
    }
}
