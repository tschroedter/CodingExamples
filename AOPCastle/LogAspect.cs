using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace AOPCastle
{
    public class LogAspect : IInterceptor
    {
        public LogAspect([NotNull] ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
            Loggers = new Dictionary <Type, ILogger>();
        }

        public ILoggerFactory LoggerFactory { get; set; }
        public Dictionary <Type, ILogger> Loggers { get; set; }

        public void Intercept(IInvocation invocation)
        {
            ILogger logger = CreateOrGetLogger(invocation);

            if ( logger.IsDebugEnabled )
            {
                logger.Debug(CreateInvocationLogString(invocation));
            }

            try
            {
                invocation.Proceed();
            }
            catch ( Exception exception )
            {
                if ( logger.IsErrorEnabled )
                {
                    logger.Error(CreateInvocationLogString(invocation),
                                 exception);
                }
                throw;
            }
        }

        private ILogger CreateOrGetLogger(IInvocation invocation)
        {
            if ( !Loggers.ContainsKey(invocation.TargetType) )
            {
                Loggers.Add(invocation.TargetType,
                            LoggerFactory.Create(invocation.TargetType));
            }

            ILogger logger = Loggers [ invocation.TargetType ];
            return logger;
        }

        public static string CreateInvocationLogString(IInvocation invocation)
        {
            var stringBuilder = new StringBuilder(100);

            stringBuilder.AppendFormat("Called: {0}.{1}(",
                                       invocation.TargetType.Name,
                                       invocation.Method.Name);

            string invocationLogString = ConvertArgumentsToString(invocation,
                                                                  stringBuilder);

            return invocationLogString;
        }

        private static string ConvertArgumentsToString(IInvocation invocation,
                                                       StringBuilder stringBuilder)
        {
            foreach ( object argument in invocation.Arguments )
            {
                string argumentDescription = argument == null
                                                 ? "null"
                                                 : DumpObject(argument);

                stringBuilder.Append(argumentDescription).Append(",");
            }

            if ( invocation.Arguments.Any() )
            {
                stringBuilder.Length--;
            }

            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private static string DumpObject(object argument)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
                                         {
                                             TypeNameHandling = TypeNameHandling.All
                                         };

            string json = JsonConvert.SerializeObject(argument,
                                                      jsonSerializerSettings);

            return json;
        }
    }
}