using System;
using System.Linq;
namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int qtdeNumeros = 6;
            const int maxNumero = 60;

            int[] aposta = new int[qtdeNumeros];
            int[] sorteio = new int[qtdeNumeros];

            Console.WriteLine("Digite seus 6 números da sorte (entre 1 e 60):");

            for (int i = 0; i < qtdeNumeros; i++)
            {
                int numero;
                while (true)
                {
                    Console.Write($"Número {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out numero) && numero >= 1 && numero <= maxNumero && !aposta.Contains(numero))
                    {
                        aposta[i] = numero;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Número inválido ou já escolhido. Tente novamente.");
                    }
                }
            }

            Random rand = new Random();
            int contador = 0;
            while (contador < qtdeNumeros)
            {
                int numeroSorteado = rand.Next(1, maxNumero + 1);
                if (!sorteio.Contains(numeroSorteado))
                {
                    sorteio[contador] = numeroSorteado;
                    contador++;
                }
            }

            int acertos = aposta.Intersect(sorteio).Count();

            Console.WriteLine("\nNúmeros sorteados: " + string.Join(", ", sorteio));
            Console.WriteLine("Seus números: " + string.Join(", ", aposta));
            Console.WriteLine($"Você acertou {acertos} número(s).");
        }
    }
}
