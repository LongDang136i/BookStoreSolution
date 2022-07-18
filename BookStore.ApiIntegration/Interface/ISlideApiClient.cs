using BookStore.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface ISlideApiClient
    {
        Task<List<SlideVm>> GetAll();
    }
}