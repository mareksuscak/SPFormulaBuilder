using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.Basic
{
    public class Int : ExtendedElement, IValueType, IConditionalType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "INT({Value})";
            }
        }

        /// <summary>
        /// Used to create: INT({Value})
        /// </summary>
        public Int(IValueType value)
        {
            this.Value = value;
        }        
    }
}
