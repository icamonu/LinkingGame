using System.Collections.Generic;
using UnityEngine;

namespace Pooling
{
    public abstract class ObjectPool<T> : MonoBehaviour
    {
        protected Queue<T> pool = new Queue<T>();
        
        public virtual T Get()
        {
            return pool.Dequeue();
        }
        
        public virtual void ReturnToPool(T objectToReturn)
        {
            pool.Enqueue(objectToReturn);
        }
    }
}