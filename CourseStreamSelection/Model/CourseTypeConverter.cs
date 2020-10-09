using CourseStreamSelection.Databases;
using System;
using System.ComponentModel;
using System.Globalization;

namespace CourseStreamSelection.Model
{
    public class CourseTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string s)
                return MainDatabase.Instance.GetCourse(s);
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value is Course c)
                    return c.ToString();
                return false;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
