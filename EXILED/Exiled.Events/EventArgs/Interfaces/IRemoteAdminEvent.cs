// -----------------------------------------------------------------------
// <copyright file="IRemoteAdminEvent.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Interfaces
{
    /// <summary>
    /// Event args used for all Remote Admin events.
    /// </summary>
    public interface IRemoteAdminEvent
    {
        /// <summary>
        /// Gets the sender who used the command.
        /// </summary>
        public CommandSender Sender { get; }
    }
}