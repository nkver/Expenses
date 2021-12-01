using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Expenses.Shared
{
    public abstract class TypeSafeEnum : IComparable
    {
        public string DisplayName { get; private set; }

        public int Id { get; private set; }

        protected TypeSafeEnum(int id, string name)
        {
            Id = id;
            DisplayName = name;
        }

        public override string ToString() => DisplayName;

        public static IEnumerable<T> GetAll<T>() where T : TypeSafeEnum
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as TypeSafeEnum;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static int AbsoluteDifference(TypeSafeEnum firstValue, TypeSafeEnum secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }

        public static T FromValue<T>(int value) where T : TypeSafeEnum
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : TypeSafeEnum
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : TypeSafeEnum
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

            return matchingItem;
        }

        public int CompareTo(object other) => Id.CompareTo(((TypeSafeEnum)other).Id);
    }
}
