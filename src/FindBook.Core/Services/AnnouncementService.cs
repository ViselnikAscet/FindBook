using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Announcement;
using FindBook.Core.Models.Enum;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class AnnouncementService : BaseService<Announcement, AnnouncementDto>, IAnnouncementService
    {
        private protected readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(
            ILogger<AnnouncementService> logger,
            IMapper mapper,
            IAnnouncementRepository repository,
            IValidator<AnnouncementDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _announcementRepository = repository;
        }

        public async Task<Response<List<AnnouncementDto>>> GetAllAnnouncement(int languageId)
        {
            Response<List<AnnouncementDto>> response = new Response<List<AnnouncementDto>>();

            var data = await _announcementRepository.GetAllAnnouncement();

            if (data != null)
            {
                response.Data = Mapper.Map<List<AnnouncementDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8003", languageId));
            }

            return response;
        }

        public async Task<Response<AnnouncementDto>> GetAnnouncementWithId(int announcementId, int languageId)
        {
            Response<AnnouncementDto> response = new Response<AnnouncementDto>();

            var data = await _announcementRepository.GetAnnouncementWithId(announcementId);

            if (data != null)
            {
                response.Data = Mapper.Map<AnnouncementDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8003", languageId));
            }

            return response;
        }

        public async Task<Response<List<AnnouncementDto>>> GetAnnouncementWithType(AnnouncementType type, int languageId)
        {
            Response<List<AnnouncementDto>> response = new Response<List<AnnouncementDto>>();
            var data = await _announcementRepository.GetAnnouncementWithType(type);

            if (data != null)
            {
                response.Data = Mapper.Map<List<AnnouncementDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8003", languageId));
            }

            return response;
        }
    }


}