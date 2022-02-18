using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio
{
    public class Desafio
    {
        public async Task Inicio()
        {
            Console.WriteLine("Digite um valor (em Real) a ser convertido: ");
            var valor = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Gostaria de converter o valor para Dólar digite 1, para Rublo Russo digite 2: ");
            var moeda = Console.ReadLine();
            switch (moeda){
                case "1":
                var conversaoDolar = await dolar(valor);
                 Console.WriteLine($"O valor convertido em Dólar é de: {conversaoDolar}");
                break;
                 case "2":
                 var conversaoRubloRusso = await rubloRusso(valor);
                  Console.WriteLine($"O valor convertido em Rublo Russo é de: {conversaoRubloRusso}");
                break;
                default:
                 Console.WriteLine("Moeda inválida");
                 await Inicio();
                break;
            }

        }

        public async Task<double> dolar(double valor)
        {
            var cliente = new HttpClient();
            var conversao = await cliente.GetStringAsync("https://economia.awesomeapi.com.br/last/BRL-USD");
            Moeda moeda = JsonSerializer.Deserialize<Moeda>(conversao);
            return Convert.ToDouble(moeda.BRLUSD.high.Replace(".", ",")) * valor;
        }

        public async Task<double> rubloRusso(double valor)
        {
            var cliente = new HttpClient();
            var conversao = await cliente.GetStringAsync("https://economia.awesomeapi.com.br/last/BRL-RUB");
            Moeda moeda = JsonSerializer.Deserialize<Moeda>(conversao);
            return Convert.ToDouble(moeda.BRLRUB.high.Replace(".", ",")) * valor;
        }
    }
}