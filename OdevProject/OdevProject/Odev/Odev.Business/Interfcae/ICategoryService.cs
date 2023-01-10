using Odev.Business.Model;
using Odev.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev.Business.Interfcae
{
    public interface ICategoryService
    {
        ServiceResponse<CategoryModel> CreateCategory(CategoryModel model);

        ServiceResponse<CategoryModel> RemoveCategory(string id);

        ServiceResponse<CategoryModel> UpdateCategories(CategoryModel model);

        ServiceResponse<List<CategoryModel>> GetCategories();
    }
}
