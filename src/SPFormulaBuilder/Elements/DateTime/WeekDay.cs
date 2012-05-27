using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;

namespace Expirio.Sharepoint.Elements.DateTime
{
    public class WeekDay : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get
            {
                return "WEEKDAY({Value})";
            }
        }

        /// <summary>
        /// Used to create: WEEKDAY({Value})
        /// </summary>
        public WeekDay(IValueType value)
        {
            this.Value = value;
        }
    }
}
