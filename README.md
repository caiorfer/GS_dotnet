Rm99617 - caio rocha fernandes

Rm99475 - Florbela Freitas Oliveira

Rm99553 - Jaquelline Aparecida Candido Barbosa de Sousa


*SustainableEnergyAPI*



SustainableEnergyAPI é uma aplicação desenvolvida em .NET Core para otimizar processos de energia sustentável. A API gerencia informações sobre processos energéticos e se integra com a OpenAI para fornecer insights adicionais.

*Índice*
Introdução
Funcionalidades
Tecnologias Utilizadas
Instalação e Configuração
Como Executar
Testes
Endpoints
Contribuição
Licença
Introdução
Este projeto visa fornecer uma API robusta para gerenciar e otimizar processos energéticos, utilizando MongoDB para persistência de dados e integrando inteligência artificial por meio da OpenAI API.

*Funcionalidades*
Gerenciamento de Processos de Energia:
Criação, leitura, atualização e exclusão de processos energéticos.
Integração com OpenAI:
Utiliza modelos GPT para fornecer insights baseados nos dados enviados.
Documentação de API:
Swagger integrado para explorar e testar endpoints.
Tecnologias Utilizadas
.NET Core 7
MongoDB
Swagger
OpenAI API
xUnit e Moq (para testes)
Instalação e Configuração
Pré-requisitos
.NET SDK 7.0
MongoDB
Chave da API da OpenAI (OpenAI API Key)
Passos para Configuração
Clone o repositório:

*Copiar código*
git clone https://github.com/seuusuario/SustainableEnergyAPI.git
cd SustainableEnergyAPI
Configure a conexão com MongoDB no appsettings.json:

json
Copiar código
{
  "ConnectionStrings": {
    "MongoDb": "mongodb://localhost:27017"
  },
  "OpenAI": {
    "ApiKey": "sua-chave-openai",
    "Model": "gpt-4"
  }
}
Restaure as dependências:

Copiar código
dotnet restore
Como Executar
Compile e execute o projeto:

Copiar código
dotnet run
Acesse a documentação Swagger:

Copiar código
https://localhost:<porta>/swagger/index.html
Testes
O projeto de testes está configurado usando xUnit e Moq. Para rodar os testes:

Navegue até o diretório de testes:

Copiar código
cd SustainableEnergyAPI.Tests
Execute os testes:

Copiar código
dotnet test

Licença
Este projeto é licenciado sob a MIT License.
