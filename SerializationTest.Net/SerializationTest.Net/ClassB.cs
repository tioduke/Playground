using System.Collections.Generic;
using System.Linq;

namespace SerializationTest.Net
{
    public class ClassB
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }
        public IList<string> Property3 { get; set; }
        public IDictionary<string, object> Property4 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            
            return this.Property1.Equals(((ClassB)obj).Property1) && this.Property2.Equals(((ClassB)obj).Property2) && this.Property3.AreEqual(((ClassB)obj).Property3) && this.Property4.AreEqual(((ClassB)obj).Property4);
        }
        
        public override int GetHashCode()
        {
            return this.Property1.GetHashCode() + this.Property2.GetHashCode() + this.Property3.GetHashCode() + this.Property4.GetHashCode();
        }

    }

    internal static class CollectionsExtensionMethods
    {
        internal static bool AreEqual(this IList<string> list1, IList<string> list2)
        {
            return list1.SequenceEqual(list2);
        }
        internal static bool AreEqual(this IDictionary<string, object> dictionary1, IDictionary<string, object> dictionary2)
        {
            return dictionary1.OrderBy(kvp => kvp.Key).SequenceEqual(dictionary2.OrderBy(kvp => kvp.Key));
        }
        
    }
}