using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using XiADSL.Arc;

namespace XiADSL.Web.Models
{
    public class ViewMetadata
    {
        private readonly PropertyInfo _property;
        public string Name { get; set; }
        public string UName { get; set; }
        public string Template { get; set; }
        public int Row { get; set; }
        public int Sort { get; set; }
        public int Size { get; set; }
        public string Group { get; set; }
        public  string Lookup { get; set; }

        
        public Dictionary<string, string> Properties { get; set; }
        

        public ViewMetadata(PropertyInfo property)
        {
            _property = property;
            Properties=new Dictionary<string, string>();
            Template = FiledTemplate(property);
            Name = property.Name.ToCamelCase();
            Size = 4;
            Sort = 1;
            Group = "General";

            if (Template=="lookup")
                Lookup = property.PropertyType.Name;
        }

        private string FiledTemplate(PropertyInfo property)
        {
            var t = property.PropertyType;
            if (property.Name == "Id")
                return "Key";

            if (t.Name.ToLower().EndsWith("password"))
                return "password";
            if (t == typeof(string))
                return "string";

            if (t == typeof(int) || t == typeof(int?) || t == typeof(Int16) || t == typeof(Int16?))
                return "number";

            if (t == typeof(decimal) || t == typeof(decimal?) || t == typeof(float) || t == typeof(float?) || t == typeof(double) || t == typeof(double?))
                return "money";

            if (t == typeof(bool) || t == typeof(bool?))
                return "bool";

            if (t == typeof(DateTime) || t == typeof(DateTime?))
                return "date";

            if (t.IsSubclassOf(typeof(BaseModel)))
                return "lookup";

            return "empty";
        }
    }
}