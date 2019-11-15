namespace UnderstandingDependencyInjection.Net.Entities
{
    public sealed class Unused
    {
        #pragma warning disable 628
        protected Unused() {}
        public static Unused Instance = new Unused();
     }
}