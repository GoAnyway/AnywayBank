using System;
using System.Threading.Tasks;
using CommonResources.DataManagerResources.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CommonDataManager.BaseUnitsOfWork
{
    public abstract class BaseUnitOfWork<TDbContext> : IUnitOfWork, IDisposable, IAsyncDisposable
        where TDbContext : DbContext
    {
        protected readonly TDbContext Context;
        protected IDbContextTransaction CurrentTransaction;

        protected BaseUnitOfWork(TDbContext context)
        {
            Context = context;
        }

        public virtual async ValueTask DisposeAsync()
        {
            if (CurrentTransaction != null) await CurrentTransaction.DisposeAsync();
            if (Context != null) await Context.DisposeAsync();
        }

        public virtual void Dispose()
        {
            CurrentTransaction?.Dispose();
            Context?.Dispose();
        }

        public virtual void BeginTransaction() =>
            CurrentTransaction = Context.Database.BeginTransaction();

        public virtual async Task BeginTransactionAsync() =>
            CurrentTransaction = await Context.Database.BeginTransactionAsync();

        public virtual int Commit()
        {
            ValidateCurrentTransaction();
            var result = Context.SaveChanges();
            CurrentTransaction.Commit();
            CurrentTransaction.Dispose();

            return result;
        }

        public virtual async Task<int> CommitAsync()
        {
            ValidateCurrentTransaction();
            var result = await Context.SaveChangesAsync();
            await CurrentTransaction.CommitAsync();
            await CurrentTransaction.DisposeAsync();

            return result;
        }

        public virtual void Rollback()
        {
            ValidateCurrentTransaction();
            CurrentTransaction.Rollback();
            CurrentTransaction.Dispose();
        }

        public virtual async Task RollbackAsync()
        {
            ValidateCurrentTransaction();
            await CurrentTransaction.RollbackAsync();
            await CurrentTransaction.DisposeAsync();
        }

        private void ValidateCurrentTransaction()
        {
            if (CurrentTransaction == null) throw new InvalidOperationException(BaseUnitOfWorkErrors.TransactionNotBegun);
        }
    }
}