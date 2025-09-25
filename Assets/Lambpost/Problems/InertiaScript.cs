using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InertiaScript : MonoBehaviour, I_Inertia
{
    public void ApplyInertia(Vector2 velocity)
    {
        GetComponent<Rigidbody2D>().velocity += velocity * Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.6f, LayerMask.GetMask("Problem"));
        if (hit.collider != null && hit.collider.TryGetComponent(out I_Inertia receiver))
        {
            receiver.ApplyInertia(GetComponent<Rigidbody2D>().velocity);
        }
    }
}
