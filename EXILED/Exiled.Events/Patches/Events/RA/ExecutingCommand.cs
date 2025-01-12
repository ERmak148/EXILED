// -----------------------------------------------------------------------
// <copyright file="ExecutingCommand.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.RA
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;

    using CommandSystem;
    using Exiled.API.Features.Pools;
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.RemoteAdmin;
    using HarmonyLib;
    using RemoteAdmin;

    using static HarmonyLib.AccessTools;

    /// <summary>
    /// Patches <see cref="CommandProcessor.ProcessQuery" />.
    /// Adds the <see cref="Handlers.RemoteAdmin.ExecutingCommand" /> event.
    /// </summary>
    [EventPatch(typeof(Handlers.RemoteAdmin), nameof(Handlers.RemoteAdmin.ExecutingCommand))]
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    internal class ExecutingCommand
    {
        /// <summary>
        /// Executing Command transpiler.
        /// </summary>
        /// <param name="instructions">Source code instructions.</param>
        /// <param name="generator">IL generator.</param>
        /// <returns>New code instructions.</returns>
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Pool.Get(instructions);
            Label continueLabel = generator.DefineLabel();
            int offset = -6;
            int index = newInstructions.FindLastIndex(instruction => instruction.Calls(Method(typeof(ICommand), nameof(ICommand.Execute)))) + offset;
            MethodInfo onExecutingCommandMethod = AccessTools.Method(typeof(Handlers.RemoteAdmin), nameof(Handlers.RemoteAdmin.OnExecutingCommand));
            LocalBuilder ev = generator.DeclareLocal(typeof(ExecutingCommandEventArgs));

            // I think this is shitcode, yes? Anyway i dont know how to write transpilers. Nobody know
            newInstructions.InsertRange(index, new[]
            {
                new CodeInstruction(OpCodes.Ldarg_1), // sender
                new CodeInstruction(OpCodes.Ldarg_0), // query
                new CodeInstruction(OpCodes.Newobj, GetDeclaredConstructors(typeof(ExecutingCommandEventArgs))[0]),
                new CodeInstruction(OpCodes.Dup),
                new CodeInstruction(OpCodes.Dup),
                new CodeInstruction(OpCodes.Stloc_S, ev),
                new CodeInstruction(OpCodes.Call, onExecutingCommandMethod),
                new CodeInstruction(OpCodes.Callvirt, PropertyGetter(typeof(ExecutingCommandEventArgs), nameof(ExecutingCommandEventArgs.IsAllowed))),
                new CodeInstruction(OpCodes.Brtrue_S, continueLabel),
                new CodeInstruction(OpCodes.Ldstr, "Execution cancelled from plugin."),
                new CodeInstruction(OpCodes.Ret),
                new CodeInstruction(OpCodes.Nop).WithLabels(continueLabel),
            });
            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];
            ListPool<CodeInstruction>.Pool.Return(newInstructions);
        }
    }
}