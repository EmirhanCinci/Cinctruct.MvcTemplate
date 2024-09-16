using System.Text.Json;

namespace Cintruct.MvcUi.Extensions
{
	/// <summary>
	/// Provides extension methods for working with session data in ASP.NET Core.
	/// </summary>
	public static class SessionExtensions
    {
		/// <summary>
		/// Stores an object in the session with the specified key.
		/// </summary>
		/// <param name="session">The session to which the object will be stored.</param>
		/// <param name="key">The key under which the object will be stored.</param>
		/// <param name="data">The object to be stored in the session.</param>
		public static void SetObject(this ISession session, string key, object data)
        {
            session.SetString(key, JsonSerializer.Serialize(data));
        }

		/// <summary>
		/// Retrieves an object from the session using the specified key.
		/// </summary>
		/// <typeparam name="T">The type of the object to retrieve.</typeparam>
		/// <param name="session">The session from which the object will be retrieved.</param>
		/// <param name="key">The key under which the object is stored.</param>
		/// <returns>The object retrieved from the session, or the default value for the type if not found.</returns>
		public static T GetObject<T>(this ISession session, string key)
        {
            var sessionJsonData = session.GetString(key);
            if (sessionJsonData != null)
            {
                return JsonSerializer.Deserialize<T>(sessionJsonData);
            }
            return default(T);
        }
    }
}
