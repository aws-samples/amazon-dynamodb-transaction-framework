
using System;

namespace BootCamp.DataAccess.Contract
{
    /// <summary>
    /// Class for product
    /// </summary>
    public class AlbumDto : ProductDto
    {
        /// <summary>
        /// Album artist.
        /// </summary>
        public string Artist { get; set; }

    }
}
