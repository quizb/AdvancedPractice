using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPractice
{
    public class Repository<T> where T : class
    {
        public readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }
        public T Get(int id)
        {
            return _items.FirstOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == id);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}
