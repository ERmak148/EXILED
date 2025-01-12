// -----------------------------------------------------------------------
// <copyright file="ExecutedQueryEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.RemoteAdmin
{
    using Exiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains information about executed RA query.
    /// </summary>
    public class ExecutedQueryEventArgs : IRemoteAdminEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutedQueryEventArgs"/> class.
        /// </summary>
        /// <param name="sender">Command sender instance.</param>
        /// <param name="response">Proccesed query response.</param>
        /// <param name="query">User query.</param>
        /// <param name="isservercommunication">Indicated command sended by RA panel (not user) to get some info.</param>
        public ExecutedQueryEventArgs(CommandSender sender, string response, string query, bool isservercommunication)
        {
            Sender = sender;
            Response = response;
            Query = query;
            IsServerCommunication = isservercommunication;
        }

        /// <inheritdoc/>
        public CommandSender Sender { get; }

        /// <summary>
        /// Gets the user query.
        /// </summary>
        public string Query { get; }

        /// <summary>
        /// Gets the query execution response.
        /// </summary>
        public string Response { get; }

        /// <summary>
        /// Gets a value indicating whether the player executed this command, or whether the RA panel automatically executed the command to get some information.
        /// </summary>
        public bool IsServerCommunication { get; }
    }
}