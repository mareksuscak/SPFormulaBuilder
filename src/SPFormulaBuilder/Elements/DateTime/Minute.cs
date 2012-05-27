﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Base.Attributes;

namespace Expirio.Sharepoint.Elements.DateTime
{
    public class Minute : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public IValueType Value;

        protected override string Template
        {
            get 
            {
                return "MINUTE({Value})";
            }
        }

        /// <summary>
        /// Used to create: MINUTE({Value})
        /// </summary>
        public Minute(IValueType value)
        {
            this.Value = value;
        }        
    }
}
