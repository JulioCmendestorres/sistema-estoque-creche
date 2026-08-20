using System;
using System.Collections.Generic;

namespace ESTOQUE_CRECHE.Models;

public partial class Item
{
    public int Id { get; set; }

    public string CodigoInterno { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public int CategoriaId { get; set; }

    public string? UnidadeMedida { get; set; }

    public int QuantidadeAtual { get; set; }

    public decimal? ValorTotalEstoque { get; set; }

    public int? QuantidadeMinima { get; set; }

    public bool? Ativo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public virtual CategoriaItem Categoria { get; set; } = null!;

    public virtual ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
}
