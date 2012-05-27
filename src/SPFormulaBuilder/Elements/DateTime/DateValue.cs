using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;

namespace Expirio.Sharepoint.Elements.DateTime
{
    public class DateValue : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get
            {
                return "DATEVALUE({Value})";
            }
        }

        /// <summary>
        /// Used to create: DATEVALUE({Value})
        /// </summary>
        public DateValue(IValueType value)
        {
            this.Value = value;
        }
    }
}
