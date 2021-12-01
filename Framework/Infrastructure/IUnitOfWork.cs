using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void Rollback();
    }
}
