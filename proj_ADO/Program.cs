// See https://aka.ms/new-console-template for more information
using proj_ADO.Controllers;
using proj_ADO.Model;
using proj_ADO.Models;

Console.WriteLine("Proj MVC - ADO.Net");

Console.WriteLine("Teste Inclusão de dados");

Engine engine = new()
{
    Description = "Teste"
};

AirPlane airplane = new()
{
    Description = "Para testes",
    Id = 1,
    Name = "TOP TURBO",
    NumberOfPassagers = 20,
    Engine = engine
};

if (new AirPlaneController().Insert(airplane))
{
    Console.WriteLine("Sucesso! registro inserido!");
}
else
{
    Console.WriteLine("Erro ao inserir registro");
}
//new AirPlaneController().FindAll().ForEach(Console.WriteLine);