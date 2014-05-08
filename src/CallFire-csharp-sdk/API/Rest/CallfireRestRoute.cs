using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallFire_csharp_sdk.API.Rest
{
    public class CallfireRestRoute<T>
    {
        public long? Id { get; set; }
        public string Object { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        public CallfireRestRoute(long? id)
        {
            Id = id;   
        }

        public CallfireRestRoute(long? id, string obj, string action, Dictionary<string, string> param)
            :this(id)
        {
            Object = obj;
            Action = action;
            Parameters = param;
        }

        public override string ToString()
        {
            var result = new StringBuilder(string.Format("/{0}", GetTypeNameForRoute()));
            if (!string.IsNullOrEmpty(Object))
            {
                result.Append(string.Format("/{0}", Object));
            }
            if (Id.HasValue)
            {
                result.Append(string.Format("/{0}", Id.Value));
            }
            if (!string.IsNullOrEmpty(Action))
            {
                result.Append(string.Format("/{0}", Action));
            }
            if (Parameters != null && Parameters.Count > 0)
            {
                result.Append(string.Format("?{0}",
                    string.Join("&",Parameters.Select(p=>string.Format("{0}={1}",p.Key,p.Value)).ToArray())));
            }

            return result.ToString();
        }

        private static string GetTypeNameForRoute()
        {
            return typeof(T).Name.ToLower().Substring(2);
        }
    }
}
