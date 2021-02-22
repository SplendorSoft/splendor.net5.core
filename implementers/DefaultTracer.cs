using System;
using System.Threading.Tasks;
using splendor.net5.core.commons;
using splendor.net5.core.contracts;

namespace splendor.net5.core.implementers
{
    public class DefaultTracer : ITracer
    {
        public Task TraceAdd<E>(E entity, DTrace trace) where E : class, new()
        {
            Type objectType = entity.GetType();
            objectType.GetProperty("UserAdd").SetValue(entity, trace.UserName);
            objectType.GetProperty("DateAdd").SetValue(entity, DateTime.Now);
            return Task.CompletedTask;
        }

        public Task TraceEdit<E>(E entity, DTrace trace) where E : class, new()
        {
            Type objectType = entity.GetType();
            objectType.GetProperty("UserEdit").SetValue(entity, trace.UserName);
            objectType.GetProperty("DateEdit").SetValue(entity, DateTime.Now);
            return Task.CompletedTask;
        }
    }
}