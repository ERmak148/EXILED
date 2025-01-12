// -----------------------------------------------------------------------
// <copyright file="ExecutingCommandEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.RemoteAdmin
{
    using Exiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains information about executing RA command.
    /// </summary>
    public class ExecutingCommandEventArgs : IRemoteAdminEvent, IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutingCommandEventArgs"/> class.
        /// </summary>
        /// <param name="sender">Command sender instance.</param>
        /// <param name="query">User query.</param>
        public ExecutingCommandEventArgs(CommandSender sender, string query)
        {
            Sender = sender;
            Query = query;
        }

        /// <inheritdoc/>
        public CommandSender Sender { get; }

        /// <inheritdoc/>
        public bool IsAllowed { get; set; } = true;

        /// <summary>
        /// Gets the user query.
        /// </summary>
        public string Query { get; }
    }
}