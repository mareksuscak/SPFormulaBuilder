using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Interfaces;
using System.Reflection;
using Expirio.Sharepoint.Base.Attributes;
using Expirio.Sharepoint.Elements.Basic;

namespace Expirio.Sharepoint.Base
{
    /// <summary>
    /// Abstract element class. Each element type must inherit from this class.
    /// </summary>
    public abstract class Element : IElementType
    {
        /// <summary>
        /// Element template. Can contain {Property} or {Field}.
        /// </summary>
        protected abstract string Template
        {
            get;
        }

        private bool FilterMembers(MemberInfo m, object filterCriteria)
        {
            return ((m.GetCustomAttributes(typeof(RequiredParameter), false).Length == 1) || (m.GetCustomAttributes(typeof(OptionalParameter), false).Length == 1));
        }

        // TODO: rewrite this method in following fashion: with regex search for {...}, than search for Fields or Properties with ... name, if they are required check value for null
        /// <summary>
        /// Returns formatted formula. If formula is longer than maximum allowed length InvalidOperationException is thrown.
        /// </summary>
        /// <returns>String representation of formula.</returns>
        public sealed override string ToString()
        {
            string formula = this.Template;

            MemberInfo[] memberInfos = this.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property, BindingFlags.Public | BindingFlags.Instance, FilterMembers, null);

            foreach (MemberInfo memberInfo in memberInfos)
            {
                object[] requiredAttrs = memberInfo.GetCustomAttributes(typeof(RequiredParameter), false);
                object[] optionalAttrs = memberInfo.GetCustomAttributes(typeof(OptionalParameter), false);

                object fieldValue = null;

                switch (memberInfo.MemberType)
                {
                    case MemberTypes.Field:
                    {
                        fieldValue = (memberInfo as FieldInfo).GetValue(this);
                        break;
                    }

                    case MemberTypes.Property:
                    {
                        fieldValue = (memberInfo as PropertyInfo).GetValue(this, null);
                        break;
                    }
                }

                // if is required and null throw exception
                if (requiredAttrs.Length == 1 && fieldValue == null)
                {
                    throw new ArgumentException(String.Format("Field {0} is required and must not be null.", memberInfo.Name));
                }
                else if (requiredAttrs.Length == 1 && fieldValue != null)
                {
                    RequiredParameter attr = requiredAttrs[0] as RequiredParameter;

                    // if parameter has overriden Name use it, otherwise use name of field
                    if (attr.Name != null)
                    {
                        formula = formula.Replace("{" + attr.Name + "}", fieldValue.ToString());
                    }
                    else
                    {
                        formula = formula.Replace("{" + memberInfo.Name + "}", fieldValue.ToString());
                    }
                }
                else if (optionalAttrs.Length == 1 && fieldValue != null)
                {
                    OptionalParameter attr = optionalAttrs[0] as OptionalParameter;

                    // if parameter has overriden Name use it, otherwise use name of field
                    if (attr.Name != null)
                    {
                        formula = formula.Replace("{" + attr.Name + "}", fieldValue.ToString());
                    }
                    else
                    {
                        formula = formula.Replace("{" + memberInfo.Name + "}", fieldValue.ToString());
                    }
                }
                else if (optionalAttrs.Length == 1 && fieldValue == null)
                {
                    OptionalParameter attr = optionalAttrs[0] as OptionalParameter;

                    // if parameter has overriden Name use it, otherwise use name of field
                    if (attr.Name != null)
                    {
                        formula = formula.Replace("{" + attr.Name + "}", "");
                    }
                    else
                    {
                        formula = formula.Replace("{" + memberInfo.Name + "}", "");
                    }
                }
            }

            if (formula.Length > SPFormulaBuilder.MAXIMUM_FORMULA_LENGTH)
            {
                throw new InvalidOperationException(String.Format("This formula contains {0} characters which is more than maximum allowed length.", formula.Length));
            }

            return formula;
        }

        
    }
}
