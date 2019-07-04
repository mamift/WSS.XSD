using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Schemas.SharePoint.Extensions;
using Microsoft.Schemas.SharePoint.Internal;
using Xml.Schema.Linq.Extensions;

namespace Microsoft.Schemas.SharePoint
{
    public partial class ValueDefinition
    {
        /// <summary>
        /// Returns <see cref="ValueDefinition"/>s from multiple input strings.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static List<ValueDefinition> NewTextValues(params string[] values)
            => values.Select(NewTextValue).ToList();

        /// <summary>
        /// New <see cref="ValueDefinition"/> from an input string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueDefinition NewTextValue(string value)
        {
            if (value.IsEmpty()) throw new ArgumentNullException(nameof(value));
            return new ValueDefinition { Untyped = XElement.Parse($"<Value Type=\"{ValueTypes.Text.StringValue()}\">{value}</Value>") };
        }

        /// <summary>
        /// Create a new value definition, by providing a value, which is represented as a string literal, plus a <paramref name="type"/> argument to
        /// specify how SharePoint should parse the value string literal.
        /// <para>Some complex types, such as <see cref="ValueTypes.Choice"/> may not be supported by SharePoint.</para>
        /// </summary> 
        /// <example>
        /// <c>var textVal = FromLiteralStringValue("this is some text", ValueTypes.Text);
        /// var intVal = FromLiteralStringValue("12", ValueTypes.Integer);</c>
        /// </example>
        /// <param name="value"></param>
        /// <param name="type">See <see cref="ValueTypes"/> enumeration for a list of possible values.</param>
        /// <returns></returns>
        public static ValueDefinition FromLiteralStringValue(string value, ValueTypes type = ValueTypes.Text)
        {
            if (value.IsEmpty()) throw new ArgumentNullException(nameof(value));
            return new ValueDefinition { Untyped = XElement.Parse($"<Value Type=\"{type.StringValue()}\">{value}</Value>") };
        }

        /// <summary>
        /// This lists all the possible value types that can be used in a <see cref="ValueDefinition"/>.
        /// <para>Documentation of them all is available: https://docs.microsoft.com/en-us/previous-versions/office/developer/sharepoint-2010/ms437580(v=office.14) </para>
        /// </summary>
        public enum ValueTypes
        {
            [StringValue(nameof(AllDayEvent))]
            AllDayEvent,
            [StringValue(nameof(Attachments))]
            Attachments,
            [StringValue(nameof(Boolean))]
            Boolean,
            [StringValue(nameof(Calculated))]
            Calculated,
            [StringValue(nameof(Choice))]
            Choice,
            [StringValue(nameof(Computed))]
            Computed,
            [StringValue(nameof(ContentTypeId))]
            ContentTypeId,
            [StringValue(nameof(Counter))]
            Counter,
            [StringValue(nameof(CrossProjectLink))]
            CrossProjectLink,
            [StringValue(nameof(Currency))]
            Currency,
            [StringValue(nameof(DateTime))]
            DateTime,
            [StringValue(nameof(File))]
            File,
            [StringValue(nameof(GridChoice))]
            GridChoice,
            [StringValue(nameof(Guid))]
            Guid,
            [StringValue(nameof(Integer))]
            Integer,
            [StringValue(nameof(Lookup))]
            Lookup,
            [StringValue(nameof(LookupMulti))]
            LookupMulti,
            [StringValue(nameof(ModStat))]
            ModStat,
            [StringValue(nameof(MultiChoice))]
            MultiChoice,
            [StringValue(nameof(MultiColumn))]
            MultiColumn,
            [StringValue(nameof(Note))]
            Note,
            [StringValue(nameof(Number))]
            Number,
            [StringValue(nameof(PageSeparator))]
            PageSeparator,
            [StringValue(nameof(Recurrence))]
            Recurrence,
            [StringValue(nameof(Text))]
            Text,
            [StringValue(nameof(ThreadIndex))]
            ThreadIndex,
            [StringValue(nameof(Threading))]
            Threading,
            [StringValue(nameof(URL))]
            URL,
            [StringValue(nameof(User))]
            User,
            [StringValue(nameof(UserMulti))]
            UserMulti,
            [StringValue(nameof(WorkflowEventType))]
            WorkflowEventType,
            [StringValue(nameof(WorkflowStatus))]
            WorkflowStatus
        }
    }
}