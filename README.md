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
