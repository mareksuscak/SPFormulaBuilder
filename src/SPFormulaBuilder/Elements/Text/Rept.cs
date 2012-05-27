using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.Text
{
    public class Rept : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType ValueLeft;

        [RequiredParameter]
        public IValueType ValueRight;

        protected override string Template
        {
            get 
            {
                return "REPT({ValueLeft}" + SPFormulaBuilder.SectionSeparator + "{ValueRight})";
            }
        }

        /// <summary>
        /// Used to create: REPT({ValueLeft},{ValueRight})
        /// </summary>
        public Rept(IValueType valueLeft, IValueType valueRight)
        {
            this.ValueLeft = valueLeft;
            this.ValueRight = valueRight;
        }        
    }
}
