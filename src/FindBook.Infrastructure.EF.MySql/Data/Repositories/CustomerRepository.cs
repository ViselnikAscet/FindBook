using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Authentication;
using AracaParca.Core.Models.Dto.Customer;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(AracaParcaContext context, ILogger<CustomerRepository> logger) : base(context, logger)
        {

        }

        public async Task<int> CheckCustomerMail(CustomerRegisterDto registerDto)
        {
            return await Table.Where(x=>x.Email == registerDto.Email && x.IsActive).CountAsync();
        }

        public async Task<List<Customer>> SearchCustomers(SearchCustomerDto customerDto)
        {
          return await Table.Where(x => ((customerDto.SearchText!=string.Empty ? x.FirstName.Contains(customerDto.SearchText) : false ) || x.Email == customerDto.Email)).ToListAsync();
        }

        public async Task<Customer> GetForLogin(LoginDto login)
        {
            return await Table.Where(x => x.Email == login.Email && x.Password == login.Password && x.IsActive).FirstOrDefaultAsync();
        }

        public async Task<Customer> SendForgetPasswordMail(ForgetPasswordDto customer)
        {
            return await Table.Where(x=>x.IsActive && x.Email == customer.Email).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckCurrentPassword(int customerId, string password)
        {
            return (await Table.Where(x=>x.Id == customerId && x.Password == password).CountAsync())>0;
        }

        public async Task<List<Customer>> GetAllVerifedCustomer()
        {
            return await Table.Where(x=>x.IsActive && x.IsConfirmed).ToListAsync();
        }
    }
}