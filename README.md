# 🛒 LojaPedidosApi

API RESTful desenvolvida em 2025 por Joao Vitor Ferreira
 ASP.NET Core para gerenciar pedidos de uma loja, utilizando padrões de DDD e Entity Framework Core para persistência dos dados.

## Funcionalidades

- Criar pedidos
- Adicionar/remover produtos em pedidos
- Fechar pedidos (com regras de negócio)
- Listar e consultar pedidos com detalhes

## Regras de Negócio

- Não é permitido alterar pedidos fechados.
- Só é possível fechar pedidos com ao menos um produto.

## Tecnologias

- ASP.NET Core 6
- Entity Framework Core
- InMemory Database (ou SQLite/PostgreSQL/SQL Server)
- Swagger

## Como executar

```bash
dotnet restore
dotnet build
dotnet run
