
# API-PROJECT-AIRLINE

## Descrição
Este projeto é uma API RESTful desenvolvida em .NET para gerenciar operações de uma companhia aérea. Ele permite o cadastro, consulta, atualização e exclusão de pilotos e aeronaves, além de funcionalidades relacionadas a voos, manutenções e cancelamentos.

## Funcionalidades
- Cadastro, listagem, atualização e exclusão de pilotos
- Cadastro, listagem, atualização e exclusão de aeronaves
- Gerenciamento de voos
- Registro de manutenções e cancelamentos
- Validações automáticas de dados

## Estrutura do Projeto
- `Controllers/`: Endpoints da API (ex: PilotoController, AeronaveController)
- `Entities/`: Entidades do domínio (Piloto, Aeronave, Voo, etc.)
- `Services/`: Lógica de negócio
- `ViewModels/`: Modelos de dados para entrada e saída da API
- `Validators/`: Validações de dados
- `Migrations/`: Migrations do Entity Framework

## Como executar
1. Certifique-se de ter o .NET 8.0 SDK instalado.
2. Restaure os pacotes:
   ```powershell
   dotnet restore
   ```
3. Execute as migrations para criar o banco de dados:
   ```powershell
   dotnet ef database update
   ```
4. Inicie a aplicação:
   ```powershell
   dotnet run --project CiaAerea/CiaAerea.csproj
   ```
5. Acesse a API em: `https://localhost:5001/swagger` para testar os endpoints.

## Tecnologias Utilizadas
- ASP.NET Core
- Entity Framework Core
- FluentValidation
- Swagger (OpenAPI)

## Observações
- O projeto segue boas práticas de organização em camadas.
- As validações são feitas via FluentValidation.
- O Swagger está disponível para facilitar o teste dos endpoints.

---
Desenvolvido por Francisco Neto.
