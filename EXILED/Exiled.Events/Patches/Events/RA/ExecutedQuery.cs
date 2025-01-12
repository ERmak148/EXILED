// -----------------------------------------------------------------------
// <copyright file="ExecutedQuery.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.RA
{
    using Exiled.API.Features;
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.RemoteAdmin;
    using HarmonyLib;
    using RemoteAdmin;

    /// <summary>
    /// Patches <see cref="CommandProcessor.ProcessQuery" />.
    /// Adds the <see cref="Handlers.RemoteAdmin.ExecutedQuery" /> event.
    /// </summary>
    [EventPatch(typeof(Handlers.RemoteAdmin), nameof(Handlers.RemoteAdmin.ExecutedQuery))]
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    internal class ExecutedQuery
    {
        /// <summary>
        /// ProccesQuery postfix.
        /// </summary>
        /// <param name="result">Source method return value.</param>
        /// <param name="q">User query.</param>
        /// <param name="sender">Command sender instance.</param>
        public static void Postfix(string result, string q, CommandSender sender)
        {
            ExecutedQueryEventArgs executedQueryEventArgs = new ExecutedQueryEventArgs(sender, result, q, q.StartsWith("$"));
            Handlers.RemoteAdmin.OnExecutedQuery(executedQueryEventArgs);
        }
    }
}