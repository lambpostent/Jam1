using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public int playerIndex;

    public float moveSpeed = 0.0025f;
    private float minX = -2f;
    private float maxX = 2f;
    private float buffer = 1f;

    private float worldHeight;
    private float worldWidth;
    private float sectionWidth;

    public Vector2 platformDelta { get; private set; }
    private Vector2 lastPosition;

    void Start()
    {
        worldHeight = Camera.main.orthographicSize * 2f;
        worldWidth = worldHeight * Camera.main.aspect;
        sectionWidth = worldWidth / 4f;
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        Vector3 playerPos = transform.position;
        minX = -worldWidth / 2f + playerIndex * sectionWidth + buffer;
        maxX = minX + sectionWidth - buffer * 2f;

        if (WhalesongInput.GetButton(playerIndex, WhaleButton.Left))
        {
            playerPos.x -= moveSpeed;
        }
        else if (WhalesongInput.GetButton(playerIndex, WhaleButton.Right))
        {
            playerPos.x += moveSpeed;
        }
        //Clamp to screen space.
        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        transform.position = playerPos;
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        platformDelta = new Vector2((transform.position.x - lastPosition.x), (transform.position.y - lastPosition.y));
        lastPosition = transform.position;
    }
}
