using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ScreenMatch.Model;

internal class Episodio
{
    private int Temporada { get; set; }
    private string Titulo { get; set; }
    private int NumeroEpisodio { get; set; }
    private double Avaliacao { get; set; }
    private DateTime? DataLancamento { get; set; }

    public Episodio(int numeroTemporada, DadosEpisodio dadosEpisodio)
    {
        this.Temporada = numeroTemporada;
        this.Titulo = dadosEpisodio.Titulo;
        this.NumeroEpisodio = dadosEpisodio.Numero;

        if (double.TryParse(dadosEpisodio.Avaliacao, System.Globalization.NumberStyles.AllowDecimalPoint, 
            System.Globalization.CultureInfo.InvariantCulture, out double avaliacao))
        {
            this.Avaliacao = avaliacao;
        }
        else
        {
            this.Avaliacao = 0.0;
        }

        //this.Avaliacao = dadosEpisodio.Avaliacao;

        //try
        //{
        //    this.Avaliacao = double.Parse(dadosEpisodio.Avaliacao);
        //}
        //catch (FormatException ex)
        //{
        //    this.Avaliacao = 0.0;
        //}

        try
        {
            this.DataLancamento = DateTime.Parse(dadosEpisodio.Data);
        }
        catch (FormatException ex)
        {
            this.DataLancamento = null;
        }
    }

    public override string ToString()
    {
        return $"Temporada=  {Temporada}, " +
            $"Titulo=  {Titulo}, " +
            $"Numero Episodio=  {NumeroEpisodio}, " +
            $"Avaliacao=  {Avaliacao}, " +
            $"Data Lançamento=  {DataLancamento}";
    }
}
