using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Interfaces.Services;
using AracaParca.Core.Services;
using FindBook.Infrastructure.EF.MySql.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FindBook.Infrastructure.EF.MySql.Data.IoC
{

    public static class RepositoryConfiguration
    {

        public static IServiceCollection RegisterEfMysqlRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IOemRepository, OemRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();

            services.AddTransient<ISeoInfoRepository, SeoInfoRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IVehicleBrandRepository, VehicleBrandRepository>();
            services.AddTransient<IVehicleEngineCodeRepository, VehicleEngineCodeRepository>();
            services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
            services.AddTransient<IVehicleYearRepository, VehicleYearRepository>();

            services.AddTransient<ILanguageBasedInfoRepository, LanguageBasedInfoRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IProductPriceRepository, ProductPriceRepository>();
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IProductQuantityRepository, ProductQuantityRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();

            services.AddTransient<IFavoriteProductRepository, FavoriteProductRepository>();
            services.AddTransient<ICustomerCarRepository, CustomerCarRepository>();

            services.AddTransient<IShipmentCompanyRepository, ShipmentCompanyRepository>();
            services.AddTransient<IShipmentCompanyParameterRepository, ShipmentCompanyParameterRepository>();
            services.AddTransient<IShipmentMethodRepository, ShipmentMethodRepository>();
            services.AddTransient<IShipmentMethodValueRepository, ShipmentMethodValueRepository>();

            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddTransient<IVirtualPosRepository, VirtualPosRepository>();
            services.AddTransient<IVirtualPosParameterRepository, VirtualPosParameterRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            services.AddTransient<IErrorRepository, ErrorRepository>();

            services.AddTransient<IResourceRepository, ResourceRepository>();

            services.AddTransient<IPermRepository, PermRepository>();
            services.AddTransient<IPermGroupRepository, PermGroupRepository>();
            services.AddTransient<IPermGroupPermRepository, PermGroupPermRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientSessionRepository, ClientSessionRepository>();
            services.AddTransient<ISettingRepository, SettingRepository>();
            services.AddTransient<IEmailSettingRepository, EmailSettingRepository>();
            services.AddTransient<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddTransient<IEmailVerificationRepository, EmailVerificationRepository>();
            services.AddTransient<IBasketHeaderRepository, BasketHeaderRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<IAnnouncementRepository, AnnouncementRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IMenuSectionRepository, MenuSectionRepository>();
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddTransient<ICampaignDetailRepository, CampaignDetailRepository>();









            return services;
        }

    }


}