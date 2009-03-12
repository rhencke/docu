﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace DrDoc.Tests
{
    public static class Extensions
    {
        public static void CountShouldEqual<T>(this IEnumerable<T> actual, int count)
        {
            (actual.Count() == count).ShouldBeTrue();
        }

        public static void ShouldBeTrue(this bool actual)
        {
            Assert.That(actual, Is.True);
        }

        public static void ShouldBeFalse(this bool actual)
        {
            Assert.That(actual, Is.False);
        }

        public static IEnumerable<T> ShouldContain<T>(this IEnumerable<T> actual, Func<T, bool> expected)
        {
            actual.First(expected).ShouldNotEqual(default(T));
            return actual;
        }

        public static MethodInfo ShouldEqual<T>(this MethodInfo method, Expression<Action<T>> expected)
        {
            var expectedMethod = ((MethodCallExpression)expected.Body).Method;

            Assert.That(method, Is.EqualTo(expectedMethod));
            return method;
        }

        public static PropertyInfo ShouldEqual<T>(this PropertyInfo property, Expression<Func<T, object>> expected)
        {
            var expectedProperty = (PropertyInfo)((MemberExpression)expected.Body).Member;

            Assert.That(property, Is.EqualTo(expectedProperty));
            return property;
        }

        public static T ShouldEqual<T>(this T actual, T expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
            return actual;
        }

        public static T ShouldNotEqual<T>(this T actual, T expected)
        {
            Assert.That(actual, Is.Not.EqualTo(expected));
            return actual;
        }

        public static T ShouldNotBeNull<T>(this T actual)
        {
            Assert.That(actual, Is.Not.Null);
            return actual;
        }

        public static XmlNode ToNode(this string original)
        {
            var doc = new XmlDocument();

            doc.LoadXml(original);

            return doc.DocumentElement;
        }
    }
}