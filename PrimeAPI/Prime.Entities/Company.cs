using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Entities
{
    public class Company : DynamicObject
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }


        Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public object this[string propertyName]
        {
            get { return _dictionary[propertyName]; }
            set { AddProperty(propertyName, value); }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            _dictionary[binder.Name] = value;
            return true;
        }

        public void AddProperty(string name, object value)
        {
            _dictionary[name] = value;
        }
    }
}
