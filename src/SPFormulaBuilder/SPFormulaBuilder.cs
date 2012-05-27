using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expirio.Sharepoint.Base.Interfaces;
using Expirio.Sharepoint.Elements;
using Expirio.Sharepoint.Elements.Basic;
using System.Globalization;

namespace Expirio.Sharepoint
{
    public class SPFormulaBuilder
    {
        /// <summary>
        /// Exception is being thrown if total characters count of 
        /// calculated field formula is bigger than this property value.
        /// </summary>
        private static int _MAXIMUM_FORMULA_LENGTH = 1024;
        public static int MAXIMUM_FORMULA_LENGTH 
        {
            get
            {
                return _MAXIMUM_FORMULA_LENGTH;
            }

            protected set
            {
                _MAXIMUM_FORMULA_LENGTH = value;
            }
        }

        /// <summary>
        /// Whether to use environments current culture or not.
        /// 
        /// If this property is set to false, InvariantCulture is used. 
        /// Otherwise environments culture is used.
        /// </summary>
        public static bool UseEnvironmentCulture = false;

        /// <summary>
        /// By setting Culture property, you override environments CurrentCulture
        /// </summary>
        private static CultureInfo _Culture;
        public static CultureInfo Culture
        {
            get
            {
                if (_Culture == null)
                {
                    if (UseEnvironmentCulture)
                    {
                        return CultureInfo.CurrentCulture;
                    }
                    else
                    {
                        return CultureInfo.InvariantCulture;
                    }
                }

                return _Culture;
            }

            set
            {
                _Culture = value;
            }
        }

        /// <summary>
        /// Current NumberFormatInfo that depends on Culture property value
        /// </summary>
        public static NumberFormatInfo NumberFormat
        {
            get
            {
                return Culture.NumberFormat;
            }
        }

        /// <summary>
        /// Element sections separator character that depends on current culture.
        /// </summary>
        public static string SectionSeparator 
        { 
            get
            {
                return NumberFormat.NumberDecimalSeparator == "," ? ";" : ",";
            }
        }

        protected delegate string FormulaAction();
        protected delegate string FormulaAction<T>(T obj);
        protected delegate string FormulaAction<T1, T2>(T1 obj1, T2 obj2);
        protected delegate string FormulaAction<T1, T2, T3>(T1 obj1, T2 obj2, T3 obj3);
        protected delegate string FormulaAction<T1, T2, T3, T4>(T1 obj1, T2 obj2, T3 obj3, T4 obj4);

        /// <summary>
        /// Do not allow to create instances of this type
        /// </summary>
        private SPFormulaBuilder()
        {
 
        }

        /// <summary>
        /// Used to create: "={Text}"
        /// Note: Formula class cannot be used directly. Instead of instantiating Formula class, use this method.
        /// </summary>
        public static string CreateFormula(IValueType element)
        {
            return new Formula(element).ToString();
        }

        /// <summary>
        /// Used to create: "={Text}"
        /// Note: Formula class cannot be used directly. Instead of instantiating Formula class, use this method.
        /// </summary>
        public static string CreateFormula(System.Linq.Expressions.Expression<Func<string>> expression)
        {
            return new Formula(expression).ToString();
        }
    }
}
