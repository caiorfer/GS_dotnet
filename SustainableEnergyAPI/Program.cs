using SustainableEnergyAPI.Data;
using SustainableEnergyAPI.Repositories;
using SustainableEnergyAPI.Services;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Configura��o dos servi�os da aplica��o
builder.Services.AddControllers();

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtendo a string de conex�o do MongoDB a partir do appsettings.json
var mongoDbConnectionString = builder.Configuration.GetConnectionString("MongoDb");

// Verificando se a string de conex�o foi carregada corretamente
if (string.IsNullOrEmpty(mongoDbConnectionString))
{
    throw new InvalidOperationException("A string de conex�o do MongoDB n�o foi configurada.");
}

// Configurando o MongoDbContext com Singleton
builder.Services.AddSingleton<MongoDbContext>(sp =>
    new MongoDbContext(mongoDbConnectionString, "SustainableEnergyDB"));

// Configura��o do HttpClient para a API da OpenAI
builder.Services.AddHttpClient("OpenAI", client =>
{
    client.BaseAddress = new Uri("https://api.openai.com/v1/");
    var apiKey = builder.Configuration["OpenAI:ApiKey"];

    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("A chave da API da OpenAI n�o foi configurada.");
    }

    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Configura��o dos reposit�rios e servi�os
builder.Services.AddScoped<IEnergyProcessRepository, EnergyProcessRepository>();
builder.Services.AddScoped<EnergyProcessService>();
builder.Services.AddScoped<OpenAIService>(); // Registro do OpenAIService

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP
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
