using Castle.DynamicProxy;
using Newtonsoft.Json;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();
            LogManager.GetLogger("TraceLog").Trace($"Wywołanie metody: {invocation.InvocationTarget}, " +
                                                    $"Metoda: { invocation.Method.Name}, parametry: " +
                                                    $"{string.Join(",", invocation.Arguments.Select(arg=> JsonConvert.SerializeObject(arg)))} ");
            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();
            LogManager.GetLogger("TraceLog").Trace($"Zakończono metode: {invocation.InvocationTarget}.{invocation.Method.Name}, z wynikiem: " +
                                                    $"{string.Join(",", JsonConvert.SerializeObject(invocation.ReturnValue))}" +
                                                    $" w czasie: {stopwatch.Elapsed}");
        }
    }
}
