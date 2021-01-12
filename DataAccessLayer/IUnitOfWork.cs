﻿using System;
using System.Threading.Tasks;
using ClubIS.DataAccessLayer.Repositories.Interfaces;

namespace ClubIS.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IEventRepository Events { get; }
        INewsRepository News { get; }
        IPaymentRepository Payments { get; }
        IAccountRepository Accounts { get; }
        IEntryRepository Entry { get; }
        IMemberFeeRepository MemberFees { get; }
        IAddressRepository Adresses { get; }
        Task<int> Save();
    }
}
