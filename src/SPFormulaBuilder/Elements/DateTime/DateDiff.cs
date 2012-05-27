using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.DateTime
{
    public class DateDiff : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType ValueLeft;

        [RequiredParameter]
        public IValueType ValueRight;

        [RequiredParameter]
        public IValueType Format;

        protected override string Template
        {
            get 
            {
                return "DATEDIF({ValueLeft}" + SPFormulaBuilder.SectionSeparator + "{ValueRight}" + SPFormulaBuilder.SectionSeparator + "{Format})";
            }
        }

        /// <summary>
        /// Used to create: DATEDIF({ValueLeft},{ValueRight},{Format})
        /// </summary>
        public DateDiff(IValueType valueLeft, IValueType valueRight, IValueType format)
        {
            this.ValueLeft = valueLeft;
            this.ValueRight = valueRight;
            this.Format = format;
        }        
    }
}
