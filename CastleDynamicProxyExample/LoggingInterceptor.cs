using System;
using Castle.Core.Interceptor;

namespace CastleDynamicProxyExample
{
    public class LoggingInterceptor : IInterceptor
    {
        private int _indentation;

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _indentation++;
                Console.WriteLine("{0} ! {1}", new string(' ', _indentation), invocation.Method.Name);
                invocation.Proceed();
            }
            finally
            {
                _indentation--;
            }
        }
	}
}