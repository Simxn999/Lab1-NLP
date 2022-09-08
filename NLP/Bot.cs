using System.Text;
using Newtonsoft.Json;
using NLPBot.Responses;

namespace NLPBot;

public static class Bot
{
    public static async Task<string> Ask(string question)
    {
        var inputLanguage = await Translator.Detect(question);

        if (!inputLanguage.Equals("en"))
            question = await Translator.Translate(question);

        var answer = await RequestAnswer(question);

        if (inputLanguage.Equals("en"))
            return answer;

        return await Translator.Translate(answer, inputLanguage);
    }

    static async Task<string> RequestAnswer(string question)
    {
        var body = new { question, };
        var requestBody = JsonConvert.SerializeObject(body);

        using var client = new HttpClient();
        using var request = new HttpRequestMessage();

        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(Variables.Instance.LanguageServiceEndpoint);
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        request.Headers.Add("Ocp-Apim-Subscription-Key", Variables.Instance.LanguageServiceKey);

        var response = await client.SendAsync(request).ConfigureAwait(false);
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BotResponse>(data)?.Answers.FirstOrDefault()?.Result ?? "Something went wrong!";

        return result;
    }
}