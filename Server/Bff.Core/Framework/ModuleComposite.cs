using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Core.Framework
{
    public abstract class ModuleComposite
    {
        private Type? _moduleType;

        private Type GetModuleType => _moduleType ??
                                           (_moduleType = GetType());

        public IKernel? Kernel { get; set; }

        public void InitializeNinject(IKernel container)
        {
            DoInitializeNinject(container);
        }

        /// <summary>
        /// 4.
        /// </summary>
        /// <param name="unityContainer"></param>
        protected virtual void DoInitializeNinject(IKernel container)
        {
        }
    }
}
