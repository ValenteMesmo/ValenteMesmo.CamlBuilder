﻿using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    /// <summary>
    /// <para>Presents possible filters to boolean fields</para>
    /// Examples: <see cref="IsTrue"></see> and <see cref="IsFalse"></see>
    /// </summary>
    public class CamlBoolField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
        public override string ToString() => query.ToString();

        internal CamlBoolField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        /// &lt;Eq&gt;&lt;FieldRef Name=&quot;fieldName&quot; /&gt;&lt;Value Type=&quot;Boolean&quot;&gt;1&lt;/Value&gt;&lt;/Eq&gt;
        /// </summary>
        public CamlOperatorPicker IsTrue()
        {
            var newCondition = $@"<Eq><FieldRef Name=""{fieldName}"" /><Value Type=""Boolean"">1</Value></Eq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        /// &lt;Eq&gt;&lt;FieldRef Name=&quot;fieldName&quot; /&gt;&lt;Value Type=&quot;Boolean&quot;&gt;0&lt;/Value&gt;&lt;/Eq&gt;
        /// </summary>
        public CamlOperatorPicker IsFalse()
        {
            //<Or><IsNull><FieldRef Name=""{fieldName}"" /></IsNull><Eq><FieldRef Name=""{fieldName}"" /><Value Type='Text'></Value></Eq></Or>
            var newCondition = $@"<Or><IsNull><FieldRef Name=""{fieldName}"" /></IsNull><Eq><FieldRef Name=""{fieldName}"" /><Value Type=""Boolean"">0</Value></Eq></Or>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }
    }
}