using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;
using System.Globalization;

namespace Expirio.Sharepoint.Elements.Basic
{
    public class NumberLiteral<T> : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public string Number;

        protected override string Template
        {
            get 
            {
                return "{Number}";
            }
        }

        /// <summary>
        /// Used to create: {Number}
        /// </summary>
        public NumberLiteral(T number)
        {
            CultureInfo ci = new CultureInfo("en-US");

            if (typeof(T) == typeof(Double))
            {
                // TODO: set regional settings
                this.Number = Convert.ToDouble(number, ci).ToString(ci);
            }
            else if (typeof(T) == typeof(Decimal))
            {
                this.Number = Convert.ToDecimal(number, ci).ToString(ci);
            }
            else
            {
                throw new InvalidOperationException(number.GetType().FullName + " is unknown type.");
            }
        }  
    }
}
