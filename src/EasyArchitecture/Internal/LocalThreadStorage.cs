﻿using System.Threading;

namespace EasyArchitecture.Internal
{
    internal static class LocalThreadStorage
    {
        private const string BusinessModuleNameKey = "bmn";
        private const string NHibernateSession = "nhs";

        internal static string GetCurrentBusinessModuleName()
        {
            var slot = Thread.GetNamedDataSlot(BusinessModuleNameKey);
            return (string)Thread.GetData(slot);
        }

        internal static void SetCurrentBusinessModuleName(string businessModuleName)
        {
            var slot = Thread.GetNamedDataSlot(BusinessModuleNameKey);
            Thread.SetData(slot, businessModuleName);
        }

        internal static object RecoverSession(string businessModuleName)
        {
            var slot = Thread.GetNamedDataSlot(NHibernateSession + businessModuleName);
            return Thread.GetData(slot);
        }

        internal static void ClearSession(string businessModuleName)
        {
            var slot = Thread.GetNamedDataSlot(NHibernateSession + businessModuleName);
            Thread.SetData(slot, null);
        }

        internal static void StoreSession(string businessModuleName, object session)
        {
            var slot = Thread.GetNamedDataSlot(NHibernateSession + businessModuleName);
            Thread.SetData(slot, session);
        }

    }
}