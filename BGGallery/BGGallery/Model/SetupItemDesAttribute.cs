using System;

namespace BGGallery.Model
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class SetupItemDesAttribute : Attribute
    {
        public string Catalog { get; }
        public string Name { get; }
        public string Des { get; }
        public int NumMin { get; }
        public int NumMax { get; }

        public SetupItemDesAttribute(string catg, string name, string des)
        {
            Catalog = catg;
            Name = name;
            Des = des;
        }
        public SetupItemDesAttribute(string catg, string name, string des, int nmin, int nmax)
        {
            Catalog = catg;
            Name = name;
            Des = des;
            NumMin = nmin;
            NumMax = nmax;
        }
    }
}
