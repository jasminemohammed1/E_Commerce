using AutoMapper;
using E_commerce.Application.DTOs.Products;
using E_Commerce.Domain.Entities.Products;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Profiles
{
    internal class PictureUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly UrlSettings _settings;
        public PictureUrlResolver(IOptions<UrlSettings> options)
        {
            _settings = options.Value;
            
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            // src = imgages/products/....
            //des localhost/Files/src

            var baseurl = _settings.baseurl.TrimEnd('/');
            var imageSrcPath = source.PictureUrl.TrimStart('/');
            return $"{baseurl}/Files/{imageSrcPath}";

        }
    }
    public class UrlSettings
    {
        public string baseurl {  get; set; }
    }
}
