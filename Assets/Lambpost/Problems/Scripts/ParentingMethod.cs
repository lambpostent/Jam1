using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentingMethod : MonoBehaviour
{
    private int combinedMask;
    private bool onPlatform;
    private bool spawnedNext;
    private Vector2 origin;
    private BoxCollider2D boxCol;

    private Transform platform;

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
        else if (onPlatform && spawnedNext)
        {
            transform.SetParent(platform);
        }
    }

    private void OnDestroy()
    {
        if (!spawnedNext)
        {
            SpawnNext?.Invoke();
        }
    }

    public void SetPlatform(Transform plat)
    {
        platform = plat;
    }
}
