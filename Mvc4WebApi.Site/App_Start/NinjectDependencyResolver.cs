﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace Mvc4.WebApi.App_Start
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}