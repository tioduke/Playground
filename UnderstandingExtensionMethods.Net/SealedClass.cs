using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnderstandingExtensionMethods.Net
{
    public sealed class SealedClass
    {
        public SealedClass() { }

        private SealedClass(string str)
        {
            ListeString.Add(str);
        }

        private IList<string> _listeString;
        private IList<string> ListeString
        {
            get { return this._listeString ?? (this._listeString = new List<string>()); }
        }
    }

    public static class SealedClassExtensions
    {
        public static SealedClass CreateInstance(string str)
        {
            var ctor = typeof(SealedClass).GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, new Type[] { typeof(string) });
            return (SealedClass)ctor.Invoke(new Object[] { str } );
        }

        public static IList<string> GetListeString(this SealedClass obj)
        {
            var pi = obj.GetType().GetProperty("ListeString", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (IList<string>)pi.GetValue(obj, null);
        }
        
        public static ConstructorInfo GetConstructor(this Type type, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetConstructors(bindingAttr).SingleOrDefault(c => c.GetParameters().Select(p => p.ParameterType).SequenceEqual(types));
        }
    }

}
