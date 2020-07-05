using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace UADDD.Infraestrutura.CrossCuting
{
    public class IoCModulo : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            IoCConfig.Load(builder);
        }
    }
}
