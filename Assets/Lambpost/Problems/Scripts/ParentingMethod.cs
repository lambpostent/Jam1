using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class ParentingMethod : MonoBehaviour
{
    private int combinedMask;
    private bool onPlatform;
    public bool spawnedNext;
    private Vector2 origin;
    private BoxCollider2D boxCol;
    private RaycastHit2D hit;

    //Raycast origins
    private Vector2[] origins;
    private float colWidth;
    private float offset;

    private Transform platform;

    public UnityEvent SpawnNext;

    private void Start()
    {
        combinedMask = LayerMask.GetMask("Problem", "Platform");
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        colWidth = boxCol.size.x * transform.localScale.x;
        offset = colWidth / 2f;

        origins = new Vector2[] {
        new Vector2(transform.position.x - offset, boxCol.bounds.min.y - 0.01f),
        new Vector2(transform.position.x, boxCol.bounds.min.y - 0.01f),
        new Vector2(transform.position.x + offset, boxCol.bounds.min.y - 0.01f)
        };

        hit = new RaycastHit2D();

        foreach (var origin in origins)
        {
            var tempHit = Physics2D.Raycast(origin, Vector2.down, 0.05f, combinedMask);
            if (tempHit.collider != null)
            {
                hit = tempHit;
                break;
            }
        }

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

    public void SetPlatform(Transform plat)
    {
        platform = plat;
    }
}
