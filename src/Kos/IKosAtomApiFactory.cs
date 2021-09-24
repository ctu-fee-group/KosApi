//
//  IKosAtomApiFactory.cs
//
//  Copyright (c) Christofel authors. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Kos.Abstractions;

namespace Kos
{
    /// <summary>
    /// Factory for <see cref="IKosAtomApi"/> to create apis that have a specific access token.
    /// </summary>
    public interface IKosAtomApiFactory
    {
        /// <summary>
        /// Creates an instance of the api with the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token used by the api.</param>
        /// <returns>The created api used for loading atom entities.</returns>
        IKosAtomApi CreateApi(string accessToken);
    }
}