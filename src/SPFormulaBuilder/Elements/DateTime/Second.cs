﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.DateTime
{
    public class Second : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "SECOND({Value})";
            }
        }

        /// <summary>
        /// Used to create: SECOND({Value})
        /// </summary>
        public Second(IValueType value)
        {
            this.Value = value;
        }        
    }
}
