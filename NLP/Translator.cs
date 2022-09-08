using System.Text;
using Newtonsoft.Json;
using NLPBot.Responses;

namespace NLPBot;

public static class Translator
{
    public static async Task<string> Detect(string text)
    {
        var body = new object[] { new { Text = text, }, };
        var requestBody = JsonConvert.SerializeObject(body);

        using var client = new HttpClient();
        using var request = new HttpRequestMessage();

        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri($"{Variables.Instance.TranslatorEndpoint}/detect?api-version=3.0");
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        request.Headers.Add("Ocp-Apim-Subscription-Key", Variables.Instance.CognitiveServiceKey);
        request.Headers.Add("Ocp-Apim-Subscription-Region", Variables.Instance.CognitiveServiceRegion);

        var response = await client.SendAsync(request).ConfigureAwait(false);
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<LanguageDetectionResponse>>(data)?.FirstOrDefault()?.Language ?? "";

        return result;
    }

    public static async Task<string> Translate(string text, string responseLanguage = "en")
    {
        var body = new object[] { new { Text = text, }, };
        var requestBody = JsonConvert.SerializeObject(body);

        using var client = new HttpClient();
        using var request = new HttpRequestMessage();

        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri($"{Variables.Instance.TranslatorEndpoint}/translate?api-version=3.0&to={responseLanguage}");
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        request.Headers.Add("Ocp-Apim-Subscription-Key", Variables.Instance.CognitiveServiceKey);
        request.Headers.Add("Ocp-Apim-Subscription-Region", Variables.Instance.CognitiveServiceRegion);

        var response = await client.SendAsync(request).ConfigureAwait(false);
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<TranslationResponse>>(data)?.FirstOrDefault()?.Result.FirstOrDefault()?.Text ??
                     "Something went wrong!";

        return result;
    }
}