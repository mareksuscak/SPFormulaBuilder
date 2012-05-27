using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base;

namespace Expirio.Sharepoint.Elements.Mathematical
{
    public class RoundUp : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        [RequiredParameter]
        public IValueType DecimalPlaces;

        protected override string Template
        {
            get 
            {
                return "ROUNDUP({Value}" + SPFormulaBuilder.SectionSeparator + "{DecimalPlaces})";
            }
        }

        /// <summary>
        /// Used to create: ROUNDUP({Value},{DecimalPlaces})
        /// </summary>
        public RoundUp(IValueType value, IValueType decimalPlaces)
        {
            this.Value = value;
            this.DecimalPlaces = decimalPlaces;
        }        
    }
}
