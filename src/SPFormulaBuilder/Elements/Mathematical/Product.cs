﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base;

namespace Expirio.Sharepoint.Elements.Mathematical
{
    public class Product : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public string Value;

        protected override string Template
        {
            get 
            {
                return "PRODUCT({Value})";
            }
        }

        /// <summary>
        /// Used to create: PRODUCT({Value})
        /// </summary>
        public Product(params IValueType[] value)
        {
            StringBuilder sb = new StringBuilder(512);

            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(value[i].ToString());

                if ((i + 1) < value.Length)
                {
                    sb.Append(SPFormulaBuilder.SectionSeparator);
                }
            }

            this.Value = sb.ToString();
        }        
    }
}
