// -----------------------------------------------------------------------
// <copyright file="ExecutingQueryEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.RemoteAdmin
{
    using Exiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains information about executing RA query.
    /// </summary>
    public class ExecutingQueryEventArgs : IRemoteAdminEvent, IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutingQueryEventArgs"/> class.
        /// </summary>
        /// <param name="sender">Command sender instance.</param>
        /// <param name="query">User query.</param>
        /// <param name="isservercommunication">Indicated command sended by RA panel (not user) to get some info.</param>
        public ExecutingQueryEventArgs(CommandSender sender, string query, bool isservercommunication)
        {
            Sender = sender;
            Query = query;
            IsServerCommunication = isservercommunication;
        }

        /// <inheritdoc/>
        public CommandSender Sender { get; }

        /// <inheritdoc/>
        public bool IsAllowed { get; set; } = true;

        /// <summary>
        /// Gets the user query.
        /// </summary>
        public string Query { get; }

        /// <summary>
        /// Gets a value indicating whether the player executed this command, or whether the RA panel automatically executed the command to get some information.
        /// </summary>
        public bool IsServerCommunication { get; }
    }
}