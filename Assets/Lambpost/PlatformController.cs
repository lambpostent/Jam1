using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatformController : MonoBehaviour
{
    #region Variables
    //Needed for screen space and input controls
    public int playerIndex;

    //Limit movement
    public float moveSpeed = 1;
    private float minX = -2f;
    private float maxX = 2f;
    private float buffer = 1f;

    //Required for screen layout
    private float worldHeight;
    private float worldWidth;
    private float sectionWidth;

    private Rigidbody2D rb;
    private bool isMoving;

    #endregion

    void Start()
    {
        worldHeight = Camera.main.orthographicSize * 2f;
        worldWidth = worldHeight * Camera.main.aspect;
        sectionWidth = worldWidth / 4f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ApplyMovement();
        SetVertical();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.rigidbody != null && other.rigidbody.TryGetComponent(out I_Inertia receiver))
        {
            if (other.contacts.Any(c => c.normal.y > 0.5f))
            {
                Vector2 platformVelocity = GetComponent<Rigidbody2D>().velocity;
                receiver.ApplyInertia(platformVelocity);
            }
        }
    }

    private void ApplyMovement()
    {
        float inputValue = 0f;

        if (WhalesongInput.GetButton(playerIndex, WhaleButton.Left))
        {
            inputValue = -1;
        }
        else if (WhalesongInput.GetButton(playerIndex, WhaleButton.Right))
        {
            inputValue = 1f;
        }
        //Calculate the velocity.
        Vector2 velocity = new Vector2(inputValue * moveSpeed, rb.velocity.y);
        //Do a check for the next position.
        float nextX = rb.position.x + velocity.x * Time.fixedDeltaTime;
        //Clamp to screen space.
        minX = -worldWidth / 2f + playerIndex * sectionWidth + buffer;
        maxX = minX + sectionWidth - buffer * 2f;
        nextX = Mathf.Clamp(nextX, minX, maxX);
        //Apply velocity based on clamp.
        velocity.x = (nextX - rb.position.x) / Time.fixedDeltaTime;
        rb.velocity = velocity;
    }

    private void SetVertical()
    {
        int allChildCount = GetComponentsInChildren<Transform>().Length - 1;
        transform.position = new Vector2(transform.position.x, -allChildCount);
    }
    /*Vertical Movement logic based on number of blocks on platform
     * Removed due to it not working overly well.
    public void MoveUpFunction()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveVertical(1f));
        }
    }

    public void MoveDownFunction()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveVertical(-1f));
        }
    }

    private IEnumerator MoveVertical(float direction)
    {
        Vector2 startPos = rb.position;
        Vector2 endPos = startPos + Vector2.up * direction;

        float duration = 0.5f;
        float elapsedTime = 0f;

        isMoving = true;

        while (elapsedTime < duration)
        {
            Vector2 newPos = Vector2.Lerp(startPos, endPos, elapsedTime / duration);
            rb.MovePosition(newPos);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(endPos);
        isMoving = false;
    }
    */
    /* Old vertical movement logic, keep for redundency.
    private IEnumerator MoveUp()
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = new Vector2(transform.position.x, (transform.position.y + 1f));

        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            transform.position = Vector2.Lerp(startPos, endPos, elapsedTime/1f);
            elapsedTime += Time.deltaTime;
            isMoving = true;
            yield return null;
        }

        isMoving = false;
        transform.position = endPos;
    }

    private IEnumerator MoveDown()
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = new Vector2(transform.position.x, (transform.position.y - 1f));

        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            transform.position = Vector2.Lerp(startPos, endPos, elapsedTime/1f);
            elapsedTime += Time.deltaTime;
            isMoving = true;
            yield return null;
        }

        isMoving = false;

        transform.position = endPos;
    }
    */
}
