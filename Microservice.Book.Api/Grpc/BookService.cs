﻿using Grpc.Core;
using Microservice.Book.Api.Data.Repository.Interfaces;
using Microservice.Book.Api.Protos;

namespace Microservice.Book.Api.Grpc;

public class BookService : BookGrpc.BookGrpcBase
{ 
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public override async Task<ListBookResponse> GetBooks(ListBookRequest request, ServerCallContext context)
    {  
        ListBookResponse books = new ListBookResponse();

        foreach (var bookRequest in request.BookRequests)
        {
            var id = bookRequest.Id;

            var book = await _bookRepository.ByIdAsync(new Guid(id));
            if(book != null)
            {
                books.BookResponses.Add(new BookResponse() { Id = id, 
                                                             Name = book.Title,
                                                             UnitPrice = book.Price.ToString() });
            }
        }

        return books; 
    }
}