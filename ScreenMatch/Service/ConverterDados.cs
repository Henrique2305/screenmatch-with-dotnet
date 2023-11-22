using Newtonsoft.Json;
using System;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace ScreenMatch.Service;

public class ConverterDados : IConverteDados
{
    private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings();

    public T ObterDados<T>(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(json, jsonSettings);
        }
        catch (JsonSerializationException e)
        {
            throw new InvalidOperationException("Erro ao desserializar o JSON.", e);
        }
    }
}
