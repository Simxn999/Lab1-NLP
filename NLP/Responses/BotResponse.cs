using Newtonsoft.Json;

namespace NLPBot.Responses;

[Serializable]
public class BotResponse
{
    [JsonProperty("answers")]
    public List<Answer> Answers { get; set; } = default!;
}

public class Answer
{
    [JsonProperty("questions")]
    public List<string> Questions { get; set; } = default!;

    [JsonProperty("answer")]
    public string Result { get; set; } = default!;

    [JsonProperty("confidenceScore")]
    public double ConfidenceScore { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; } = default!;

    [JsonProperty("metadata")]
    public Metadata Metadata { get; set; } = default!;

    [JsonProperty("dialog")]
    public Dialog Dialog { get; set; } = default!;
}

public class Dialog
{
    [JsonProperty("isContextOnly")]
    public bool IsContextOnly { get; set; }

    [JsonProperty("prompts")]
    public List<object> Prompts { get; set; } = default!;
}

public class Metadata
{
    [JsonProperty("editorial")]
    public string Editorial { get; set; } = default!;
}