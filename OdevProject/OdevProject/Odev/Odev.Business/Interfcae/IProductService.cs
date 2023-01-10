using Odev.Business.Model;
using Odev.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev.Business.Interfcae
{
    public interface IProductService
    {
        ServiceResponse<ProductModel> CreateProduct(ProductModel model);

        ServiceResponse<List<ProductViewModel>> GetProducts();
    }
}
