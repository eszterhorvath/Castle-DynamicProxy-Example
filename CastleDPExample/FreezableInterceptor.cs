using System;
using Castle.Core.Interceptor;

namespace CastleDPExample
{
    public class FreezableInterceptor : IInterceptor, IFreezable
    {
        private bool _isFrozen;
        public bool IsFrozen => _isFrozen;

        public void Freeze()
        {
            _isFrozen = true;
        }

        public void Intercept(IInvocation invocation)
        {
            if (_isFrozen && invocation.Method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Object Frozen");
            }
            invocation.Proceed();
        }
    }
}