using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Base.Interfaces;

namespace Expirio.Sharepoint.Elements.Basic
{
    public class ColumnReference : ExtendedElement, IValueType
    {
        [RequiredParameter]
        public string Name;

        protected override string Template
        {
            get 
            {
                return "{Name}";
            }
        }

        /// <summary>
        /// Used to create: [{Name}]
        /// </summary>
        public ColumnReference(string name)
        {
            if (name.Contains(" "))
            {
                this.Name = String.Format("[{0}]", name);
            }
            else
            {
                this.Name = name;
            }
        }        
    }
}
