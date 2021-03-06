﻿using System;

using apiblog.Context;
using apiblog.Interfaces;
using apiblog.UoW;

namespace apiblog.Factories
{
    public class GenericServiceFactory<T> : IGenericService<T> where T : class
    {
        public T GetService()
        {
            var UnitOfWork = new UnitOfWork(new ContextData());
            return (T)Activator.CreateInstance(typeof(T), UnitOfWork);           
        }
    }
}