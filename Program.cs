var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); /* mapeia todas controllers, que possuem a assinatura de ser uma controller, é até por isso que 
                       * possui herança, marcação de atributo com os decorators, coleta todas estas classes e entende estas
                       * rotas e cria um dicionário de rotas e o disponibiliza para o asp.net interno e swagger
                       */ //1ª forma de mapear os roteamentos

app.MapGet("/", () => "Acesse /swagger para mais infos"); 
//mapeando roteamentos sem escrever uma controller aqui adicionamos um contexto, como segundo parametro
//e nele podemos chamar algum método, mas neste caso, só estamos retornando uma string.

app.MapGet("/teste-get", () => "teste");

app.Run();
