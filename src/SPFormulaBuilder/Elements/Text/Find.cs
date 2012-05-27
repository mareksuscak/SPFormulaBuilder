using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.Text
{
    public class Find : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType ValueLeft;

        [RequiredParameter]
        public IValueType ValueRight;

        protected override string Template
        {
            get 
            {
                return "FIND({ValueLeft}" + SPFormulaBuilder.SectionSeparator + "{ValueRight})";
            }
        }

        /// <summary>
        /// Used to create: FIND({ValueLeft},{ValueRight})
        /// </summary>
        public Find(IValueType valueLeft, IValueType valueRight)
        {
            this.ValueLeft = valueLeft;
            this.ValueRight = valueRight;
        }        
    }
}
