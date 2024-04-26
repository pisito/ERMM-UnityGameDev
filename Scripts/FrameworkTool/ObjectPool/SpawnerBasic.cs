using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ERMM.FrameworkTool.ObjectPool
{
    public class SpawnerBasic : MonoBehaviour
    {
        public ObjectPoolBasic poolManager;

        public KeyCode spawnKey = KeyCode.Space;

        [SerializeField]
        private List<Transform> spawnLocations = new List<Transform>(); // List of potential spawn locations
        [SerializeField]
        private bool useRandomLocations = false; // Toggle for using random spawn locations
        [SerializeField]
        private bool useSpawnKey = true; // Toggle for using random spawn locations


        void Start()
        {
            if(poolManager == null)
                poolManager = FindObjectOfType<ObjectPoolBasic>(); // Find the ObjectPoolManager in the scene
        }

        void Update()
        {
            if (useSpawnKey && Input.GetKeyDown(spawnKey)) // Example input for spawning objects
            {
                SpawnObject();
            }
        }

        private void SpawnObject()
        {
            GameObject obj = poolManager.GetObject(); // Get an object from the pool

            if (useRandomLocations && spawnLocations.Count > 0)
            {
                // Choose a random location from the list if enabled and list is not empty
                Transform spawnTransform = spawnLocations[Random.Range(0, spawnLocations.Count)];
                obj.transform.position = spawnTransform.position;
                obj.transform.rotation = spawnTransform.rotation;
            }
            else
            {
                // Use the spawner's own position if random locations are not enabled or the list is empty
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
            }
        }
    }
}
