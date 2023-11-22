using Newtonsoft.Json;

namespace ScreenMatch.Model;

[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public record DadosSerie(
    [JsonProperty("Title")]
    string Titulo,

    [JsonProperty("totalSeasons")]
    int TotalTemporadas,

    [JsonProperty("imdbRating")]
    string Avaliacao
);