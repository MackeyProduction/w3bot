﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3bot.Core.Utilities;

namespace w3bot.Core.Database.Repository
{
    /// <summary>
    /// w3bot interface for repositories.
    /// </summary>
    public interface IRepository : IValidator
    {
        /// <summary>
        /// Fetches a dictionary by id.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>Returns an dictionary.</returns>
        T FetchById<T>(int id);

        /// <summary>
        /// Fetch all entries as list.
        /// </summary>
        /// <returns>Returns a list with all entries.</returns>
        IList<T> FetchAll<T>();
    }
}
