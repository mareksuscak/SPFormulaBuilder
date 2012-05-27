using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expirio.Sharepoint.Base.Attributes
{
    /// <summary>
    /// Formula parameter marker attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class OptionalParameter : Attribute
    {
        public string Name
        {
            get;
            set;
        }
    }
}
