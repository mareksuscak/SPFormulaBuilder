using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.Basic
{
    public class ConstantLiteral : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public string Text;

        protected override string Template
        {
            get 
            {
                return "{Text}";
            }
        }

        /// <summary>
        /// Used to create: {Text}
        /// </summary>
        public ConstantLiteral(string text, params object[] parameters)
        {
            this.Text = String.Format(text, parameters);
        }        
    }
}
