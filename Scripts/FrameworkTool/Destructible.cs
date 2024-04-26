using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace ERMM.FrameworkTool.ObjectPool
{

    public class Destructible : MonoBehaviour
    {
        public UnityEvent onDestroy;

        public bool useDelay = false;
        public int delay = 0;
        public bool onlyDisable;

        private bool triggerDestroySignal = false;

        public void Destroy()
        {
            if (triggerDestroySignal) return; // already start destroying, prevent redundant call

            triggerDestroySignal = true;

            if (useDelay && delay > 0)
            {
                StartCoroutine(DestroyWithDelay());
            }
            else
            {
                HandleOnDestory();
                if (onlyDisable)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }

        IEnumerator DestroyWithDelay()
        {
            yield return new WaitForSecondsRealtime(delay);
            HandleOnDestory();
        }


        void HandleOnDestory()
        {
            onDestroy?.Invoke();
        }
    }
}
