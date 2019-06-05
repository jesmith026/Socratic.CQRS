# **Socratic Command Query Responsibility Segregation**
A set of libraries to facilitate the use of the CQRS pattern in .NET Core.

## **Project Status**
#### Socratic.CQRS.Abstractions
[![Build Status](https://dev.azure.com/jesmith26/SocraticProgrammer/_apis/build/status/Libraries/Socratic.CQRS.Abstractions-CI?branchName=master)](https://dev.azure.com/jesmith26/SocraticProgrammer/_build/latest?definitionId=23&branchName=master)

#### Socratic.CQRS
[![Build Status](https://dev.azure.com/jesmith26/SocraticProgrammer/_apis/build/status/jesmith026.Socratic.CQRS?branchName=dev)](https://dev.azure.com/jesmith26/SocraticProgrammer/_build/latest?definitionId=25&branchName=dev)

## **Getting Started**
### Dependencies
- Docker

To interact with the sample simply navigate to the project directory, i.e. ./Samples/ApiSample/. Then Type the command "docker-compose up". Once the command completes you can send requests to the API via the http://localhost:8080/api/students URL endpoint.

There is a Postman collection in the tests directory which demonstrates some of the calls available.

Please note that the sample API is **NOT** inteded to be an illustration of API best practices, but instead only to demonstrate simple usage of this library.

## **About**
While experimenting with different design techniques, I established a strong preference for the CQRS pattern. For a while I used the [Mediatr library](https://github.com/jbogard/MediatR) which I strongly recommend for most developers. It's a very elegant and well-crafted library to accomplish much of the same goals as this one. In fact, while our designs were extremely different at the onset of my development for this library the more I learned the closer my implementation became to Jimmy Bogard's. However, there are a few key differences which cause me to maintain my own implementation. A key difference with this library is the way handlers are resolved via reflection which allows me to make the handlers extensible via attribute decorators.

As stated previously, I strongly recommend Jimmy Bogard's library for most developers who want to implement this type of functionality in their application. However, if the differences in mine appeal to you I'm happy for any feedback.