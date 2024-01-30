using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.VirtualPosParameter;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class VirtualPosParameterService : BaseService<VirtualPosParameter, VirtualPosParameterDto>, IVirtualPosParameterService
    {
        private protected readonly IVirtualPosParameterRepository _virtualPosParameterRepository;
        private readonly IVirtualPosRepository _virtualPosRepository;

        public VirtualPosParameterService(
            ILogger<VirtualPosParameterService> logger,
            IMapper mapper,
            IVirtualPosParameterRepository repository,
            IValidator<VirtualPosParameterDto> validator,
            IVirtualPosRepository virtualPosRepository,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _virtualPosParameterRepository = repository;
            _virtualPosRepository = virtualPosRepository;
        }

        public async Task<Response<bool>> AddVirtualPosParameter(VirtualPosParameterDto virtualPosParameterDto, int languageId)
        {
            Response<bool> response = new Response<bool>();



            var virtualpos = await _virtualPosRepository.GetIdWithVPosEntegreId(virtualPosParameterDto.VirtualPosId);

            if (virtualpos != null)
            {
                var check = await _virtualPosParameterRepository.CheckParameters(virtualpos.Id, virtualPosParameterDto.PropertyName);

                if (check != null) // burda key value müz  var 
                {
                    check.Value = virtualPosParameterDto.Value;
                    var data = await UpdateAsync(Mapper.Map<VirtualPosParameterDto>(check), languageId);
                    if (data.IsSuccess != false)
                    {
                        response.Data = true;
                        response.IsSuccess = true;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Errors.Add(await _errorService.GetByCode("8002", languageId));
                    }
                    return response;
                }
                else
                {
                    virtualPosParameterDto.VirtualPosId = virtualpos.Id;
                    var data = await AddAsync(virtualPosParameterDto, languageId);
                    if (data.IsSuccess != false)
                    {
                        response.Data = true;
                        response.IsSuccess = true;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Errors.Add(await _errorService.GetByCode("8002", languageId));
                    }
                }

            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8002", languageId));
            }



            return response;



        }

        public async Task<Response<List<VirtualPosParameterDto>>> GetVirtualPosParameterValue(int virtualposId, int languageId)
        {
            Response<List<VirtualPosParameterDto>> response = new Response<List<VirtualPosParameterDto>>();


            var virtualpos = await _virtualPosRepository.GetIdWithVPosEntegreId(virtualposId);

            if (virtualpos != null)
            {
                var data = await _virtualPosParameterRepository.GetVirtualPosParameterValue(virtualpos.Id);

                if (data != null)
                {
                    response.IsSuccess = true;
                    response.Data = Mapper.Map<List<VirtualPosParameterDto>>(data);
                }
                else
                {
                    response.IsSuccess = false;
                    response.Errors.Add(await _errorService.GetByCode("8002", languageId));
                }
            }
            else
            {
                var item = new VirtualPos();
                item.VPosEntegreId = virtualposId;
                item.PaymentMethodId = 1;
                var addData = await _virtualPosRepository.AddAsync(item);

                if (addData != false)
                {
                    var addedData = await _virtualPosRepository.GetIdWithVPosEntegreId(virtualposId);
                    var data = await _virtualPosParameterRepository.GetVirtualPosParameterValue(addedData.Id);

                    if (data != null)
                    {
                        response.IsSuccess = true;
                        response.Data = Mapper.Map<List<VirtualPosParameterDto>>(data);
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Errors.Add(await _errorService.GetByCode("8002", languageId));
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Errors.Add(await _errorService.GetByCode("8002", languageId));
                }
            }




            return response;
        }
    }


}