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

## Utilização do react para front.
- O código acima é um exemplo de um componente React que busca e exibe uma lista de pedidos de uma API.
- Ele utiliza o hook useEffect para fazer a requisição quando o componente é montado e gerencia estados de carregamento e erro.

para abrir ele: http://localhost:5189/api/Pedido 

## Como executar

```bash
dotnet restore
dotnet build
dotnet run
