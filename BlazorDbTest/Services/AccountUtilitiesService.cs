using BlazorDbTest.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorDbTest.Services
{
    public class AccountUtilitiesService : IDisposable
    {
        private readonly IDbContextFactory<BttestContext> _dbContextFactory;
        public AccountUtilitiesService(IDbContextFactory<BttestContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public string? GetAccountEmail(string accountId)
        {
            string? email = "Account not found";
            

            if (!string.IsNullOrEmpty(accountId))
            {
                int? accountID = int.Parse(accountId);
                BttestContext bttestContext = _dbContextFactory.CreateDbContext();
                email = bttestContext.Accounts.FirstOrDefault(a=>a.AccountId == accountID)?.Email;
            }
            return email;
        }
        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}
