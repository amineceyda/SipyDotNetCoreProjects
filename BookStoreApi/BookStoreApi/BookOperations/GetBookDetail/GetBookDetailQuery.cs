using AutoMapper;
using BookStoreApi.Common;
using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            
            BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(book); 
            /* bunları AutoMapper yapacak
            BookDetailViewModel viewModel = new BookDetailViewModel();
            viewModel.Title = book.Title;
            viewModel.PageCount = book.PageCount;
            viewModel.PublishDate = book.PublishDate.ToString("dd/MM/yyy");
            viewModel.Genre = ((GenreEnum)book.GenreId).ToString();*/
           
            return viewModel;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }
    }
}
