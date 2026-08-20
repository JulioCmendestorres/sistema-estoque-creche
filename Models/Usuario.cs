using System;
using System.Collections.Generic;

namespace ESTOQUE_CRECHE.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? Papel { get; set; }

    public bool? Ativo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public virtual ICollection<LogAuditoria> LogsAuditoria { get; set; } = new List<LogAuditoria>();

    public virtual ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
}
