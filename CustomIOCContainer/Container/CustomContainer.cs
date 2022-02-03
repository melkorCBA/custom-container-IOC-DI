using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomIOCContainer
{
    public class CustomContainer
    {
        private readonly Dictionary<Type, MetaData> types = new Dictionary<Type, MetaData>();
        private readonly Dictionary<Type, object> SingeltonObjects = new Dictionary<Type, object>();

        public void AddSingelton<TInterface, TImplementation>() where TImplementation : TInterface
        {
            types[typeof(TInterface)] = new MetaData { Type = typeof(TImplementation), Lifetime = LifeTime.Singelton };
        }

        public void AddTransient<TInterface, TImplementation>() where TImplementation : TInterface
        {
            types[typeof(TInterface)] = new MetaData { Type = typeof(TImplementation), Lifetime = LifeTime.Transient };
        }

        public TInterface GetService<TInterface>()
        {
            return (TInterface)Create(typeof(TInterface));
        }

        private object Create(Type type)
        {
            
            var (concreteType, lifetime) = types[type];
            //Find a default constructor using reflection
            var defaultConstructor = concreteType.GetConstructors()[0];
            //Verify if the default constructor requires params
            var defaultParams = defaultConstructor.GetParameters();
            //Instantiate all constructor parameters using recursion
            var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();
           

            if (lifetime.Equals(LifeTime.Singelton))
            {
                if (SingeltonObjects.ContainsKey(concreteType))
                {
                    return SingeltonObjects[concreteType];
                }
                var concreteObject = CreateNewInstance(defaultConstructor, parameters);

                SingeltonObjects[concreteType] = concreteObject;
                return concreteObject;
            }


            // for Transient dependecies
            return CreateNewInstance(defaultConstructor, parameters);



        }

        private object CreateNewInstance(ConstructorInfo defaultConstructor, object[] parameters)
        {
            return defaultConstructor.Invoke(parameters);
        }

    }

    class MetaData
    {
        public Type? Type { get; set; }
        public LifeTime Lifetime { get; set; }
        public void Deconstruct(out Type? type, out LifeTime lifetime)
        {
            type = Type;
            lifetime = Lifetime;
        }


    }

    enum LifeTime
    {
        Singelton = 1,
        Transient = 2
    }
}
