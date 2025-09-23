using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TP01.Negocio;
using TP01.Repositorio;
using System.IO;

namespace TP01
{
    public class Program
    {
        public static void Main(string[] args)
            {
                RunConsoleTests();

                Console.WriteLine("\n--- Iniciando Servidor Web ---");
                Console.WriteLine("Acesse as rotas no seu navegador (ex: http://localhost:5000/livro/nome)");
                
                var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Configure(app =>
                {
                    var repository = new BookRepository();
                    var livro = repository.GetBook();

                    if (livro == null)
                    {
                        app.Run(async context =>
                        {
                            await context.Response.WriteAsync("Erro: Nenhum livro encontrado no repositório CSV.");
                        });
                        return;
                    }

                    app.Run(async context =>
                    {
                        var path = context.Request.Path.Value?.ToLower().TrimEnd('/');

                        // B1 – Nome do livro
                        if (path == "/livro/nome")
                        {
                            await context.Response.WriteAsync(livro.GetName());
                        }
                        // B2 – ToString()
                        else if (path == "/livro/tostring")
                        {
                            await context.Response.WriteAsync(livro.ToString());
                        }
                        // B3 – GetAuthorNames()
                        else if (path == "/livro/autores")
                        {
                            await context.Response.WriteAsync(livro.GetAuthorNames());
                        }
                        // B4 – Página HTML
                        else if (path == "/livro/apresentarlivro")
                        {
                            context.Response.ContentType = "text/html; charset=utf-8";

                            string autoresHtml = "";
                            foreach (var autor in livro.GetAuthors())
                            {
                                autoresHtml += $"<li>{autor.GetName()} ({autor.GetEmail()})</li>";
                            }

                            string paginaHtml = $@"
                                <!DOCTYPE html>
                                <html>
                                <head><title>Detalhes do Livro</title></head>
                                <body>
                                    <h1>{livro.GetName()}</h1>
                                    <p>Preço: R$ {livro.GetPrice()}</p>
                                    <p>Quantidade: {livro.GetQty()}</p>
                                    <h3>Autores:</h3>
                                    <ul>{autoresHtml}</ul>
                                </body>
                                </html>";

                            await context.Response.WriteAsync(paginaHtml);
                        }
                        else
                        {
                            await context.Response.WriteAsync("Rota não encontrada.");
                        }
                    });
                })
                .Build();

            host.Run();
        }


        public static void RunConsoleTests()
        {
            Console.WriteLine("--- Teste da Classe Book ---");

            BookRepository repository = new BookRepository();
            Book meuLivro = repository.GetBook();

            Console.WriteLine($"Livro carregado: {meuLivro.GetName()}");
            Console.WriteLine();

            Console.WriteLine("1. Testando Getters Iniciais:");
            Console.WriteLine($"Nome: {meuLivro.GetName()}");
            Console.WriteLine($"Preço: R$ {meuLivro.GetPrice()}");
            Console.WriteLine($"Quantidade: {meuLivro.GetQty()}");

            Author[] autores = meuLivro.GetAuthors();
            Console.WriteLine("Autores (via GetAuthors):");
            foreach (var autor in autores)
            {
                Console.WriteLine($"- {autor.GetName()}");
            }
            Console.WriteLine();

            Console.WriteLine("2. Testando o método GetAuthorNames():");
            Console.WriteLine($"Nomes: {meuLivro.GetAuthorNames()}");
            Console.WriteLine();

            Console.WriteLine("3. Testando o método ToString():");
            Console.WriteLine(meuLivro.ToString());
            Console.WriteLine();

            Console.WriteLine("4. Testando os Setters:");
            Console.WriteLine("Alterando preço para 89.90 e quantidade para 15...");
            meuLivro.SetPrice(89.90);
            meuLivro.SetQty(15);
            Console.WriteLine($"Novo Preço: R$ {meuLivro.GetPrice()}");
            Console.WriteLine($"Nova Quantidade: {meuLivro.GetQty()}");
            Console.WriteLine();

            Console.WriteLine("Estado final do objeto com ToString():");
            Console.WriteLine(meuLivro.ToString());
        }
                
    }
}