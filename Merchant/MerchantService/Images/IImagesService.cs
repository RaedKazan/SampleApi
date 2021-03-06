﻿using MerchantData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MerchantService.Images
{
    public interface IImagesService
    {
        Task<Image> GetImage(int id);

        Task<int> PostImage(Image image);

        Task<IEnumerable<Image>> GetproductImages(int productId);

        Task<bool> PutImage(int id, Image image);

        Task<bool> DeleteImage(int id);
    }
}
