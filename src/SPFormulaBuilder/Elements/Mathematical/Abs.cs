using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base;

namespace Expirio.Sharepoint.Elements.Mathematical
{
    public class Abs : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "ABS({Value})";
            }
        }

        /// <summary>
        /// Used to create: ABS({Value})
        /// </summary>
        public Abs(IValueType value)
        {
            this.Value = value;
        }        
    }
}
