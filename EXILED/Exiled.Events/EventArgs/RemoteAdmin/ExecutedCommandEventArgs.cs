// -----------------------------------------------------------------------
// <copyright file="ExecutedCommandEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.RemoteAdmin
{
    using Exiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains information about executed RA command.
    /// </summary>
    public class ExecutedCommandEventArgs : IRemoteAdminEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutedCommandEventArgs"/> class.
        /// </summary>
        /// <param name="sender">Command sender instance.</param>
        /// <param name="response">Command response.</param>
        /// <param name="query">User query.</param>
        public ExecutedCommandEventArgs(CommandSender sender, string response, string query)
        {
            Sender = sender;
            Response = response;
            Query = query;
        }

        /// <inheritdoc/>
        public CommandSender Sender { get; }

        /// <summary>
        /// Gets the response of executed command.
        /// </summary>
        public string Response { get; }

        /// <summary>
        /// Gets the user query.
        /// </summary>
        public string Query { get; }
    }
}