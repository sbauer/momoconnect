using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StructureMap.Configuration.DSL;

namespace MomoConnect.WebUI.DependencyResolution
{
    public class CommandRegistry: Registry
    {
        public CommandRegistry()
        {
            Scan(x =>
            { 
            
                x.AssemblyContainingType<IMediator>();
                x.AssemblyContainingType<DefaultRegistry>();

                x.AddAllTypesOf(typeof (IRequestHandler<,>));
                x.AddAllTypesOf(typeof (IAsyncRequestHandler<,>));
                x.WithDefaultConventions();
            }
                );

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ct => t => ct.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ct => t => ct.GetAllInstances(t));

        }
    }
}
