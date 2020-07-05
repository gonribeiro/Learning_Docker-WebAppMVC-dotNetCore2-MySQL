using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UADDD.Dominio.Entidade;

namespace UADDD.Infraestrutura.Persistencia.configuracoes
{
    class AlunoConfiguracao : IEntityTypeConfiguration<Aluno>
    {
        // Customizando a tabela aluno (exemplo se necessário)
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Id);
            builder.ToTable("Alunos");
            builder.Property(a => a.DataMatricula)
                .HasColumnName("Matricula")
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetData()");
            builder.Property(a => a.DataCadastro)
                .HasColumnName("Cadastro")
                .IsRequired()
                .HasColumnType("Data")
                .HasDefaultValueSql("GetDate()");
        }
    }
}
