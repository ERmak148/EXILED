// -----------------------------------------------------------------------
// <copyright file="RemoteAdmin.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Handlers
{
#pragma warning disable SA1623 // Property summary documentation should match accessors
    using Exiled.Events.EventArgs.RemoteAdmin;
    using Exiled.Events.Features;

    /// <summary>
    /// RA related events.
    /// </summary>
    public class RemoteAdmin
    {
        /// <summary>
        /// Invoked after RA query processed.
        /// </summary>
        public static Event<ExecutedQueryEventArgs> ExecutedQuery { get; set; } = new();

        /// <summary>
        /// Invoked before RA query processed.
        /// </summary>
        public static Event<ExecutingQueryEventArgs> ExecutingQuery { get; set; } = new();

        /// <summary>
        /// Invoked after RA command executed.
        /// </summary>
        public static Event<ExecutedCommandEventArgs> ExecutedCommand { get; set; } = new();

        /// <summary>
        /// Invoked before RA command executed.
        /// </summary>
        public static Event<ExecutingCommandEventArgs> ExecutingCommand { get; set; } = new();

        /// <summary>
        /// Called after RA query processed.
        /// </summary>
        /// <param name="ev">The <see cref="ExecutedQueryEventArgs"/> instance.</param>
        public static void OnExecutedQuery(ExecutedQueryEventArgs ev) => ExecutedQuery.InvokeSafely(ev);

        /// <summary>
        /// Called before RA query processed.
        /// </summary>
        /// <param name="ev">The <see cref="ExecutingQueryEventArgs"/> instance.</param>
        public static void OnExecutingQuery(ExecutingQueryEventArgs ev) => ExecutingQuery.InvokeSafely(ev);

        /// <summary>
        /// Called after RA command executed.
        /// </summary>
        /// <param name="ev">The <see cref="ExecutedCommandEventArgs"/> instance.</param>
        public static void OnExecutedCommand(ExecutedCommandEventArgs ev) => ExecutedCommand.InvokeSafely(ev);

        /// <summary>
        /// Called before RA command executed.
        /// </summary>
        /// <param name="ev">The <see cref="ExecutingCommandEventArgs"/> instance.</param>
        public static void OnExecutingCommand(ExecutingCommandEventArgs ev) => ExecutingCommand.InvokeSafely(ev);
    }
}