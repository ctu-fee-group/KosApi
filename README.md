# WARNING

This library is WIP. It supports only minority of the operations (loading atom entries, without filters), the API of the library may change at any moment.

# Kos Api
This is a library that can be used to access KOS api (https://kosapi.fit.cvut.cz/projects/kosapi/wiki). It is generic so it could be used to access any Atom XML api with the same data structure as kos api.

This repository does not contain all entities for kos api, only those needed in Christofel project. If you are using entity that is not present here, you can open PR with it. (or you could just create it in your project and load it using generic load method)

Library contains caching mechanism (using `Microsoft.Extensions.Caching`) and is supposed to be used as scoped service, but may be used as a singleton if you set up caching correctly.

# How to use

Example with dependency injection can be found in `Kos.Example` project
