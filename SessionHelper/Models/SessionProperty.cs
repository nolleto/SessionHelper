using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionHelper.Models
{
    public class SessionProperty<T>
    {
        private string key { get; set; }
        private Type type { get { return typeof(T); } }

        public SessionProperty(string key)
        {
            this.key = key;
        }

        public SessionProperty<T> Set(T value)
        {
            Session.SetSessionProperty(key, value);
            return this;
        }

        public T Get()
        {
            return Session.GetSessionProperty<T>(key);
        }

        public T GetOrDefault()
        {
            return GetValue((current) =>
            {
                if (!type.IsPrimitive && type != typeof(string)) return Activator.CreateInstance<T>();
                return current;
            });
        }

        public T GetOrDefault(T defaultValue)
        {
            return GetValue((current) =>
            {
                return defaultValue;
            });
        }

        public SessionProperty<T> Reset()
        {
            Set(default(T));
            return this;
        }

        private T GetValue(Func<T, T> valueNull = null)
        {
            T currentValue = Get();
            if (currentValue == null && valueNull != null)
            {
                currentValue = valueNull(currentValue);
            }
            return currentValue;
        }
    }
}
