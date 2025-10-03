using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomise : MonoBehaviour
{
    #region Variables
    //Arrays
    private Color[] colours;
    //Components
    public SpriteRenderer SR;
    //Values
    private int colourIndex;
    #endregion
    
    private void Start()
    {
        //Fill arrays
        FillColours();

        //Get random index.
        colourIndex = Random.Range(0, colours.Length);
        //Set random colour
        SR.color = colours[colourIndex];

        RandomSize();
    }

    private void RandomSize()
    {
        float randX = Random.Range(0.25f, 1f);
        float randY = Random.Range(0.25f, 1f);
        float randZ = Random.Range(0.25f, 1f);
        gameObject.transform.localScale = new Vector3(randX, randY, randZ);
    }

    private void FillColours()
    {
        colours = new Color[10];
        colours[0] = new Color(0.49f, 0.98f, 1f);
        colours[1] = new Color(0.97f, 0.51f, 0.47f);
        colours[2] = new Color(0.44f, 0.51f, 0.22f);
        colours[3] = new Color(0.47f, 0.32f, 0.66f);
        colours[4] = new Color(1f, 0.97f, 0f);
        colours[5] = new Color(0.80f, 0.33f, 0f);
        colours[6] = new Color(0.60f, 1f, 0.6f);
        colours[7] = new Color(0.44f, 0.50f, 0.56f);
        colours[8] = new Color(1f, 0f, 1f);
        colours[9] = new Color(0f, 0.75f, 1f);
    }
}
