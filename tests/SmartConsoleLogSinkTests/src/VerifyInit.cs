using System.Runtime.CompilerServices;
using DiffEngine;

class VerifyInit
{
    [ModuleInitializer]
    internal static void Init()
    {
        DiffTools.UseOrder(DiffTool.VisualStudioCode, DiffTool.SublimeMerge, DiffTool.Meld, DiffTool.TortoiseGitIDiff);
    }
}