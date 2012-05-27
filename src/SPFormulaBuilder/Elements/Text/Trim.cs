using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base;

namespace Expirio.Sharepoint.Elements.Text
{
    public class Trim : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "TRIM({Value})";
            }
        }

        /// <summary>
        /// Used to create: TRIM({Value})
        /// </summary>
        public Trim(IValueType value)
        {
            this.Value = value;
        }        
    }
}
