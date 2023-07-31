using AutoMapper;
using BookStoreApi.BookOperations.CreateBooks;
using BookStoreApi.BookOperations.GetBookDetail;
using BookStoreApi.BookOperations.GetBooks;
using BookStoreApi.BookOperations.UpdateBook;
using BookStoreApi.Entities;

namespace BookStoreApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            
        }
    }
}
