using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Helpers;
using FindBook.Core.Interfaces.Helpers;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Authentication;
using FindBook.Core.Models.Dto.Customer;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.User;
using FindBook.Core.Models.Enum;
using FindBook.Core.Models.Static;
using FindBook.Core.Services.Bases;
using FindBook.Core.Validation;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class CustomerService : BaseService<Customer, CustomerDto>, ICustomerService
    {
        private protected readonly ICustomerRepository _customerRepository;
        protected readonly IValidator<CustomerRegisterDto> _customerRegisterValidator;
        protected readonly IValidator<ChangePasswordDto> _customerChangePasswordDtoValidator;
        protected readonly ISettingService _settingService;
        protected readonly IEmailVerificationService _emailVerificationService;
        protected readonly IEmailVerificationRepository _emailVerificationRepository;

        protected readonly IEmailHelper _emailHelper;
        public CustomerService(
            ILogger<CustomerService> logger,
            IMapper mapper,
            ICustomerRepository repository,
            IValidator<CustomerDto> validator,
            IEmailHelper emailHelper,
            ISettingService settingService,
            IValidator<CustomerRegisterDto> customerRegisterValidator,
            IValidator<ChangePasswordDto> customerChangePasswordDtoValidator,
             IEmailVerificationService emailVerificationService,
             IEmailVerificationRepository emailVerificationRepository,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _customerRepository = repository;
            _customerRegisterValidator = customerRegisterValidator;
            _emailHelper = emailHelper;
            _settingService = settingService;
            _emailVerificationService = emailVerificationService;
            _emailVerificationRepository = emailVerificationRepository;
            _customerChangePasswordDtoValidator = customerChangePasswordDtoValidator;
        }

        public async Task<Response<string>> GetCustomerRegister(CustomerRegisterDto customerRegisterDto, int languageId)
        {
            Response<string> response = new Response<string>();
            ValidationResult valResult = await _customerRegisterValidator.ValidateAsync(new ValidationContext<CustomerRegisterDto>(customerRegisterDto));
            if (!valResult.IsValid)
            {
                response.IsSuccess = false;
                List<SimpleErrorDto> errors = new List<SimpleErrorDto>();
                foreach (string errorCode in valResult.Errors.Select(x => x.ErrorCode).ToList())
                {
                    response.Errors.Add(await _errorService.GetByCode(errorCode, languageId));
                }
            }
            else
            {

                var checkMail = await _customerRepository.CheckCustomerMail(customerRegisterDto);

                if (checkMail == 0)
                {

                    Customer _entity = Mapper.Map<Customer>(customerRegisterDto);
                    var result = await _customerRepository.AddAsync(_entity);

                    if (result == true)
                    {
                        var defaultSetting = await _settingService.GetDefault();

                        EmailVerificationDto verification = new EmailVerificationDto();
                        verification.IsActive = true;
                        verification.CustomerId = _entity.Id;
                        verification.Type = 0;

                        var verificationResult = await _emailVerificationService.AddAsync(verification, languageId);

                        if (verificationResult.IsSuccess)
                        {
                            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                            list.Add(new KeyValuePair<string, string>("[link]", ApplicationSetting.Url + "/Verify/" + verification.Key1 + "/" + verification.Key2 + "/" + verification.Key3));
                            list.Add(new KeyValuePair<string, string>("[logo]", ApplicationSetting.Url + defaultSetting.Data.Logo));
                            list.Add(new KeyValuePair<string, string>("[instagram]", ApplicationSetting.CdnUrl + "instagram.png"));
                            list.Add(new KeyValuePair<string, string>("[twitter]", ApplicationSetting.CdnUrl + "twitter.png"));
                            list.Add(new KeyValuePair<string, string>("[linkedin]", ApplicationSetting.CdnUrl + "linkedin.png"));
                            list.Add(new KeyValuePair<string, string>("[facebook]", ApplicationSetting.CdnUrl + "facebook.png"));
                            list.Add(new KeyValuePair<string, string>("[mailIcon]", ApplicationSetting.CdnUrl + "mailIcon.png"));
                            list.Add(new KeyValuePair<string, string>("[email]", customerRegisterDto.Email));
                            bool mailResult = await _emailHelper.SendMailWithTemplate("Üyeliğinizi Tamamlamak için Emailinizi Onaylayınız", "RegisterCustomer", customerRegisterDto.Email, list, languageId);
                            response.IsSuccess = result;
                            response.Data = customerRegisterDto.Email;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            foreach (var item in verificationResult.Errors)
                            {
                                response.Errors.Add(item);
                            }
                            customerRegisterDto.IsDeleted = true;
                            customerRegisterDto.IsActive = false;
                            await _customerRepository.UpdateAsync(Mapper.Map<Customer>(customerRegisterDto));
                        }

                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Errors.Add(await _errorService.GetByCode("5004", languageId));
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Errors.Add(await _errorService.GetByCode("5005", languageId));
                }
            }

            return response;

        }

        public async Task<Response<SimpleCustomerDto>> VerifyCustomer(int customerId, int languageId)
        {
            Response<SimpleCustomerDto> response = new Response<SimpleCustomerDto>();
            var customer = await _customerRepository.GetAsync(customerId);

            if (customer == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("5001", languageId));
            }
            else
            {
                customer.IsConfirmed = true;
                if (!await _customerRepository.UpdateAsync(customer))
                {
                    response.IsSuccess = false;
                    response.Errors.Add(await _errorService.GetByCode("5002", languageId));
                }
                else
                {
                    response.IsSuccess = true;
                    response.Data = Mapper.Map<SimpleCustomerDto>(customer);
                }
            }
            return response;
        }

        public async Task<Response<SimpleCustomerDto>> VerifyEmail(string key1, string key2, string key3, int languageId)
        {
            Response<SimpleCustomerDto> response = new Response<SimpleCustomerDto>();

            var data = await _emailVerificationRepository.GetByKeys(key1, key2, key3, EmailType.Verification);

            if (data == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("5003", languageId));
            }
            else
            {

                data.IsActive = false;
                await _emailVerificationRepository.UpdateAsync(data);
                var customerResult = await VerifyCustomer(data.CustomerId, languageId);
                if (customerResult.IsSuccess)
                {
                    response.Data = customerResult.Data;
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                    foreach (var item in customerResult.Errors)
                    {
                        response.Errors.Add(item);
                    }
                }

            }

            return response;
        }

        public async Task<Response<SimpleCustomerDto>> GetCustomerLogin(LoginDto loginDto, int languageId)
        {
            Response<SimpleCustomerDto> response = new Response<SimpleCustomerDto>();

            var data = await _customerRepository.GetForLogin(loginDto);

            if (data == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("5006", languageId));
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<SimpleCustomerDto>(data);
            }

            return response;
        }

        public async Task<Response<List<CustomerDto>>> SearchCustomer(SearchCustomerDto searchCustomerDto, int languageId)
        {
            Response<List<CustomerDto>> response = new Response<List<CustomerDto>>();

            var data = await _customerRepository.SearchCustomers(searchCustomerDto);

            if (data == null)
            {
                response.IsSuccess = true;
                response.Errors.Add(await _errorService.GetByCode("5006", languageId));
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<CustomerDto>>(data);
            }

            return response;
        }

        public async Task<Response<bool>> SendForgetPasswordMail(ForgetPasswordDto customerEmail, int languageId)
        {
            Response<bool> response = new Response<bool>();

            var checkCustomer = await _customerRepository.SendForgetPasswordMail(customerEmail);

            if (checkCustomer != null)
            {
                var defaultSetting = await _settingService.GetDefault();


                response.IsSuccess = true;
                response.Data = true;

                EmailVerificationDto emailVerification = new EmailVerificationDto();
                emailVerification.IsActive = true;
                emailVerification.CustomerId = checkCustomer.Id;
                emailVerification.Type = (EmailType)1;


                var verificationResult = await _emailVerificationService.AddAsync(emailVerification, languageId);

                if (verificationResult.IsSuccess)
                {
                    List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                    list.Add(new KeyValuePair<string, string>("[link]", ApplicationSetting.Url + "/ChangePassword/" + emailVerification.Key1 + "/" + emailVerification.Key2 + "/" + emailVerification.Key3));
                    list.Add(new KeyValuePair<string, string>("[logo]", ApplicationSetting.Url + defaultSetting.Data.Logo));
                    list.Add(new KeyValuePair<string, string>("[user]", checkCustomer.FirstName + " " + checkCustomer.LastName));
                    list.Add(new KeyValuePair<string, string>("[instagram]", ApplicationSetting.CdnUrl + "instagram.png"));
                    list.Add(new KeyValuePair<string, string>("[twitter]", ApplicationSetting.CdnUrl + "twitter.png"));
                    list.Add(new KeyValuePair<string, string>("[linkedin]", ApplicationSetting.CdnUrl + "linkedin.png"));
                    list.Add(new KeyValuePair<string, string>("[facebook]", ApplicationSetting.CdnUrl + "facebook.png"));
                    list.Add(new KeyValuePair<string, string>("[mailIcon]", ApplicationSetting.CdnUrl + "mail.png"));
                    list.Add(new KeyValuePair<string, string>("[email]", checkCustomer.Email));
                    bool mailResult = await _emailHelper.SendMailWithTemplate("Şifrenizi Yenilemek İçin Tıklayınız", "ForgetPassword", checkCustomer.Email, list, languageId);
                    response.IsSuccess = true;
                    response.Data = true;
                }
                else
                {
                    response.IsSuccess = false;
                    foreach (var item in verificationResult.Errors)
                    {
                        response.Errors.Add(item);
                    }
                }

            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("", languageId));
            }

            return response;
        }

        public async Task<Response<bool>> UpdatePassword(int customerId, ChangePasswordDto changePasswordDto, int languageId, bool currentPasswordRequire = false)
        {
            Response<bool> response = new Response<bool>();



            ValidationResult valResult = await _customerChangePasswordDtoValidator.ValidateAsync(new ValidationContext<ChangePasswordDto>(changePasswordDto));
            var data = await _customerRepository.GetAsync(customerId);



            if (!valResult.IsValid)
            {
                response.IsSuccess = false;
                List<SimpleErrorDto> errors = new List<SimpleErrorDto>();
                foreach (string errorCode in valResult.Errors.Select(x => x.ErrorCode).ToList())
                {
                    response.Errors.Add(await _errorService.GetByCode(errorCode, languageId));
                }
            }
            else
            {

                if (currentPasswordRequire)
                {
                    var checkPassword = await _customerRepository.CheckCurrentPassword(data.Id, changePasswordDto.CurrentPassword);
                    if (checkPassword)
                    {
                        //yeni şifreler eşleşmesi
                        if (changePasswordDto.ValidPassword)
                        {
                            data.Password = changePasswordDto.Password;
                            await _customerRepository.UpdateAsync(data);
                            response.IsSuccess = true;
                            response.Data = true;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Errors.Add(await _errorService.GetByCode("3012", languageId));
                        }

                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Errors.Add(await _errorService.GetByCode("3013", languageId)); // sistemdeki şifre ile eşleşmiyor
                    }
                }
                else
                {
                    data.Password = changePasswordDto.Password;
                    await _customerRepository.UpdateAsync(data);
                    response.IsSuccess = true;
                    response.Data = true;
                }



            }
            return response;
        }

        public async Task<Response<string>> SendReturnStatusMail(int customerId, int mailType, int languageId)
        {

            var customer = await _customerRepository.GetAsync(customerId);

            Response<string> response = new Response<string>();

            var defaultSetting = await _settingService.GetDefault();


            if (mailType == 1)
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

                list.Add(new KeyValuePair<string, string>("[email]", customer.Email));

                bool mailResult = await _emailHelper.SendMailWithTemplate("Ürün Iade Talebiniz başarıyla Onaylandı", "RegisterCustomer", customer.Email, list, languageId);
                response.IsSuccess = mailResult;
                response.Data = customer.Email;

            }
            else
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

                list.Add(new KeyValuePair<string, string>("[email]", customer.Email));

                bool mailResult = await _emailHelper.SendMailWithTemplate("Ürününüz İade Şartlarını sağlamadığı için kabul edilemedi", "RegisterCustomer", customer.Email, list, languageId);

                response.IsSuccess = mailResult;
                response.Data = customer.Email;
            }





            return response;
        }

        public async Task<Response<List<CustomerDto>>> GetAllVerifedCustomer(int languageId)
        {
            Response<List<CustomerDto>> response = new Response<List<CustomerDto>>();

            var data = await _customerRepository.GetAllVerifedCustomer();

            if (data != null){
                response.Data = Mapper.Map<List<CustomerDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess =false;
                response.Errors.Add(await _errorService.GetByCode("" , languageId));
            }

            return response;
        }
    }
}
// list.Add(new KeyValuePair<string, string>("[logo]", ApplicationSetting.Url + defaultSetting.Data.Logo));
// list.Add(new KeyValuePair<string, string>("[instagram]", ApplicationSetting.CdnUrl + "instagram.png"));
// list.Add(new KeyValuePair<string, string>("[twitter]", ApplicationSetting.CdnUrl + "twitter.png"));
// list.Add(new KeyValuePair<string, string>("[linkedin]", ApplicationSetting.CdnUrl + "linkedin.png"));
// list.Add(new KeyValuePair<string, string>("[facebook]", ApplicationSetting.CdnUrl + "facebook.png"));
// list.Add(new KeyValuePair<string, string>("[mailIcon]", ApplicationSetting.CdnUrl + "mailIcon.png"));

