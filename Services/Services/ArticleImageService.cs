using BusinessObjects.DTOs.ArticleImages;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ArticleImageService : IArticlesImagesServices
    {
        public Task<DeletionResult> DeleteImage(int ArticleID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleImageUpdateDTO>> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleImageUpdateDTO> GetArticleImageByID(int ArticleID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleImageUpdateDTO>> GetArticleImageLists()
        {
            throw new NotImplementedException();
        }

        public Task<ImageUploadResult> UploadImagesAsync(IFormFile file, ArticleImageCreateDTO articleImageCreateDTO, int ArticleID)
        {
            throw new NotImplementedException();
        }
    }
}
