using System.Threading.Tasks;
using System.Net.Http;


namespace SoundCloud
{
	public class JsonConverter
	{
		
		public async Task<string> GetStringbyJson(string link)
		{
			HttpClient client = new HttpClient ();
			HttpResponseMessage message = await client.GetAsync (link);
			return await message.Content.ReadAsStringAsync ();

		}
	}
}

