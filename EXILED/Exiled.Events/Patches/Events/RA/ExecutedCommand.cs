// -----------------------------------------------------------------------
// <copyright file="ExecutedCommand.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.RA
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.RemoteAdmin;
    using HarmonyLib;
    using RemoteAdmin;

    /// <summary>
    /// Patches <see cref="CommandProcessor.ProcessQuery" />.
    /// Adds the <see cref="Handlers.RemoteAdmin.ExecutedCommand" /> event.
    /// </summary>
    [EventPatch(typeof(Handlers.RemoteAdmin), nameof(Handlers.RemoteAdmin.ExecutedCommand))]
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    internal static class ExecutedCommand
    {
        /// <summary>
        /// Executed Command transpiler.
        /// </summary>
        /// <param name="instructions">Source code instructions.</param>
        /// <returns>New code instructions.</returns>
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new (instructions);
            MethodInfo onExecutedCommandMethod = AccessTools.Method(typeof(Handlers.RemoteAdmin), nameof(Handlers.RemoteAdmin.OnExecutedCommand));
            ConstructorInfo constructorArgs = AccessTools.Constructor(typeof(ExecutedCommandEventArgs), new[] { typeof(CommandSender), typeof(string), typeof(string) });

            // I think this is shitcode, yes? Anyway i dont know how to write transpilers. Nobody know
            for (int i = 0; i < codes.Count; i++)
            {
                yield return codes[i];
                if (codes[i].opcode == OpCodes.Stloc_S && i > 0 && codes[i - 1].opcode == OpCodes.Ldloc_S)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_1); // sender
                    yield return new CodeInstruction(OpCodes.Ldloc_S, 6); // response
                    yield return new CodeInstruction(OpCodes.Ldarg_0); // query
                    yield return new CodeInstruction(OpCodes.Newobj, constructorArgs);
                    yield return new CodeInstruction(OpCodes.Call, onExecutedCommandMethod);
                }
            }
        }
    }
}