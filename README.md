# Loja De Ferramentas

- Este projeto é uma API para uma loja de ferramentas, com integração ao Mercado Pago para processamento de transações. A arquitetura adotada é o Domain-Driven Design (DDD), que busca organizar o código em torno do domínio do negócio, garantindo um design mais flexível e focado na solução dos problemas específicos da loja de ferramentas.

## Ferramentas Utilizadas

**Tecnologias Utilizadas**

- .NET - Backend da API

- Entity Framework Core - ORM para interação com banco de dados

- SQL Server - Banco de dados relacional

- FluentValidation - Validação de dados

- JWT (JSON Web Token) - Autenticação e segurança

- Swagger - Documentação da API

- Mercado Pago API - Integração para pagamentos

## Funcionalidades 

- ### Gestão de Produtos

- Cadastro, edição e remoção de ferramentas

- Listagem de produtos com filtros 

- Upload de imagens dos produtos

### Gestão de Pedidos

- Criar pedidos

- Consultar status dos pedidos


### Autenticação e Autorização

- Registro e login de usuários

- Controle de acesso baseado em funções (admin, cliente, etc.)

### Pagamentos via Mercado Pago

- Integração com Mercado Pago para processar pagamentos

- Webhooks para notificação de status de pagamento

- Consulta de transações
