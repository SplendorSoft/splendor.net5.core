using System;
using System.Collections.Generic;
using System.Globalization;
using splendor.net5.core.enums;

namespace splendor.net5.core.commons
{
    /// <summary>
    /// Class representing a filter used in data stores queries
    /// </summary>
    public class DFilter
    {
        public string Name { get; set; }
        public DFilterTypes Type { get; set; }
        public DFilterOperators Operator { get; set; }
        public object Value { get; set; }
        public DFilterTypes ListType { get; set; }
        public DFilterConditions Condition { get; set; }

        public int IntValue()
        {
            if (Type == DFilterTypes.Int)
            {
                if (int.TryParse(Value.ToString().Trim(), out int value))
                {
                    return value;
                }
            }
            throw new FormatException();
        }

        public long LongValue()
        {
            if (Type == DFilterTypes.Long)
            {
                if (long.TryParse(Value.ToString().Trim(), out long value))
                {
                    return value;
                }
            }
            throw new FormatException();
        }

        public double DoubleValue()
        {
            if (Type == DFilterTypes.Double)
            {
                if (double.TryParse(Value.ToString().Trim(), out double value))
                {
                    return value;
                }
            }
            throw new FormatException();
        }

        public string StringValue()
        {
            if (Type == DFilterTypes.String)
            {
                if (Value != null)
                {
                    return Value.ToString().Trim();
                }
            }
            throw new FormatException();
        }

        public DateTime DateTimeValue(string dateFormat)
        {
            if (Type is DFilterTypes.Date or DFilterTypes.DateTime)
            {
                if (Value != null)
                {
                    return DateTime.ParseExact(Value.ToString().Trim(),
                    dateFormat, CultureInfo.InvariantCulture);
                }
            }
            throw new FormatException();
        }

        public bool BoolValue()
        {
            if (Type == DFilterTypes.Bool)
            {
                if (bool.TryParse(Value.ToString().Trim(), out bool value))
                {
                    return value;
                }
            }
            throw new FormatException();
        }

        public bool BitValue()
        {
            if (Type == DFilterTypes.Bit)
            {
                if (Value != null)
                {
                    if (short.TryParse(Value.ToString().Trim(), out short value))
                    {
                        if (value is 1 or 0)
                        {
                            return value == 1;
                        }
                    }
                }
            }
            throw new FormatException();
        }

        public object ListValue()
        {
            if (Type == DFilterTypes.List)
            {
                if (Value != null)
                {
                    Type valueType;
                    Func<object> parseAction;

                    switch (ListType)
                    {
                        case DFilterTypes.Int:
                            valueType = typeof(int);
                            parseAction = () => { return IntValue(); };
                            break;
                        case DFilterTypes.Long:
                            valueType = typeof(long);
                            parseAction = () => { return LongValue(); };
                            break;
                        case DFilterTypes.Double:
                            valueType = typeof(double);
                            parseAction = () => { return DoubleValue(); };
                            break;
                        case DFilterTypes.Bool:
                            valueType = typeof(bool);
                            parseAction = () => { return BoolValue(); };
                            break;
                        case DFilterTypes.Bit:
                            valueType = typeof(bool);
                            parseAction = () => { return BitValue(); };
                            break;
                        case DFilterTypes.String:
                            valueType = typeof(string);
                            parseAction = () => { return StringValue(); };
                            break;
                        default:
                            throw new FormatException();
                    }

                    Type genericListType = typeof(List<>).MakeGenericType(valueType);
                    var list = (System.Collections.IList)Activator
                    .CreateInstance(genericListType);

                    string[] values = Value.ToString().Split(',');

                    object temp = Value;

                    foreach (var value in values)
                    {
                        Value = value;
                        list.Add(parseAction());
                    }

                    Value = temp;
                    return list;
                }
            }
            throw new FormatException();
        }

        public object ListDateTime(string dateFormat)
        {
            if (Type == DFilterTypes.List)
            {
                if (Value != null)
                {
                    Type valueType;
                    Func<object> parseAction;

                    switch (ListType)
                    {
                        case DFilterTypes.Date:
                        case DFilterTypes.DateTime:
                            valueType = typeof(DateTime);
                            parseAction = () => { return DateTimeValue(dateFormat); };
                            break;
                        default:
                            throw new FormatException();
                    }

                    Type genericListType = typeof(List<>).MakeGenericType(valueType);
                    var list = (System.Collections.IList)Activator
                    .CreateInstance(genericListType);

                    string[] values = Value.ToString().Split(',');

                    object temp = Value;

                    foreach (var value in values)
                    {
                        Value = value;
                        list.Add(parseAction());
                    }

                    Value = temp;
                    return list;
                }
            }
            throw new FormatException();
        }
    }
}