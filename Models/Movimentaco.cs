using System;
using System.Collections.Generic;

namespace ESTOQUE_CRECHE.Models;

public partial class Movimentaco
{
    public int Id { get; set; }

    public string NumeroMovimentacao { get; set; } = null!;

    public string? TipoMovimentacao { get; set; }

    public int ItemId { get; set; }

    public int Quantidade { get; set; }

    public decimal? ValorUnitario { get; set; }

    public decimal? ValorTotal { get; set; }

    public DateOnly DataMovimentacao { get; set; }

    public int? ParceiroId { get; set; }

    public string? DescricaoSaida { get; set; }

    public string? Beneficiario { get; set; }

    public int ResponsavelId { get; set; }

    public string? Observacoes { get; set; }

    public string? Status { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public virtual Iten Item { get; set; } = null!;

    public virtual Parceiro? Parceiro { get; set; }

    public virtual Usuario Responsavel { get; set; } = null!;
}
