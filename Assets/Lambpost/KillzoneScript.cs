using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillzoneScript : MonoBehaviour
{
    //public UnityEvent BlockFallEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Problem"))
        {
            ParentingMethod spawn = other.gameObject.GetComponent<ParentingMethod>();

            if (!spawn.spawnedNext)
            {
                spawn.SpawnNext?.Invoke();
            }

            Destroy(other.gameObject);
            //BlockFallEvent?.Invoke();
        }
    }
}
