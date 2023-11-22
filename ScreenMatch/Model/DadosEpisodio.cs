using Newtonsoft.Json;

namespace ScreenMatch.Model;

[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public record DadosEpisodio(
    [JsonProperty("Title")]
    string Titulo,

    [JsonProperty("Episode")]
    int Numero,

    [JsonProperty("imdbRating")]
    string Avaliacao,

    [JsonProperty("Released")]
    string Data
);