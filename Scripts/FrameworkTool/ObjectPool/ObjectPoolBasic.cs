using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.FrameworkTool.ObjectPool
{
    /**
     * The ObjectPoolManager class will manage the pool of objects. 
     * It will create a specified number of objects to fill the pool and provide methods 
     * to get an inactive object from the pool and return it when it's no longer needed.
     * */
    public class ObjectPoolBasic : MonoBehaviour
    {
        [SerializeField]
        private GameObject objectPrefab; // The prefab that the pool will manage
        [SerializeField]
        private int poolSize = 10; // Size of the pool

        private Queue<GameObject> objectPool = new Queue<GameObject>(); // Pool of objects

        void Awake()
        {
            FillPool();
        }

        private void FillPool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(objectPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }

        public GameObject GetObject()
        {
            if (objectPool.Count > 0)
            {
                GameObject obj = objectPool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                // Optionally expand the pool if it's empty
                GameObject obj = Instantiate(objectPrefab);
                obj.SetActive(true);
                return obj;
            }
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }
}
