using Microsoft.AspNetCore.Identity;
using SmartLibrary.Data;
using SmartLibrary.DTOs.Auth;
using SmartLibrary.DTOs.Authorr;
using SmartLibrary.Models;
using SmartLibrary.Repositories.Interfaces;

namespace SmartLibrary.Repositories.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<AuthorResponseDto> createAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var Author = new Author
            {
                Name = createAuthorDto.Name,
                Biography = createAuthorDto.Biography
            };
            _dbContext.Authors.Add(Author);
            await _dbContext.SaveChangesAsync();
            return new AuthorResponseDto
            {
                Name = Author.Name,
                Biography = Author.Biography
            };
        }
    }
}
