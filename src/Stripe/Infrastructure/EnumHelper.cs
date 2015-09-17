using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Stripe.Infrastructure
{

    public static class EnumHelper
    {
        public static string GetDescriptionFromEnumValue(Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(
                                typeof(DescriptionAttribute), false), (
                                    f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att)
                                .Description == description);
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

        public static string GetDisplayName(this Enum value)
        {
            var enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);

            if (enumValue == null)
            {
                throw new Exception(string.Format("Value of {0} is not valid for enum {1}", value, enumType.Name));
            }

            var member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = string.Empty;

            if (attrs.Length == 0)
            {
                outString = value.ToString();
            }
            else if (((DisplayAttribute)attrs[0]).ResourceType == null)
            {
                outString = ((DisplayAttribute)attrs[0]).Name;
            }
            else
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }
        
    }
}
