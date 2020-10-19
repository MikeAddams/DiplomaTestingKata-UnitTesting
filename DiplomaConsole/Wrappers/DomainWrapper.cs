using System;

namespace Diploma.Wrappers
{
    public class DomainWrapper : IDomainWrapper
    {
        public string GetRoothDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}