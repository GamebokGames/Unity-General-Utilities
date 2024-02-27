using UnityEngine;

namespace Gamebok.GeneralUtilities
{
    public abstract class Proxy<T> : ScriptableObject where T : class
    {
        public T Value { get; private set; }
        
        public void Register(T instance)
        {
            Value = instance;
        }

        public void Unregister(T instance)
        {
            if (instance == Value)
            {
                Value = null;
            }
        }
    } 
}