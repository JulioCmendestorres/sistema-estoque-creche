using System;
using System.Collections.Generic;

namespace ESTOQUE_CRECHE.Models;

public partial class LogsAuditorium
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string TabelaAfetada { get; set; } = null!;

    public string Acao { get; set; } = null!;

    public int? RegistroId { get; set; }

    public string? DadosAntigos { get; set; }

    public string? DadosNovos { get; set; }

    public string? IpUsuario { get; set; }

    public DateTime? CriadoEm { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
