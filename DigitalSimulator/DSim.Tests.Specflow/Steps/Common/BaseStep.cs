using System;
using System.Threading;
using Castle.Windsor;
using DSim.Common;
using DSim.LogicGates.RealTime;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace DSim.Tests.Specflow.Steps.Common
{
    public abstract class BaseStep
    {
        private static readonly TimeSpan SleepTime = TimeSpan.FromSeconds(0.1);

        public void SleepWaitAndDo([NotNull] Func <bool> breakIfTrue,
                                   [NotNull] Action doSomething)
        {
            for ( var i = 0 ; i < 10 ; i++ )
            {
                Thread.Sleep(SleepTime);

                if ( breakIfTrue() )
                {
                    break;
                }

                doSomething();
            }
        }

        public void DoNothing()
        {
        }

        public static WindsorContainer GetWindsorContainerFromContext()
        {
            var container = ( WindsorContainer ) ScenarioContext.Current [ "WindsorContainer" ];
            return container;
        }

        public static IWire GetWireFromContext([NotNull] string name)
        {
            return ( IWire ) ScenarioContext.Current [ name ];
        }

        public static IRealTimeOr CreateRealTimeOr([NotNull] IAgenda agenda,
                                                   [NotNull] IWire inputOne,
                                                   [NotNull] IWire inputTwo,
                                                   [NotNull] IWire output)
        {
            WindsorContainer container = GetWindsorContainerFromContext();

            var factory = container.Resolve <IRealTimeOrFactory>();
            IRealTimeOr or = factory.Create(agenda,
                                            inputOne,
                                            inputTwo,
                                            output);
            return or;
        }

        public static IWire CreateWire([NotNull] string name)
        {
            WindsorContainer container = GetWindsorContainerFromContext();

            var wire = container.Resolve <IWire>();
            wire.Name = name;

            return wire;
        }

        public static IAgenda CreateAgenda([NotNull] string name)
        {
            WindsorContainer container = GetWindsorContainerFromContext();

            var agenda = container.Resolve <IAgenda>();
            agenda.Name = name;

            return agenda;
        }

        public static IRealTimeInverter CreateRealTimeInverter(IAgenda agenda,
                                                               IWire input,
                                                               IWire output)
        {
            WindsorContainer container = GetWindsorContainerFromContext();

            var factory = container.Resolve <IRealTimeInverterFactory>();
            IRealTimeInverter inverter = factory.Create(agenda,
                                                        input,
                                                        output);
            return inverter;
        }

        // todo obsolete
        public static IRealTimeInverter CreateRealTimeInverter(IWire input,
                                                               IWire output)
        {
            WindsorContainer container = GetWindsorContainerFromContext();

            var factory = container.Resolve <IRealTimeInverterFactory>();
            IRealTimeInverter inverter = factory.Create(input,
                                                        output);
            return inverter;
        }

        public static IRealTimeProbe CreateRealTimeProbe(IAgenda agenda,
                                                         IWire wire)
        {
            WindsorContainer container = GetWindsorContainerFromContext();

            var factory = container.Resolve <IRealTimeProbeFactory>();
            IRealTimeProbe probe = factory.Create(agenda,
                                                  wire);
            return probe;
        }

        public static IRealTimeProbe GetRealTimeProbeFromContext(string probeName)
        {
            var probe = ( IRealTimeProbe ) ScenarioContext.Current [ probeName ];
            return probe;
        }

        public static IAgenda GetAgendaFromContext(string probeName)
        {
            var agenda = ( IAgenda ) ScenarioContext.Current [ probeName ];
            return agenda;
        }
    }
}