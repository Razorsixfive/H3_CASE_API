using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.EventSourcedNormalizers;
using Application.ViewModels;
using FluentValidation.Results;

namespace Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(Guid id);
        
        Task<ValidationResult> Register(CustomerViewModel customerViewModel);
        Task<ValidationResult> Update(CustomerViewModel customerViewModel);
        Task<ValidationResult> Remove(Guid id);

        Task<IList<CustomerHistoryData>> GetAllHistory(Guid id);
    }
}
