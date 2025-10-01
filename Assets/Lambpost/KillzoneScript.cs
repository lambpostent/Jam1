using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillzoneScript : MonoBehaviour
{
    public UnityEvent BlockFallEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpawnScript spawn = other.gameObject.GetComponent<SpawnScript>();
        if (!spawn.spawnedNext)
        {
            spawn.SpawnNext?.Invoke();
        }

        Destroy(other.gameObject);
        BlockFallEvent?.Invoke();
    }
}
