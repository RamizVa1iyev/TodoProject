using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TodoProject.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object data)
        {
            var stringData = JsonConvert.SerializeObject(data);
            session.SetString(key,stringData);
        }

        public static T GetObject<T>(this ISession session, string key) where T:class
        {
            var stringData = session.GetString(key);
            if (string.IsNullOrEmpty(stringData))
            {
                return null;
            }
            else
            {
                var data = JsonConvert.DeserializeObject<T>(stringData);
                return data;
            }
        }
    }
}
