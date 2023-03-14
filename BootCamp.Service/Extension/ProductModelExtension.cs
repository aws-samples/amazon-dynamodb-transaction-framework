using BootCamp.DataAccess.Contract;
using BootCamp.Service.Contract;
using System;
using System.Reflection;

namespace BootCamp.Service.Extension
{
    /// <summary>
    /// Extension class for dto to model object translation.
    /// </summary>
    public static class ProductModelExtension
    {
        public static ProductModel ToProductModel(this ProductDto dto)
        {
            if (dto is AlbumDto albumDto)
            {
                return new AlbumModel
                {
                    TableName = albumDto.TableName,
                    ProductType = albumDto.ProductType,
                    Title = albumDto.Title,
                    Artist = albumDto.Artist
                };
            }
            else if (dto is BookDto bookDto)
            {
                return new BookModel
                {
                    TableName = bookDto.TableName,
                    ProductType = bookDto.ProductType,
                    Author = bookDto.Author,
                    PublishDate = bookDto.PublishDate.ToDateTimeOrNull(),
                    Title = bookDto.Title,
                };
            }
            else if (dto is MovieDto movieDto)
            {
                return new MovieModel
                {
                    TableName = movieDto.TableName,
                    ProductType = movieDto.ProductType,
                    Title = movieDto.Title,
                    Genre = movieDto.Genre,
                    Director = movieDto.Director,
                };
            }

            return null;
        }

        public static DateTime? ToDateTimeOrNull(this string strDate)
        {
            if (DateTime.TryParse(strDate, out var dateTime))
            {
                return dateTime;
            }
            else
            {
                return null;
            }
        }
    }

}
