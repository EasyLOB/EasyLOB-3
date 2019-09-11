using System;
using System.Linq;
using System.Reflection;
//using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

/*

How to retrieve Data Annotations from code ?
https://stackoverflow.com/questions/7027613/how-to-retrieve-data-annotations-from-code-programmatically

var length = AttributeExtensions.GetPropertyAttributeValue<Player, String, StringLengthAttribute, Int32>(p => p.PlayerName, a => a.MaximumLength);

var length = AttributeExtensions.GetMaxLength<Player>(x => x.PlayerName);

var player = new Player();
var length = player.GetMaxLength(x => x.PlayerName);

*/

namespace EasyLOB.Library
{
    public static class AttributeExtensions
    {
        public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(Expression<Func<T, TOut>> propertyExpression, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (attr == null)
            {
                throw new MissingMemberException(typeof(T).Name + "." + propertyInfo.Name, typeof(TAttribute).Name);
            }

            return valueSelector(attr);
        }

        //public static Int32 GetMaxLength<T>(Expression<Func<T, string>> propertyExpression)
        //{
        //    return GetPropertyAttributeValue<T, string, MaxLengthAttribute, Int32>(propertyExpression, attr => attr.Length);
        //}

        //public static Int32 GetMaxLength<T>(this T instance, Expression<Func<T, string>> propertyExpression)
        //{
        //    return GetMaxLength<T>(propertyExpression);
        //}
    }
}
