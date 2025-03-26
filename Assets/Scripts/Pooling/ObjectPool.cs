using System.Collections.Generic;
using UnityEngine;

namespace Pooling
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        private Queue<T> pool = new Queue<T>();
        private T prefab;
        private Transform parent;

        public ObjectPool(T prefab, int initialSize, Transform parent = null)
        {
            this.prefab = prefab;
            this.parent = parent;
            Initialize(initialSize);
        }

        public void Initialize(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                T obj = Object.Instantiate(prefab, parent);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        public T Get()
        {
            if (pool.Count > 0)
            {
                T obj = pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                T obj = Object.Instantiate(prefab, parent);
                return obj;
            }
        }

        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}