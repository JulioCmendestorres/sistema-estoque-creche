using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ESTOQUE_CRECHE.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaItem> CategoriasItens { get; set; }

    public virtual DbSet<Item> Itens { get; set; }

    public virtual DbSet<LogAuditoria> LogsAuditoria { get; set; }

    public virtual DbSet<Movimentacao> Movimentacoes { get; set; }

    public virtual DbSet<Parceiro> Parceiros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F5CD68A7A");

            entity.ToTable("categorias_itens");

            entity.HasIndex(e => e.Nome, "UQ__categori__6F71C0DC77C026CD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValue(true)
                .HasColumnName("ativo");
            entity.Property(e => e.CriadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("criado_em");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__itens__3213E83F18814E45");

            entity.ToTable("itens");

            entity.HasIndex(e => e.CodigoInterno, "UQ__itens__FC1BD89AAFC889AF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValue(true)
                .HasColumnName("ativo");
            entity.Property(e => e.AtualizadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("atualizado_em");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.CodigoInterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_interno");
            entity.Property(e => e.CriadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("criado_em");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.QuantidadeAtual).HasColumnName("quantidade_atual");
            entity.Property(e => e.QuantidadeMinima)
                .HasDefaultValue(0)
                .HasColumnName("quantidade_minima");
            entity.Property(e => e.UnidadeMedida)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("unidade_medida");
            entity.Property(e => e.ValorTotalEstoque)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_total_estoque");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Itens)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_itens_categorias");
        });

        modelBuilder.Entity<LogAuditoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__logs_aud__3213E83FC5C6D53C");

            entity.ToTable("logs_auditoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acao)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("acao");
            entity.Property(e => e.CriadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("criado_em");
            entity.Property(e => e.DadosAntigos).HasColumnName("dados_antigos");
            entity.Property(e => e.DadosNovos).HasColumnName("dados_novos");
            entity.Property(e => e.IpUsuario)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ip_usuario");
            entity.Property(e => e.RegistroId).HasColumnName("registro_id");
            entity.Property(e => e.TabelaAfetada)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tabela_afetada");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LogsAuditoria)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_logs_usuarios");
        });

        modelBuilder.Entity<Movimentacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__moviment__3213E83F97AF07F3");

            entity.ToTable("movimentacoes");

            entity.HasIndex(e => e.NumeroMovimentacao, "UQ__moviment__38482027905199BE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AtualizadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("atualizado_em");
            entity.Property(e => e.Beneficiario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("beneficiario");
            entity.Property(e => e.CriadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("criado_em");
            entity.Property(e => e.DataMovimentacao).HasColumnName("data_movimentacao");
            entity.Property(e => e.DescricaoSaida)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descricao_saida");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.NumeroMovimentacao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_movimentacao");
            entity.Property(e => e.Observacoes)
                .HasColumnType("text")
                .HasColumnName("observacoes");
            entity.Property(e => e.ParceiroId).HasColumnName("parceiro_id");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.ResponsavelId).HasColumnName("responsavel_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("pendente")
                .HasColumnName("status");
            entity.Property(e => e.TipoMovimentacao)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo_movimentacao");
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_total");
            entity.Property(e => e.ValorUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_unitario");

            entity.HasOne(d => d.Item).WithMany(p => p.Movimentacoes)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_movimentacoes_itens");

            entity.HasOne(d => d.Parceiro).WithMany(p => p.Movimentacoes)
                .HasForeignKey(d => d.ParceiroId)
                .HasConstraintName("FK_movimentacoes_parceiros");

            entity.HasOne(d => d.Responsavel).WithMany(p => p.Movimentacoes)
                .HasForeignKey(d => d.ResponsavelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_movimentacoes_usuarios");
        });

        modelBuilder.Entity<Parceiro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parceiro__3213E83FB6747B48");

            entity.ToTable("parceiros");

            entity.HasIndex(e => e.CpfCnpj, "UQ__parceiro__F9F7EECF85E23B9A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValue(true)
                .HasColumnName("ativo");
            entity.Property(e => e.AtualizadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("atualizado_em");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cpf_cnpj");
            entity.Property(e => e.CriadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("criado_em");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasColumnType("text")
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3213E83FED192FB3");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164A42D995B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasDefaultValue(true)
                .HasColumnName("ativo");
            entity.Property(e => e.AtualizadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("atualizado_em");
            entity.Property(e => e.CriadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("criado_em");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Papel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("papel");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}