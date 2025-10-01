using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnScript : MonoBehaviour
{
    private bool onPlatform;
    public bool spawnedNext;
    private int combinedMask;
    private BoxCollider2D boxCol;
    private Vector2 origin;

    public UnityEvent SpawnNext;

    private void Start()
    {
        combinedMask = LayerMask.GetMask("Problem", "Platform");
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        origin = new Vector2(boxCol.bounds.center.x, (boxCol.bounds.min.y - 0.01f));
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.05f, combinedMask);
        onPlatform = hit.collider != null;

        if (onPlatform && !spawnedNext)
        {
            SpawnNext?.Invoke();
            spawnedNext = true;
        }
    }
}
