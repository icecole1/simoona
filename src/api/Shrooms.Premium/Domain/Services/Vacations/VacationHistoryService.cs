﻿using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Shrooms.Contracts.DAL;
using Shrooms.DataLayer.EntityModels.Models;
using Shrooms.Premium.DataTransferObjects.Models.Vacations;
using Shrooms.Premium.Infrastructure.VacationBot;

namespace Shrooms.Premium.Domain.Services.Vacations
{
    public class VacationHistoryService : IVacationHistoryService
    {
        private readonly IDbSet<ApplicationUser> _usersDbSet;
        private readonly IVacationBotService _vacationBotService;

        public VacationHistoryService(IUnitOfWork2 uow, IVacationBotService vacationBotService)
        {
            _vacationBotService = vacationBotService;
            _usersDbSet = uow.GetDbSet<ApplicationUser>();
        }

        public async Task<VacationDto[]> GetVacationHistoryAsync(string userId)
        {
            var user = await _usersDbSet.SingleAsync(u => u.Id == userId);

            var vacationsInfo = await _vacationBotService.GetVacationHistory(user.Email);
            return vacationsInfo.Select(MapVacationInfoToDto).ToArray();
        }

        private static VacationDto MapVacationInfoToDto(VacationInfo vacationInfo)
        {
            return new VacationDto
            {
                DateFrom = vacationInfo.DateFrom,
                DateTo = vacationInfo.DateTo
            };
        }
    }
}