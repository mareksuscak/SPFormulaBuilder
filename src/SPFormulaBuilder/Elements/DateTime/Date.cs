using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.DateTime
{
    public class Date : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Year;

        [RequiredParameter]
        public IValueType Month;

        [RequiredParameter]
        public IValueType Day;

        protected override string Template
        {
            get 
            {
                return "DATE({Year}" + SPFormulaBuilder.SectionSeparator + "{Month}" + SPFormulaBuilder.SectionSeparator + "{Day})";
            }
        }

        /// <summary>
        /// Used to create: DATE({Year},{Month},{Day})
        /// </summary>
        public Date(IValueType year, IValueType month, IValueType day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }        
    }
}
