# SipyDotNetCoreProjects
This repository contains the homework projects and exercises completed during the Sipay .NET Core Bootcamp. The focus of this bootcamp was building web APIs using .NET Core.

## SipayFirstApi
It contains the project files of the first lesson of our API development course.

The SipayFirstApi project serves as an introductory example for building RESTful APIs. It covers the basic concepts of API setup, request handling, and response generation. (HTTP methods & CRUD (Create, Read, Update, Delete)

## FirstAssigment / First Homework
### Updating with FluentValidation
The SipayFirstAPI project has been updated to use FluentValidation for validation of the Person model. This ensures that the staff person's information is validated according to the specified rules.

### Validation Rules
The following validation rules have been implemented using FluentValidation:

Name: Required field with a minimum length of 5 characters and a maximum length of 100 characters.
Lastname: Required field with a minimum length of 5 characters and a maximum length of 100 characters.
Phone: Required field with a pattern validation for a 10-digit number.
AccessLevel: Required field that must be a value between 1 and 5 (inclusive).
Salary: Required field that must be within the allowed limit based on the staff person's access level.

## TodoApi
TodoApi project created following Microsoft's Tutorial: Create A web API with ASP.NET Core

[Link](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)

## QuoteApi (PatikaDev HW-Project)
The QuoteApi is a RESTful API that provides a collection of inspiring quotes. It allows users to retrieve quotes, add new quotes, update existing quotes, and delete quotes using standard HTTP methods. The API is built using ASP.NET Core (.NET 6) and follows RESTful principles. 

### Endpoints
The QuoteApi exposes the following endpoints:

- GET /api/quotes/list: list all quotes that sorted alphabetically based on the author's name.
- GET /api/quotes: Retrieves all quotes.
- GET /api/quotes/{id}: Retrieves a specific quote by ID.
- POST /api/quotes: Adds a new quote to the collection. (with basic validation)
- PUT /api/quotes/{id}: Updates an existing quote by ID.
- PATCH /api/quotes/{id}: Partially updates an existing quote by ID using JSON Patch.
- DELETE /api/quotes/{id}: Deletes a quote by ID.

### Data Format
The API returns quotes in the following format:

#### json
```
{
  "id": 1,
  "author": "Albert Einstein",
  "text": "Imagination is more important than knowledge."
}
```
### Example JSON Patch Document
The JSON Patch document should contain one or more operations (add, remove, replace, etc.) that specify the changes to be applied to the quote. 
Here's an example:

#### json
```
[
  { "op": "replace", "path": "/author", "value": "New Author" },
  { "op": "add", "path": "/tags", "value": ["inspirational", "motivational"] },
  { "op": "remove", "path": "/isFeatured" }
]
```
