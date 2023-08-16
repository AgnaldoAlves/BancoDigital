using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using BancoDigital.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

[Route("api/[controller]")]
[ApiController]
public class BancoController : ControllerBase
{

    private  List<Conta> contas = new List<Conta>
    {
        new Conta { Id = 1, NomeTitular = "João", Saldo = 1000 },
        new Conta { Id = 2, NomeTitular = "Maria", Saldo = 1500 },
        new Conta { Id = 3, NomeTitular = "Carlos", Saldo = 200 },
    };

    private  List<Transacao> transacoes = new List<Transacao>();

    private  List<Divida> dividas = new List<Divida>
    {
        new Divida { Id = 1, ContaId = 1, Valor = 300 },
        new Divida { Id = 2, ContaId = 2, Valor = 500 },
     
    };

    [HttpPost("sacar")]
    public IActionResult RealizarMovimentacao(int contaId, decimal valor)
    {
        var conta = contas.FirstOrDefault(c => c.Id == contaId);
        if (conta == null)
            return NotFound("Conta não encontrada");

        if (conta.Saldo < valor)
            return BadRequest("Saldo insuficiente");

        conta.Saldo -= valor;
        transacoes.Add(new Transacao { ContaId = contaId, Valor = -valor, Data = DateTime.Now });

        return Ok("Movimentação realizada com sucesso! Saldo da conta ficou em: " + conta.Saldo);
    }

    [HttpPost("quitar-divida")]
    public IActionResult QuitarDivida(int contaId)
    {
        var conta = contas.FirstOrDefault(c => c.Id == contaId);
        if (conta == null)
            return NotFound("Conta não encontrada");

        var divida = dividas.FirstOrDefault(d => d.Id == contaId);
        if (divida == null)
            return NotFound("Dívida não encontrada para esta conta");

        if (conta.Saldo < divida.Valor)
            return BadRequest("Saldo insuficiente para quitar a dívida");

   

        conta.Saldo -= divida.Valor;
        transacoes.Add(new Transacao { ContaId = contaId, Valor = -divida.Valor, Data = DateTime.Now });
        dividas.Remove(divida);

        var  msgOk  = string.Format("Dívida no valor de {0} , quitada com sucesso! Restando um saldo de : {1}", divida.Valor, conta.Saldo);

        return Ok(msgOk);
    }

    [HttpGet("saldo/{contaId}")]
    public IActionResult ConsultarSaldo(int contaId)
    {
        var conta = contas.FirstOrDefault(c => c.Id == contaId);
        if (conta == null)
            return NotFound("Conta não encontrada");
        return Ok($"Saldo da conta {conta.NomeTitular}: R$ {conta.Saldo}");
    }


    [HttpGet("transacoes/{contaId}")]
    public IActionResult ConsultarTransacoes(int contaId)
    {
        var conta = contas.FirstOrDefault(c => c.Id == contaId);
        if (conta == null)
            return NotFound("Conta não encontrada");

        var transacoesDaConta = transacoes.Where(t => t.ContaId == contaId).ToList();

        return Ok(transacoesDaConta);
    }


}
