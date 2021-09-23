using System.Collections.Generic;
using Castle.DynamicProxy;

namespace CastleDynamicProxyExample
{
    public static class Freezable
    {
        private static readonly IDictionary<object, IFreezable> _freezables = new Dictionary<object, IFreezable>();
        private static readonly ProxyGenerator _generator = new ProxyGenerator();

        public static void Freeze(object freezable)
        {
            if(IsFreezable(freezable))
                _freezables[freezable].Freeze();
        }

        public static bool IsFreezable(object obj)
        {
            return obj != null && _freezables.ContainsKey(obj);
        }

        public static bool IsFrozen(object freezable)
        {
            return IsFreezable(freezable) && _freezables[freezable].IsFrozen;
        }
        public static T CreateFreezable<T>() where T : class, new()
        {
            var interceptor = new FreezableInterceptor();
            var proxy = _generator.CreateClassProxy<T>(new LoggingInterceptor(), interceptor);
            _freezables.Add(proxy, interceptor);
            return proxy;
        }
    }
}
