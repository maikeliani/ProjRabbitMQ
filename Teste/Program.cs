using System.Net;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using ProjRabbitMQ.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        HttpClient rabbit = new HttpClient();
        Message mensage = new()
        {
            Description = " to com fome"
        };

        for (int i = 0; i < 10; i++)
        {

            HttpResponseMessage response = rabbit.PostAsJsonAsync("https://localhost:7195/api/Messages", mensage).Result;
            //como nao esta em una funcao async e esta dando um post async então precisa do .Result!!
            //A Consumer vai automaticamente ( a cada 2 segundos) visitando a fila e no caso desse teste ele vai imprimir as mensagens
            //atraves do comando  --> Console.WriteLine("Description: " + message.Description);  que esta dentro da Consumer
        }
    }
}