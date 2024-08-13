using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public string? PropName { get; set; }
        [NotMapped]
        public string? PropValue { get; set; }

        Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public int Count
        {
            get
            {
                return _dictionary.Count;
            }
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

        public void AddProperty<TTValue>(string key, TTValue value = default(TTValue))
        {
            _dictionary[key] = value;
        }
        public void AddProperty(string typeName, string key, object value)
        {
            Type type = Type.GetType(typeName);
            _dictionary[key] = Convert.ChangeType(value, type);
        }
    }
}
