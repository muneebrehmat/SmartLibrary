using Microsoft.EntityFrameworkCore;
using SmartLibrary.Data;
using SmartLibrary.DTOs.Books;
using SmartLibrary.Models;
using SmartLibrary.Repositories.Interfaces;

namespace SmartLibrary.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BookResponseDto> createBooksAsync(CreateBookDto createBookDto)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Name == createBookDto.AuthorName);
            if(author==null)
            {
                throw new Exception("Author does not exist!!!");
            }
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == createBookDto.CategoryName);
            if(category==null)
            {
                throw new Exception("Category does not exist!!!");
            }
            var book = new Book
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                TotalCopies = createBookDto.TotalCopies,
                AvailableCopies = createBookDto.AvailableCopies,
                AuthorId = author.Id,
                CategoryId = category.Id                
            };
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                Author = book.Author.Name, 
                Category= book.Category.Name
            };

        }

        public async Task<List<BookResponseDto>> GetAllBooksAsync()
        {
            var books = await _dbContext.Books.Where(b => b.AvailableCopies > 0)
                .Select(b => new BookResponseDto
                {
                    Id = b.Id,
                    ISBN = b.ISBN,
                    Title = b.Title,
                    Author = b.Author.Name,
                    Category = b.Category.Name

                }).ToListAsync();

            return books;
        }

        public async Task<BookResponseDto> GetBookById(int bookId)
        {
            var book = await _dbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new KeyNotFoundException("Book Not Found");
            }

            return new BookResponseDto
            {
                Id = book.Id,
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author?.Name,
                Category = book.Category?.Name
               
            };
        }

        public async Task<string> UpdateBookAsync(int BookId,UpdateBookDto updateBookDto)
        {
           var book = await _dbContext.Books.FirstOrDefaultAsync(b=>b.Id== BookId);
            if (book == null)
            {
                throw new Exception("Book Not Found!!!");
            }
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == updateBookDto.CategoryName);
            if (category == null)
            {
                throw new Exception("Category does not exist!!!");
            }
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Name == updateBookDto.AuthorName);
            if(author == null)
            {
                throw new Exception("Author does not Exist!!!");
            }
            book.Title = updateBookDto.Title;
            book.ISBN = updateBookDto.ISBN;
            book.TotalCopies = updateBookDto.TotalCopies;
            book.AvailableCopies=updateBookDto.AvailableCopies;
            book.AuthorId = author.Id;
            book.CategoryId = category.Id;
            
            await _dbContext.SaveChangesAsync();
            return "Book updated successfully.";
        }
    }
}
