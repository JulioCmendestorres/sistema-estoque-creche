using System;
using System.Collections.Generic;

namespace ESTOQUE_CRECHE.Models;

public partial class Parceiro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Tipo { get; set; }

    public string? CpfCnpj { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public bool? Ativo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public virtual ICollection<Movimentaco> Movimentacos { get; set; } = new List<Movimentaco>();
}
