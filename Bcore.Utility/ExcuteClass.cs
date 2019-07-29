using System;

namespace Bcore.Utility
{
    public class ExcuteClass<T> where T : class
    {
        /// <summary>
        /// Call method in object and don't return a data. (method void)
        /// </summary>
        /// <param name="methodName">method name of class.</param>
        /// <param name="paramMethod">the params of method, if method don't params ExcuteMethodNoReturnData("methodName"), else ExcuteMethodNoReturnData("methodName",3,5,"abc","etc")</param>
        public void ExcuteMethodNoReturnData(string methodName, params object[] paramMethod)
        {
            var methodInfo = typeof(T).GetMethod(methodName);
            object classInstance = Activator.CreateInstance(typeof(T));
            methodInfo.Invoke(classInstance, paramMethod);
        }
        /// <summary>
        /// Call method in object and return a data.
        /// </summary>
        /// <param name="methodName">method name of class.</param>
        /// <param name="paramMethod">the params of method, if method don't params ExcuteMethodNoReturnData("methodName"), else ExcuteMethodNoReturnData("methodName",3,5,"abc","etc")</param>
        public object ExcuteMethodReturnData(string methodName, params object[] paramMethod)
        {
            var methodInfo = typeof(T).GetMethod(methodName);
            // initialize object of class T
            object classInstance = Activator.CreateInstance(typeof(T));
            // call method in object, with the argument and return data.
            return methodInfo.Invoke(classInstance, paramMethod);
        }
    }
}
