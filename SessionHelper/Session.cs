using SessionHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace SessionHelper
{
    public static class Session
    {
        internal static HttpSessionState session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        internal static TModel GetSessionProperty<TModel>(string prop)
        {
            if (Session.session == null)
                return default(TModel);

            var obj = Session.session[prop];
            if (obj != null)
            {
                return (TModel)obj;
            }
            return default(TModel);
        }

        internal static void SetSessionProperty(string prop, object value)
        {
            if (Session.session != null)
            {
                Session.session[prop] = value;
            }
        }

        public static SessionProperty<TModel> CreateProperty<TModel>(string name)
        {
            return new SessionProperty<TModel>(name);
        }

        public static SessionProperty<object> CreateProperty(string name)
        {
            return new SessionProperty<object>(name);
        }

        public static TModel GetValue<TModel>(string name)
        {
            return new SessionProperty<TModel>(name).Get();
        }

        public static object GetValue(string name)
        {
            return new SessionProperty<object>(name).Get();
        }
    }
}
