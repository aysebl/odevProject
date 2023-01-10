using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Odev.Business.Interfcae;
using Odev.Business.Base;
using Odev.Business.Model;
using Odev.Core.Responses;
using Odev.DAL.Interface;
using Odev.Entities.Model;

namespace Odev.Business.Services
{
    public class ProductService : BaseService<ProductService>, IProductService
    {
        private readonly IMongoRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMongoRepository<Product> productRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public ServiceResponse<ProductModel> CreateProduct(ProductModel model)
        {
            var res = new ServiceResponse<ProductModel> { };

            var product = _mapper.Map<Product>(model);
            product.Id = null;

            var resProduct = _productRepository.InsertOne(product);

            if (!resProduct.Successed)
            {
                res.Successed = false;
                res.Code = StatusCodes.Status500InternalServerError;
                res.Message = "Beklenmeyen bir hata oluştu, lütfen daha sonra yeniden deneyiniz.";
                res.Errors = resProduct.Message;

                return res;
            }


            Expression<Func<Product, bool>> filterPredicate = PredicateBuilder.New<Product>(true);
            filterPredicate = filterPredicate.And(x => x.Id == product.Id);

            AggregateUnwindOptions<ProductLookedUp> unwindOptions = new AggregateUnwindOptions<ProductLookedUp>() { PreserveNullAndEmptyArrays = true };

            var lookedUp = _productRepository.Aggregate()
                .Match(filterPredicate)
                .Lookup<Product, ProductLookedUp>("categories", "CategoryId", "Id", "Category")
                .Unwind(x => x.Category, unwindOptions)
                .As<ProductLookedUp>()
                .FirstOrDefault();

            res.Result = _mapper.Map<ProductModel>(lookedUp);


            return res;
        }

        public ServiceResponse<ProductModel> CreateProducts(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<ProductViewModel>> GetProducts()
        {
            var res = new ServiceResponse<List<ProductViewModel>> { };

            AggregateUnwindOptions<ProductLookedUp> unwindOptions = new AggregateUnwindOptions<ProductLookedUp>() { PreserveNullAndEmptyArrays = true };

            var lookedUp = _productRepository.Aggregate()
                .Lookup<Product, ProductLookedUp>("categories", "CategoryId", "Id", "Category")
                .Unwind(x => x.Category, unwindOptions)
                .As<ProductLookedUp>()
                .ToList();

            res.Result = _mapper.Map<List<ProductViewModel>>(lookedUp);

            return res;
        }

        ServiceResponse<List<ProductViewModel>> IProductService.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
