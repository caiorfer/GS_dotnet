**U.R.S.A.**
99553 - Jaquelline Aparecida Candido Barbosa de Sousa
99475 - Florbela Freitas Oliveira
99617 - caio rocha fernandes

https://github.com/caiorfer/GS_dotnet
Sustainable Energy API
Descrição do Projeto
O Sustainable Energy API é uma aplicação que visa promover a sustentabilidade energética ao oferecer uma API para gerenciar processos energéticos, usando um banco de dados MongoDB para armazenar os dados de forma eficiente e segura. Além disso, a aplicação integra com a API OpenAI para fornecer recursos adicionais, como análise de dados e automação com inteligência artificial.

Funcionalidades
Gerenciamento de Processos Energéticos: CRUD (Create, Read, Update, Delete) para gerenciamento de processos de eficiência energética.
Integração com OpenAI: Capacidade de gerar respostas com IA para promover recomendações relacionadas a processos energéticos.
MongoDB: Utiliza MongoDB para armazenamento de dados relacionados aos processos energéticos.
Swagger: Documentação da API com o Swagger, facilitando o uso e integração de desenvolvedores.

Tecnologias Utilizadas
.NET 8: Framework para construção da API.
MongoDB: Banco de dados NoSQL para persistência de dados.
OpenAI API: Integração com a API do OpenAI para utilizar GPT-4.
Swagger: Ferramenta para gerar e exibir a documentação da API.
xUnit e Moq: Ferramentas para criação de testes automatizados.

Endpoints da API
GET /api/energyprocess
[
  {
    "id": "1",
    "name": "Processo Solar",
    "efficiency": 95
  },
  {
    "id": "2",
    "name": "Processo Eólico",
    "efficiency": 85
  }
]

POST /api/energyprocess
{
  "name": "Processo Hidrelétrico",
  "efficiency": 90
}
{
  "id": "3",
  "name": "Processo Hidrelétrico",
  "efficiency": 90
}
GET /api/energyprocess/{id}
{
  "name": "Processo Solar Avançado",
  "efficiency": 98
}
DELETE /api/energyprocess/{id}
Deleta

Estrutura do projeto
SustainableEnergyAPI/
│
├── Controllers/
│   ├── EnergyProcessController.cs
│
├── Services/
│   ├── EnergyProcessService.cs
│
├── Models/
│   ├── EnergyProcess.cs
│
├── Repositories/
│   ├── EnergyProcessRepository.cs
│
├── Data/
│   ├── MongoDbContext.cs
│
├── Tests/
│   ├── EnergyProcessServiceTests.cs
│
├── appsettings.json
├── Program.cs
└── Startup.cs (se aplicável)
