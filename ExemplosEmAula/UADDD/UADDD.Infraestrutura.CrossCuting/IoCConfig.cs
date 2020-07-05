using System;
using Autofac;
using UADDD.Aplicacao.Interfaces;
using UADDD.Aplicacao.Servicos;
using UADDD.Dominio.Interfaces.Repositorios;
using UADDD.Dominio.Interfaces.Servicos;
using UADDD.Dominio.Servicos;
using UADDD.Infraestrutura.CrossCuting.AutoMapper;
using UADDD.Infraestrutura.Persistencia.Repositorio;

namespace UADDD.Infraestrutura.CrossCuting
{
    public class IoCConfig
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AlunoServicoAplicacao>().As<IAlunoServicoAplicacao>();

            builder.RegisterType<AlunoServicoDominio>().As<IAlunoServicoDominio>();

            builder.RegisterType<AlunoRepositorio>().As<IAlunoRepositorio>();

            builder.RegisterType<MapperAluno>().As<IMapperAluno>();
        }
    }
}
