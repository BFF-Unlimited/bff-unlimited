using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public IContainer? Kernel { get; set; }

        public void InitializeUnity(IContainer unityContainer)
        {
            this.DoInitializeUnity(unityContainer);
        }

        // TODO: Evaluate if code will beneded else delete
        //public void InitializePermissions(IPermissionRegistration permissions)
        //{
        //    this.DoInitializePermissions(permissions);
        //}

        public void InitializeComponent(IContainer unityContainer)
        {
            this.Kernel = unityContainer;
            this.DoInitializeComponent();
            this.Kernel = null;
        }

        public void RegisterTypeIdentifiers(IContainer unityContainer)
        {
            this.Kernel = unityContainer;
            this.DoRegisterTypeIdentifiers();
            this.Kernel = null;
        }

        // TODO: Evaluate if code will beneded else delete
        ///// <summary>
        ///// 3.
        ///// </summary>
        ///// <param name="unityContainer"></param>
        //protected virtual void DoInitializePermissions(IPermissionRegistration permissions)
        //{
        //}

        /// <summary>
        /// 4.
        /// </summary>
        /// <param name="unityContainer"></param>
        protected virtual void DoInitializeUnity(IContainer unityContainer)
        {
        }

        /// <summary>
        /// 5.
        /// </summary>
        /// <param name="unityContainer"></param>
        protected virtual void DoInitializeComponent()
        {
        }

        /// <summary>
        /// 6.
        /// </summary>
        /// <param name="unityContainer"></param>
        protected virtual void DoRegisterTypeIdentifiers()
        {
        }

        // TODO: Evaluate if code will beneded else delete
        //protected void RegisterTypeIdentifier<TType>(string identifier, EntityType entityType = EntityType.Unknown) where TType : class
        //{
        //    var entityTypeRegistry = this.Kernel.Resolve<ITypeIdentifierRegistry>();
        //    entityTypeRegistry.RegisterType<TType>(identifier, entityType);
        //}

        // TODO: Evaluate if code will beneded else delete
        //protected void RegisterPermissions(IPermissionRegistration permissions, Type permissionType)
        //{
        //    if (!typeof(IPermission).IsAssignableFrom(permissionType))
        //        new InvalidCastException("permissionType");

        //    permissions.Register(GetModuleType, permissionType);
        //}
    }
}
