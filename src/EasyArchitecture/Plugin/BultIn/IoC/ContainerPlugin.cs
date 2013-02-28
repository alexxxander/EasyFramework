﻿using System;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Core;
using EasyArchitecture.Core.Plugin;
using EasyArchitecture.Plugin.Contracts.IoC;

namespace EasyArchitecture.Plugin.BultIn.IoC
{
    internal class ContainerPlugin : AbstractPlugin, IContainerPlugin
    {
        private readonly Dictionary<Type, TypeRegistry> _registeredTypes = new Dictionary<Type, TypeRegistry>();

        protected override void ConfigurePlugin(ModuleAssemblies moduleAssemblies, PluginInspector pluginInspector)
        {
            AutoRegister(moduleAssemblies.DomainAssembly, moduleAssemblies.InfrastructureAssembly, false,pluginInspector);
            AutoRegister(moduleAssemblies.ApplicationAssembly, moduleAssemblies.ApplicationAssembly, true,pluginInspector);
        }

        private void AutoRegister(Assembly interfacesAssembly, Assembly implementationsAssembly, bool useInterception, PluginInspector pluginInspector)
        {
            var implementationTypes = implementationsAssembly.GetExportedTypes();
            var interfaceTypes = interfacesAssembly.GetExportedTypes();

            foreach (var exportedType in interfaceTypes)
            {
                if (!exportedType.IsInterface) continue;

                var type = exportedType;
                var implementationType = Array.Find(implementationTypes,
                                                    t => type.IsAssignableFrom(t) && !type.Equals(t));

                if (implementationType == null)
                {
                    continue;
                }

                pluginInspector.Log("Interface {0} are mapped to {1}, {2} interception", exportedType.FullName, implementationType.FullName,
                    useInterception?"using":"not using");

                _registeredTypes.Add(exportedType, new TypeRegistry(implementationType,useInterception));
            }
        }
 
        public IContainer GetInstance()
        {
            return new EasyArchitecture.Plugin.BultIn.IoC.Container(_registeredTypes);
        }
    }
}