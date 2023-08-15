# BancoDigital
# API Simulador de Banco Digital

Este projeto é uma API em C# que simula algumas funcionalidades de um banco digital, como movimentação de contas e quitação de dívidas.
Nessa primeira versao, nao tem conexao com banco de dados.

## Funcionalidades

A API oferece as seguintes funcionalidades:

- Movimentação de conta corrente para quitar dívida
- Consulta de saldo de uma conta
- Consulta de transações de uma conta

## Configuração

1. Clone o repositório para a sua máquina local.
2. Abra o projeto no Visual Studio.
3. Configure a porta da aplicação no arquivo `launchSettings.json` ou utilize a porta padrão 5000.
4. Execute o projeto pressionando F5.

## Endpoints

### Movimentação de conta para quitar dívida

`POST /api/Banco/quitar-divid/{contaId}a`



Realiza uma movimentação de conta para quitar uma dívida.

Parâmetros:
- `contaId` (int): ID da conta corrente.
- `valor` (decimal): Valor da movimentação.

### Consulta de saldo da conta

`GET /api/Banco/saldo/{contaId}`

Retorna o saldo da conta corrente.

Parâmetros:
- `contaId` (int): ID da conta corrente.

### Consulta de transações da conta

`GET /api/Banco/transacoes/{contaId}`

Retorna as transações realizadas na conta corrente.

Parâmetros:
- `contaId` (int): ID da conta corrente.

## Exemplos de Uso

### Movimentação de sacar

```bash
curl -X POST "http://localhost:5000/api/Banco/sacar" -d "contaId=1&valor=100"


### Consulta de saldo da conta

curl "http://localhost:5000/api/Banco/saldo/1"


### Consulta de transações da conta    
curl "http://localhost:5000/api/Banco/transacoes/1"


