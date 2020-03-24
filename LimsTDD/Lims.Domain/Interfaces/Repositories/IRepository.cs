using System;
using System.Collections.Generic;
using System.Text;
using Lims.Domain.Entities;
using Lims.Domain.Interfaces;
using Lims.Domain.Services;

namespace Lims.Domain.Interfaces.Repositories
{
    public interface IRepository<Tes> where Tes : class
    {
        bool Create(Tes sample);

        bool Update(Tes sample);

        bool Delete(Tes sample);

        Tes Read(Guid id);

        IEnumerable<Tes> ReadAll();
        

    }
}
