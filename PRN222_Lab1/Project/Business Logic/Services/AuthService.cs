using Business_Logic.Interfaces;
using Data.Interface;
using Data.Repositories;
using Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUOW _unitOfWork;

        public AuthService(IUOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StoreAccount> AuthenticateAsync(string email, string password)
        {
            var accountRepo = _unitOfWork.GetRepository<StoreAccount>();

            var account = await accountRepo.Entities
                .Where(a => a.EmailAddress == email && a.StoreAccountPassword == password)
                .FirstOrDefaultAsync();

            var accounts = await accountRepo.GetAllAsync();
            if (account != null && (account.Role == 2 || account.Role == 3))
            {
                return account;
            }
            return null;
        }
    }

}

