using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnScript : MonoBehaviour
{
    private bool onPlatform;
    private bool previousState;
    public bool spawnedNext;
    private int combinedMask;
    private BoxCollider2D boxCol;
    RaycastHit2D hit;
    //Raycast origins
    private Vector2[] origins;
    private float halfWidth;

    public UnityEvent SpawnNext;
    public UnityEvent AddCount;
    public UnityEvent RemoveCount;

    private void Start()
    {
        combinedMask = LayerMask.GetMask("Problem", "Platform");
        boxCol = GetComponent<BoxCollider2D>();
        halfWidth = boxCol.bounds.extents.x;
    }

    private void Update()
    {
        /*origin = new Vector2(boxCol.bounds.center.x, (boxCol.bounds.min.y - 0.01f));
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.05f, combinedMask);
        onPlatform = hit.collider != null;*/

        //Replaced to allow for multiple raycasts.
        origins = new Vector2[] {
        new Vector2(transform.position.x - halfWidth / 2f, boxCol.bounds.min.y - 0.01f),
        new Vector2(transform.position.x, boxCol.bounds.min.y - 0.01f),
        new Vector2(transform.position.x + halfWidth / 2f, boxCol.bounds.min.y - 0.01f)
        };

        foreach(var origin in origins)
        {
            var tempHit = Physics2D.Raycast(origin, Vector2.down, 0.05f, combinedMask);

            if(tempHit.collider != null)
            {
                hit = tempHit;
                break;
            }
        }

        onPlatform = hit.collider != null;

        if (onPlatform && previousState != onPlatform)
        {
            //add
            AddCount?.Invoke();
            previousState = true;
        }
        else if (!onPlatform && previousState == true)
        {
            //remove
            RemoveCount?.Invoke();
            previousState = false;
        }

        if (onPlatform && !spawnedNext)
        {
            SpawnNext?.Invoke();
            spawnedNext = true;
        }
    }
}
