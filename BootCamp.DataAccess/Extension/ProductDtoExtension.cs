using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

using BootCamp.DataAccess.Contract;
using BootCamp.DataAccess.Common.AWS.DynamoDB;

namespace BootCamp.DataAccess.Extension
{
    public static class ProductDtoExtension
    {
        private static readonly Type albumDtoType = typeof(AlbumDto);
        private static readonly Type bookDtoType = typeof(BookDto);
        private static readonly Type movieDtoType = typeof(MovieDto);
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> productDtoPropertyCache = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        /// <summary>
        /// Convert to product dto list.
        /// </summary>
        /// <param name="queryResult"></param>
        /// <param name="productType"></param>
        /// <returns></returns>
        public static List<ProductDto> ToProductDtoList(this List<Dictionary<string, AttributeValue>> queryResult, string productType)
        {
            if ((queryResult is null) || (queryResult.Count <= 0))
            {
                return null;
            }

            var resultList = new List<ProductDto>();
            foreach (Dictionary<string, AttributeValue> item in queryResult)
            {
                var dto = item.ToProductDto(productType);
                resultList.Add(dto);
            }

            return resultList;
        }

        /// <summary>
        /// Converto to product dto.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="productType"></param>
        /// <returns></returns>
        public static ProductDto ToProductDto(this Dictionary<string, AttributeValue> item, string productType)
        {
            if (item is null)
            {
                return null;
            }

            if (item.ContainsKey(nameof(AlbumDto.Artist)))
            {
                var productDto = new AlbumDto();
                return productDtoPropertyCache.GetProductDto(item, albumDtoType, productDto);
            }
            else if (item.ContainsKey(nameof(BookDto.Author)))
            {
                var productDto = new BookDto();
                return productDtoPropertyCache.GetProductDto(item, bookDtoType, productDto);
            }
            else if (item.ContainsKey(nameof(MovieDto.Director)))
            {
                var productDto = new MovieDto();
                return productDtoPropertyCache.GetProductDto(item, movieDtoType, productDto);
            }
            return null;
        }

        /// <summary>
        /// Convert to delete item  request details.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Dictionary<string, AttributeValue> ToDeleteItemRequestDetail(this ProductDto dto)
        {
            var item = new Dictionary<string, AttributeValue>();
            item.AddValue(nameof(dto.Title), dto.Title);
            if (dto is BookDto bookDto)
            {
                item.AddValue(nameof(bookDto.Author), bookDto.Author.ToAttributeValue());
            }
            else if (dto is AlbumDto albumDto)
            {
                item.AddValue(nameof(albumDto.Artist), albumDto.Artist.ToAttributeValue());
            }
            else if (dto is MovieDto movieDto)
            {

                item.AddValue(nameof(movieDto.Director), movieDto.Director.ToAttributeValue());
            }
            return item;
        }


    }
}
