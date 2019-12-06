namespace SerializationTest.Net
{
    public class ClassA
    {
        public ClassB Property1 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            
            return this.Property1.Equals(((ClassA)obj).Property1);
        }
        
        public override int GetHashCode()
        {
            return this.Property1.GetHashCode();
        }
    }
}