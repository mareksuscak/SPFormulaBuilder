using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.Text
{
    public class Counta : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public string Value;

        protected override string Template
        {
            get 
            {
                return "COUNTA({Value})";
            }
        }

        /// <summary>
        /// Used to create: COUNTA({Value[0]}, {Value[1]}, ...)
        /// </summary>
        public Counta(params IValueType[] value)
        {
            StringBuilder sb = new StringBuilder(512);

            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(value[i].ToString());

                if((i+1) < value.Length)
                {
                    sb.Append(SPFormulaBuilder.SectionSeparator);
                }
            }

            this.Value = sb.ToString();
        }        
    }
}
