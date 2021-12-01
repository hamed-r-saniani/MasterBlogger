using Framework.Infrastructure;

namespace MB.Infrastructure.EFCore
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly MasterBloggerContext _context;

        public UnitOfWorkEF(MasterBloggerContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
