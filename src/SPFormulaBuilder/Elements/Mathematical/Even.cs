using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base;

namespace Expirio.Sharepoint.Elements.Mathematical
{
    public class Even : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "EVEN({Value})";
            }
        }

        /// <summary>
        /// Used to create: EVEN({Value})
        /// </summary>
        public Even(IValueType value)
        {
            this.Value = value;
        }        
    }
}
