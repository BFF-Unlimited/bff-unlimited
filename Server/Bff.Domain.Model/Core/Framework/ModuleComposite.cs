using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Domain.Model.Core.Framework
{
    public abstract class ModuleComposite
    {
        private Type? moduleType;

        private Type GetModuleType => this.moduleType ??
                                           (this.moduleType = this.GetType());

        public IKernel? Kernel { get; set; }

        public void InitializeNinject(IKernel container)
        {
            this.DoInitializeNinject(container);
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
