﻿using System.IO;

namespace Bounce.Framework
{
    public class ShellCommand : Task
    {
        [Dependency] public Task<string> Exe;
        [Dependency] public Task<string> Arguments;
        [Dependency] public Task<string> WorkingDirectory;

        public override void Build(IBounce bounce)
        {
            string oldDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(WorkingDirectory.Value);

            try
            {
                bounce.ShellCommand.ExecuteAndExpectSuccess(Exe.Value, Arguments.Value);
            } finally
            {
                Directory.SetCurrentDirectory(oldDirectory);
            }
        }
    }
}