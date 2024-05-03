using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Produto),StatusCodes.Status200OK)] //Formatadores de resposta, para melhor documentar a api
        public IActionResult Get() //metodo get que trária todos os produtos
        {
            //200 - deu certo, dentro do Ok retornamos o dado, no caso chamariamos o método que vai no banco e nos trás o
            //produto
            return Ok(new Produto { Id = 1, Nome = "Teste"});//instanciamos um produto para dar um exemplo 
        }

        [HttpGet("{id:int}")] //parametro id pois queremos um produto especifico
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)] //Formatando a resposta com o retorno de objeto
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Caso id informado não exista, retorna um 404
        public IActionResult Get(int id) //metodo get para trazer um produto especifico
        {
            //200 - deu tudo certo e retorna o dado do produto especifico.
            return Ok(new Produto { Id = 1, Nome = "Teste" }); 
        }

        [HttpPost] // no Post recebemos o dado do nosso cliente informando como é o produto
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)] // com estes formatadores, ele exibe na API os 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]           // possiveis retornos, mostrando o que podemos receber
        public IActionResult Post(Produto produto)
        //Metodo Post para criar um novo produto,então ele tem um parametro que é o produto, este parametro
        //não é de rotas mas sim de corpo, no requestBody
        {
            //201 - Ok, foi criado, tome o endpoint para consultar qual o metodo para chamar e ter acesso a
            //esse recurso que você criou, passamos então a rota "Get", depois criamos a estrutura de rota de um parametro
            //de rota vazio, um objeto dinamico new {id = produto.Id}, e por fim o objeto que é o próprio produto que criamos
            return CreatedAtAction("Get", new {id = produto.Id}, produto); 
        }

        [HttpPut("{id:int}")] //parametro de rota id pois queremos atualizar 1 produto especifico
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, Produto produto) // metodo put para Atualizar um dado que existe
        //aqui passamos 2 parametros, int id, e Produto produto, pois o id vem pela rota e o id do produto
        //vem pelo corpo da requisição, o ASP.net sabe identificar isso.
        {
            //400 - não é possivel atualizar produto id 4 pois produto recebido é id 5, não está sendo tratado o mesmo
            //produto
            if (id != produto.Id) return BadRequest(); 

            return NoContent(); //204 - deu certo mas não tenho nada para te mostrar pois você sabe qual o objeto
        }

        [HttpDelete("{id:int}")] //ele ja espera um parametro id também para excluir produto especifico
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        //Metodo Delete para excluir um produto, neste caso não precisamos passar qual o produto, pois ele vai pegar o
        //id ir no banco de dados, ver se o produto existe e se existir exclui
        {
            return NoContent();
        }

        //E pronto está feito um Crud via API;
    }
}
