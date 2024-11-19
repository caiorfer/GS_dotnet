using SustainableEnergyAPI.Data;
using SustainableEnergyAPI.Repositories;
using SustainableEnergyAPI.Services;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços da aplicação
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtendo a string de conexão do MongoDB a partir do appsettings.json
var mongoDbConnectionString = builder.Configuration.GetConnectionString("MongoDb");

// Verificando se a string de conexão foi carregada corretamente
if (string.IsNullOrEmpty(mongoDbConnectionString))
{
    throw new InvalidOperationException("A string de conexão do MongoDB não foi configurada.");
}

// Configurando o MongoDbContext com Singleton
builder.Services.AddSingleton<MongoDbContext>(sp =>
    new MongoDbContext(mongoDbConnectionString, "SustainableEnergyDB"));

// Configuração do HttpClient para a API da OpenAI
builder.Services.AddHttpClient("OpenAI", client =>
{
    client.BaseAddress = new Uri("https://api.openai.com/v1/");
    var apiKey = builder.Configuration["OpenAI:ApiKey"];

    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("A chave da API da OpenAI não foi configurada.");
    }

    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Configuração dos repositórios e serviços
builder.Services.AddScoped<IEnergyProcessRepository, EnergyProcessRepository>();
builder.Services.AddScoped<EnergyProcessService>();
builder.Services.AddScoped<OpenAIService>(); // Registro do OpenAIService

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SustainableEnergyAPI v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

app.Run();
