using Newtonsoft.Json;

namespace ScreenMatch.Model;

[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public record DadosTemporada(
    [JsonProperty("Season")]
    int Numero,

    [JsonProperty("Episodes")]
    List<DadosEpisodio> Episodios
);