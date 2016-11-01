using System;
using AOPCastle;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AOPConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Run 2 - configuration fluent");
            using ( var container = new WindsorContainer() )
            {
                container.AddFacility<LoggingFacility>(f => f.UseNLog());

                container.Register(
                                   Component.For <IInterceptor>()
                                            .ImplementedBy <LogAspect>()
                                            .Named("LogAspect"));
                container.Register(
                                   Component.For <ISomething>()
                                            .ImplementedBy <Something>()
                                            .Interceptors(InterceptorReference.ForKey("LogAspect")).Anywhere);
                var something = container.Resolve <ISomething>();
                something.DoSomething("");
                Console.WriteLine("Augment 10 returns " + something.Augment(10));
                something.DoSomething(new Record(1.0,2.0,"Hello World", 3.0));
            }
        }
    }
}