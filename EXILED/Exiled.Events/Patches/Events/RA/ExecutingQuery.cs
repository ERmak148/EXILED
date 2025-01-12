// -----------------------------------------------------------------------
// <copyright file="ExecutingQuery.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.RA
{
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.RemoteAdmin;
    using HarmonyLib;
    using RemoteAdmin;

    /// <summary>
    /// Patches <see cref="CommandProcessor.ProcessQuery" />.
    /// Adds the <see cref="Handlers.RemoteAdmin.ExecutingQuery" /> event.
    /// </summary>
    [EventPatch(typeof(Handlers.RemoteAdmin), nameof(Handlers.RemoteAdmin.ExecutingQuery))]
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    internal class ExecutingQuery
    {
        /// <summary>
        /// ProccesQuery prefix.
        /// </summary>
        /// <param name="q">User query.</param>
        /// <param name="sender">Command sender instance.</param>
        /// <returns>Method execution allowed.</returns>
        public static bool Prefix(string q, CommandSender sender)
        {
            ExecutingQueryEventArgs ev = new ExecutingQueryEventArgs(sender, q, q.StartsWith("$"));

            Handlers.RemoteAdmin.OnExecutingQuery(ev);

            return ev.IsAllowed;
        }
    }
}