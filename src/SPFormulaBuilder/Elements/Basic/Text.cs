using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.Basic
{
    public class Text : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        [RequiredParameter]
        public IValueType Format;

        protected override string Template
        {
            get 
            {
                return "TEXT({Value}" + SPFormulaBuilder.SectionSeparator + "{Format})";
            }
        }

        /// <summary>
        /// Used to create: TEXT({Value},{Format})
        /// </summary>
        public Text(IValueType value, IValueType format)
        {
            this.Value = value;
            this.Format = format;
        }        
    }
}
