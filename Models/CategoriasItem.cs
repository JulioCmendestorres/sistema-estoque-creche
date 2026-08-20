using System;
using System.Collections.Generic;

namespace ESTOQUE_CRECHE.Models;

public partial class CategoriaItem
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public bool? Ativo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public virtual ICollection<Item> Itens { get; set; } = new List<Item>();
}
