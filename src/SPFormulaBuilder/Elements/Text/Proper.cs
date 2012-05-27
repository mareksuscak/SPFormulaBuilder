using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base;

namespace Expirio.Sharepoint.Elements.Text
{
    public class Proper : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "PROPER({Value})";
            }
        }

        /// <summary>
        /// Used to create: PROPER({Value})
        /// </summary>
        public Proper(IValueType value)
        {
            this.Value = value;
        }        
    }
}
