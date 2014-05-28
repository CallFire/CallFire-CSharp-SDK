using System.Text;

namespace CallFire_csharp_sdk.API.Rest
{
    public class CallfireRestRoute<T>
    {
        public long? Id { get; set; }
        public string Object { get; set; }
        public string Action { get; set; }

        public CallfireRestRoute(long? id)
        {
            Id = id;   
        }

        public CallfireRestRoute(long? id, string obj, string action)
            :this(id)
        {
            Object = obj;
            Action = action;
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

            return result.ToString();
        }

        private static string GetTypeNameForRoute()
        {
            return typeof(T).Name.ToLower();
        }
    }
}
