using System.Linq;
using CallFire_csharp_sdk.API.Rest.Data;

namespace CallFire_csharp_sdk.API.Rest
{
    internal static class ResourceListOperations
    {
        internal static T[] CastResourceList<T>(ResourceList resource)
        {
            T[] array = null;
            if (resource.Resource != null && resource.Resource.Any())
            {
                array = new T[resource.Resource.Count()];
                for (var i = 0; i < resource.Resource.Count(); i++)
                {
                    array[i] = (T)resource.Resource[i];
                }
            }
            return array;
        }
    }
}
