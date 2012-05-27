﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.Basic
{
    public class PercentageLiteral : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "{Value}%";
            }
        }

        /// <summary>
        /// Used to create: "{Value}%"
        /// </summary>
        public PercentageLiteral(IValueType value)
        {
            this.Value = value;
        }        
    }
}
