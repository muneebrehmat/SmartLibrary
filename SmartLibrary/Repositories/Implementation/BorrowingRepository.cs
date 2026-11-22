using Microsoft.EntityFrameworkCore;
using SmartLibrary.Data;
using SmartLibrary.DTOs.Borrowings;
using SmartLibrary.Models;
using SmartLibrary.Repositories.Interfaces;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Repositories.Implementation
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ApplicationDbContext _dbContext;

        public BorrowingRepository(ICurrentUserService currentUserService, ApplicationDbContext dbContext)
        {
            _currentUserService = currentUserService;
            _dbContext = dbContext;
        }
        public async Task<BorrowResponseDto> BorrowBookAsync(BorrowBookDto borrowBookDto)
        {
            var userId = _currentUserService.UserId;
            var MemberName = _currentUserService.FullName;
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Title == borrowBookDto.BookTitle);
            if (book == null)
            {
                throw new Exception("This book does not exist!!!");
            }
            if (book.Status != "Available")
            {
                throw new Exception("This book is currently not available!");
            }
            var alreadyBorrowed = await _dbContext.Borrowings.AnyAsync
                (b => b.UserId == userId && b.BookId == book.Id && b.ReturnDate == null);
            if (alreadyBorrowed)
            {
                throw new Exception("You have already borrowed this book!");

            }
            book.AvailableCopies--;
            if (book.AvailableCopies == 0)
            {
                book.Status = "Not Available";
            }

            var Borrowbook = new Borrowing
            {
                BookId = book.Id,
                UserId = userId,
                BorrowDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(7)
            };
            _dbContext.Borrowings.Add(Borrowbook);
            await _dbContext.SaveChangesAsync();
            return new BorrowResponseDto
            {
                BookTitle = borrowBookDto.BookTitle,
                MemberName = MemberName,
                DueDate = Borrowbook.DueDate
            };
        }

        public async Task<List<BorrowResponseDto>> GetAllBorrowedAsync()
        {
            var allBorrowed = await _dbContext.Borrowings
                .Include(b => b.User)
                .Include(b => b.Book)
                .Select(b => new BorrowResponseDto
                {
                    BookTitle = b.Book.Title,
                    MemberName = b.User.FullName,
                    PhoneNumber = b.User.PhoneNumber,
                    BorrowDate = b.BorrowDate,
                    DueDate = b.DueDate
                })
                .ToListAsync();

            return allBorrowed;
        }
    

    public async Task<ReturnResponseDto> ReturnBookAsync(ReturnBookDto returnBookDto)
        {
            var userId = _currentUserService.UserId;
            var memberName = _currentUserService.FullName;

            // Find the book
            var book = await _dbContext.Books
                .FirstOrDefaultAsync(b => b.Title == returnBookDto.BookTitle);

            if (book == null)
            {
                throw new Exception("This book does not exist!");
            }

            // Find the active borrowing record
            var borrowing = await _dbContext.Borrowings
                .FirstOrDefaultAsync(b =>
                    b.BookId == book.Id &&
                    b.UserId == userId &&
                    b.ReturnDate == null);

            if (borrowing == null)
            {
                throw new Exception("You have not borrowed this book!");
            }

            // Update return date
            borrowing.ReturnDate = DateTime.UtcNow;

            // Increase available copies
            book.AvailableCopies++;

            // Update book status
            book.Status = "Available";

            await _dbContext.SaveChangesAsync();

            return new ReturnResponseDto
            {
                BookTitle = book.Title,
                MemberName = memberName,
                ReturnDate = borrowing.ReturnDate.Value,
                Message = "Book returned successfully!"
            };
        }
    }
}
