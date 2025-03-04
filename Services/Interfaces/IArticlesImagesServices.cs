using BusinessObjects.DTOs.ArticleImages;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IArticlesImagesServices
    {
        public Task<ImageUploadResult> UploadImagesAsync(IFormFile file , ArticleImageCreateDTO articleImageCreateDTO , int ArticleID);
        public Task<IEnumerable<ArticleImageUpdateDTO>> GetArticleImageLists();
        public Task<ArticleImageUpdateDTO> GetArticleImageByID(int ArticleID);
        public Task<DeletionResult> DeleteImage(int ArticleID);
        public Task<IEnumerable<ArticleImageUpdateDTO>> GetAllImages();
        /*public Task<IEnumerable<ArticleImageUpdateDTO>> GetArticleImageByID(int id);*/
    }
}
