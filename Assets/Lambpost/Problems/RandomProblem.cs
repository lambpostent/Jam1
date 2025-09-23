using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class RandomProblem : MonoBehaviour
{
    //Arrays
    [SerializeField] private Color[] colours;
    [SerializeField] private string[] text;

    //Variables
    public int colourIndex;
    public int textIndex;
    public bool onPlatform;
    private Character_Controller platform;

    //Components
    public SpriteRenderer SR;
    public TMP_Text textComp;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;

    //For the raycast
    public LayerMask platformLayer;
    private float rayLength = 0.05f;
    private Vector2 origin;

    private void Start()
    {
        onPlatform = false;
        //Get random index for the two arrays.
        colourIndex = Random.Range(0, (colours.Length - 1));
        textIndex = Random.Range(0, (text.Length - 1));
        //Get Components
        SR = GetComponent<SpriteRenderer>();
        textComp = GetComponentInChildren<TMP_Text>();
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        //Set random colour and text
        SR.color = colours[colourIndex];
        textComp.text = text[textIndex];
    }

    private void Update()
    {
        origin = new Vector2(boxCol.bounds.center.x, boxCol.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayLength, platformLayer);

        onPlatform = hit.collider != null;

        if (onPlatform)
        {
            platform = hit.collider.gameObject.GetComponentInParent<Character_Controller>();
        }
    }

    private void FixedUpdate()
    {
        if (onPlatform)
        {
            rb.MovePosition(rb.position + (platform.platformDelta * 5));
        }
    }
}
