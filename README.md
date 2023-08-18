# BancoDigital
# API Simulador de Banco Digital

Este projeto é uma API em C# que simula algumas funcionalidades de um banco digital, como movimentação de contas e quitação de dívidas.

## Funcionalidades

A API oferece as seguintes funcionalidades:

- Movimentação de conta corrente para quitar dívida (Sacar, depositar)
- Consulta de saldo de uma conta 
- Consulta de transações de uma conta

## Configuração

1. Clone o repositório para a sua máquina local.
2. Abra o projeto no Visual Studio.
3. Configure a porta da aplicação no arquivo `launchSettings.json` ou utilize a porta padrão 5000.
4. Execute o projeto pressionando F5.

## Teconologias
C#
MySQL

## Pacotes e bibliotecas utilizadas:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql

## Endpoints
Para acessar os os endpoints usei o swagger

https://localhost:7014/swagger/index.html

"DADO QUE eu consuma a API QUANDO eu chamar o post sacar informando o número da conta e um valor válido ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo e a API retornará o saldo atualizado."

"DADO QUE eu consuma a API QUANDO eu chamar a post sacar informando o número da conta e um valor maior do que o meu saldo ENTÃO a API me retornará um erro uma mensagem informando que eu não tenho saldo suficiente."

Primeiro, adicione uma ou mais contas no banco e dividas para uma ou mais contas

### (1) criar conta
POST /api/Contas/Criar Conta

### (2) criar divida
POST /api/Contas/Criar Divida

### (3) sacar conta
POST  /api/Contas/sacar

Parâmetros:
- `contaId` (int): ID da conta corrente.
- 'valor' (double): valor do saque
  
### (4) Consulta de saldo da conta

GET /api/Banco/saldo/{contaId}

Retorna o saldo da conta corrente.

Parâmetros:
- `contaId` (int): ID da conta corrente.
  
### (5) quitar dívida

`POST /api/Banco/quitar-divid/{contaId}`

Realiza uma movimentação de conta para quitar uma dívida.

Parâmetros:
- `contaId` (int): ID da conta corrente.



### (6) Consulta de transações da conta

`GET /api/Banco/transacoes/{contaId}`

Retorna as transações realizadas na conta corrente.

Parâmetros:
- `contaId` (int): ID da conta corrente.




