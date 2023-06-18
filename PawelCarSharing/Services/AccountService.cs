using System.Collections.Generic;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Services
{
    public class AccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccountById(int id)
        {
            return _accountRepository.GetOne(id);
        }

        public void CreateAccount(Account account)
        {
            account.Id = _accountRepository.GetMaxId() + 1;
            _accountRepository.Add(account);
        }
    }
}
