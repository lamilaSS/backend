using System;
using System.Threading.Tasks;
using mcq_backend.Helper.Context;

namespace mcq_backend.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        private bool disposed = false;

        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveAsync()
        {
            var resp = await _context.SaveChangesAsync();
            return resp;
        }
    }
}