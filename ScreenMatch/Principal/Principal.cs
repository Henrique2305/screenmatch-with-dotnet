using ScreenMatch.Model;
using ScreenMatch.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenMatch.Principal;

public class Principal
{
    ConsumoAPI consumo = new ConsumoAPI();
    
    ConverterDados conversor = new ConverterDados();

    private const string ENDERECO = "https://www.omdbapi.com/?t=";

    private const string API_KEY = "&apikey=6585022c";

    public void ExibeMenu()
    {
        Console.Write("Digite o nome da série para busca ");
        string nomeSerie = Console.ReadLine()!;

        var json = consumo.ObterDados(ENDERECO + nomeSerie.Replace(" ", "+") + API_KEY);
        DadosSerie dados = conversor.ObterDados<DadosSerie>(json);
        Console.WriteLine(dados);

        List<DadosTemporada> temporadas = new List<DadosTemporada>();

        for (int i = 1; i <= dados.TotalTemporadas; i++)
        {
            json = consumo.ObterDados(
                    ENDERECO + nomeSerie.Replace(" ", "+") + "&season=" + i + API_KEY).ToString();

            DadosTemporada dadosTemporada = conversor.ObterDados<DadosTemporada>(json);
            temporadas.Add(dadosTemporada);
        }

        temporadas.ForEach(t => t.ToString());

        List<Episodio> episodios = temporadas
            .SelectMany(t => t.Episodios.Select(d => new Episodio(t.Numero, d)))
            .ToList();

        episodios.ForEach(e => Console.WriteLine(e));
    }
}
