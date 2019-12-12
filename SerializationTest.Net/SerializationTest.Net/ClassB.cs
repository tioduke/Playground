using System.Collections.Generic;
using System.Linq;

namespace SerializationTest.Net
{
    public class ClassB
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }
        public IList<string> Property3 { get; set; }
        public IDictionary<int, string> Property4 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            return Property1.Equals(((ClassB)obj).Property1) && Property2.Equals(((ClassB)obj).Property2) && Property3.AreEqual(((ClassB)obj).Property3) && Property4.AreEqual(((ClassB)obj).Property4);
        }

        public override int GetHashCode()
        {
            return Property1.GetHashCode() + Property2.GetHashCode() + Property3.GetHashCode() + Property4.GetHashCode();
        }

    }

    internal static class CollectionsExtensionMethods
    {
        internal static bool AreEqual(this IList<string> list1, IList<string> list2)
        {
            return list1.SequenceEqual(list2);
        }
        internal static bool AreEqual(this IDictionary<int, string> dictionary1, IDictionary<int, string> dictionary2)
        {
            return dictionary1.OrderBy(kvp => kvp.Key).SequenceEqual(dictionary2.OrderBy(kvp => kvp.Key));
        }

    }
}