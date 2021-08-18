# Kos Api
This is a library that can be used to access KOS api (https://kosapi.fit.cvut.cz/projects/kosapi/wiki). It is generic so it could be used to access any Atom XML api with the same data structure as kos api.

This repository does not contain all entities for kos api, only those needed in Christofel project. If you are using entity that is not present here, you can open PR with it. (or you could just create it in your project and load it using generic load method)

Library contains caching mechanism (using `Microsoft.Extensions.Caching`) and is supposed to be used as scoped service, but may be used as a singleton if you set up caching correctly.



# How to use

1. instance of `KosApi` class must be obtained
2. `KosApi.GetAuthorizedApi` will return `AuthorizedKosApi` class that is used to access the API with given access token.
3. Either use `AuthorizedKosApi.LoadEntityAsync` if you have already downloaded data from the api and you want to load reference of type `AtomLoadableEntity<T>` or use some of the exposed properties that represent controllers and methods inside them that load entities.

Example with dependency injection can be found in `Kos.Example` project
