using JBAPI.API.Enums;
using System;
using System.Reflection;

namespace JBAPI.API.Plugin
{ 
    public interface IPlugin
    {
        Assembly Assembly { get; }
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        PluginPriority Priority { get; }
        void OnEnabled();
        void OnDisabled();
    }
}