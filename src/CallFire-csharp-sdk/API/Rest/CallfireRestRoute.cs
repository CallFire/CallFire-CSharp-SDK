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

        public CallfireRestRoute()
        {
        }

        public CallfireRestRoute(long? id, string obj, string action)
            :this(id)
        {
            Object = obj;
            Action = action;
        }

        public override string ToString()
        {
            const string slashFormat = "/{0}";

            var result = new StringBuilder(string.Format(slashFormat, GetTypeNameForRoute()));

            if (!string.IsNullOrEmpty(Object))
            {
                result.AppendFormat(slashFormat, Object);
            }
            if (Id.HasValue)
            {
                result.AppendFormat(slashFormat, Id.Value);
            }
            if (!string.IsNullOrEmpty(Action))
            {
                result.AppendFormat(slashFormat, Action);
            }

            return result.ToString();
        }

        private static string GetTypeNameForRoute()
        {
            return typeof(T).Name.ToLower();
        }
    }
}
