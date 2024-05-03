using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    //[Route("[controller]")] dessa forma diz que o acesso ao nosso recurso (URI) vai ser o endere�o/nome da controller
    //n�o � uma boa pratica pois tem palavras unidas e letras maiusculas.

    [Route("api/minha-controller")] // aqui fizemos uma forma personalizada, n�o � o melhor nome mas j� � algo
    public class WeatherForecastController : ControllerBase
    {
        //construtor, pode ser criado utilizando ctor, para ser mais rapido, nele podemos fazer inje��es de depenencia tbm
        public WeatherForecastController() 
        {
            
        }

        //[HttpGet("teste")] //localhost:7285/api/minha-controller/teste
        //[Route("api/minha-controller")] se tivermos alguma necessidade al�m da rota definida para a controller, podemos
        //definir a tora aqui direto na nossa action, da forma que fizemos, ou junto do HttpGet que tamb�m funciona
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Get3() //neste caso n�o teve problema pois alteramos o verbo para Post
        {
            return Ok();
        }

        [HttpGet("{id:int}/dado/{id2:int}")] //aqui temos o parametro pois nosso metodo tem parametro e precisamos passar este na rota
        public IActionResult Get2(int id, int id2)
        {
            return Ok();
        }
        //Quando temos 2 rotas/metodos que fazem praticamente a mesma coisa, temos um problema de rotas ambiguas
        //para resolver temos que diferenciar uma das rotas da outra, elas podem fazer a mesma coisa, mas precisam
        //tem uma diferencia��o, para a aplica��o saber qual rota estamos chamando, sendo ela get, post, put ou delete
        //n�o importa, para resolver o problema no caso acima passamos um parametro de ID, para o m�todo e tamb�m para a rota
        //o problema acontece quando utilizamos a mesma rota e mesmo verbo http
    }
}
