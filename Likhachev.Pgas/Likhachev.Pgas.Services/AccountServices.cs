using System;
using System.Collections.Generic;
using System.Text;

namespace Likhachev.Pgas.Services
{
    using Core.Abstractions;
    using Core.Accounts;
    using Data;
    using Services.Dtos;

    public class AccountServices
    {
        private static readonly AccountRepository _extendedAccountRepository = new AccountRepository();
        private static readonly IRepository<Account> _accountRepository = new EFRepository<Account>();

        public static Account GetAccount(LoginData login) => _extendedAccountRepository.GetLoginAccount(login);
        public static bool IsLoginTaken(string login) => _extendedAccountRepository.IsLoginBusy(login);
        public static Account CreateAccount(RegistrationAccountDto model) 
        {
            Account newUser = new Account {
                Login = model.Login,
                Password = model.Password,
                FirstName = model.UserName,
                SecondName = model.UserSecondName,
                FatherName = model.UserMiddleName,
                AccountTypeId = (int)model.AccountType
            };

            if (model.AccountType == AccountModelTypes.Expert) newUser.FacultyId = model.Faculty;
            if (model.AccountType == AccountModelTypes.Student) newUser.StudyGroup = model.StudyGroup;

            return _accountRepository.Create(newUser);
        }
    }
}
