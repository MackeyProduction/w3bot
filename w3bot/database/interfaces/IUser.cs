using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Database.Interfaces
{
    /// <summary>
    /// w3bot interface for user entity.
    /// </summary>
    interface IUser
    {
        /// <summary>
        /// The unique identifier for the user.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The username from the user.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The password from the user.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// The email address from the user.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// The register date from the user.
        /// </summary>
        DateTime RegisterDate { get; set; }

        /// <summary>
        /// The group of the user.
        /// </summary>
        IGroup Group { get; set; }
    }
}
