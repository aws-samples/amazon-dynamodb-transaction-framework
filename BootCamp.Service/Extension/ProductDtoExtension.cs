using BootCamp.DataAccess.Contract;
using BootCamp.Service.Contract;

namespace BootCamp.Service.Extension
{
    /// <summary>
    /// Extension class for model to dto object translation.
    /// </summary>
    public static class ProductDtoExtension
    {
        public static ProductDto ToProductDto(this ProductModel model)
        {
            if (model is AlbumModel albumModel)
            {
                return new AlbumDto
                {
                    TableName= albumModel.TableName,
                    ProductType = albumModel.ProductType,
                    Title = albumModel.Title,
                    Artist = albumModel.Artist
                };
            }
            else if (model is BookModel bookModel)
            {
                return new BookDto
                {
                    TableName= bookModel.TableName,
                    ProductType = bookModel.ProductType,
                    Author = bookModel.Author,
                    PublishDate = bookModel.PublishDate.ToString(),
                    Title = bookModel.Title,
                };
            }
            else if (model is MovieModel movieModel)
            {
                return new MovieDto
                {
                    TableName= movieModel.TableName,
                    ProductType = movieModel.ProductType,
                    Title = movieModel.Title,
                    Genre = movieModel.Genre,
                    Director = movieModel.Director,
                };
            }

            return null;
        }
    }
}
