using AutoMapper;
using BusinessObjects.DTOs.Articles;
using BusinessObjects.Entities;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArticleCreateDTO> CreateNewsArtiles(ArticleCreateDTO newsArticleDTO)
        {
            try
            {
                var mapping = _mapper.Map<Article>(newsArticleDTO);
                {
                    await _unitOfWork._articleRepository.AddAsync(mapping);
                    var isSuccess = await _unitOfWork.SaveChangesAsync() > 0;
                    if (isSuccess)
                    {
                        var mappingResult = _mapper.Map<ArticleCreateDTO>(mapping);
                        return mappingResult;
                    }
                    else
                    {
                        return new ArticleCreateDTO();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteNewsArticles(int id)
        {
            try
            {
                var getArticleID = await _unitOfWork._articleRepository.GetByIdAsync(id);
                if (getArticleID != null)
                {
                    if (getArticleID.IsDeleted = true )
                    {
                        getArticleID.IsDeleted = false;
                    }
                    else
                    {
                        getArticleID.IsDeleted = true;
                    }
                    _unitOfWork._articleRepository.Update(getArticleID);
                    var IsSuccess = await _unitOfWork.SaveChangesAsync()>0;
                    if (IsSuccess)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ArticleReadDTO>> GetAllNewsArticles()
        {
            try
            {
                var result = await _unitOfWork._articleRepository.GetAllAsync();
                if (result != null)
                {
                    return _mapper.Map<IEnumerable<ArticleReadDTO>>(result);
                }
                else
                {
                    return new List<ArticleReadDTO>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<ArticleReadDTO> GetNewsArticleByID(int id)
        {
            try
            {
                var result = await _unitOfWork._articleRepository.GetByIdAsync(id);
                if (result != null)
                {
                    return _mapper.Map<ArticleReadDTO>(result);
                }
                else
                {
                    return new ArticleReadDTO();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ArticleUpdateDTO> UpdateNewsArticleByID(ArticleUpdateDTO newsArticleDTO,int id)
        {
            try
            {
                var result = await _unitOfWork._articleRepository.GetByIdAsync(id);
                if(result != null)
                {
                    var mapping = _mapper.Map(newsArticleDTO, result);
                    _unitOfWork._articleRepository.Update(mapping);
                    var isSuccess = await _unitOfWork.SaveChangesAsync() > 0;
                    if (isSuccess)
                    {
                        return _mapper.Map<ArticleUpdateDTO>(mapping);
                    }
                    else
                    {
                        return new ArticleUpdateDTO();
                    }
                }
                else
                {
                    return new ArticleUpdateDTO();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
