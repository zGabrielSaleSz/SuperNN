using SuperNN.Core.Domain;

namespace SuperNN.Core.Providers
{
    public class FunctionProvider
    {
        private IDictionary<Type, object> _activationFunctionsByType;
        private IDictionary<Type, object> _errorFunctionsByType;
        private IDictionary<Type, object> _initializationFunctionsByType;
        public FunctionProvider()
        {
            _activationFunctionsByType = new Dictionary<Type, object>();
            _errorFunctionsByType = new Dictionary<Type, object>();
            _initializationFunctionsByType = new Dictionary<Type, object>();
        }

        public IActivationFunction GetActivationFunction<T>() where T : IActivationFunction, new()
        {
            return GetInstanceOf<T>(_activationFunctionsByType);
        }

        public IErrorFunction GetErrorFunction<T>() where T : IErrorFunction, new()
        {
            return GetInstanceOf<T>(_errorFunctionsByType);
        }

        public IInitializationFunction GetInitializationFunction<T>() where T : IInitializationFunction, new()
        {
            return GetInstanceOf<T>(_initializationFunctionsByType);
        }

        private T GetInstanceOf<T>(IDictionary<Type, object> data) where T : new()
        {
            var type = typeof(T);
            if (!data.TryGetValue(type, out var function))
            {
                var instance = new T();
                data[type] = instance;
                function = instance;
            }
            return (T)function;
        }

    }
}
