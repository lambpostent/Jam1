using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Randomise : MonoBehaviour
{
    #region Variables
    //Arrays
    private Color[] colours;
    private string[] text;
    //Components
    public SpriteRenderer SR;
    public TMP_Text textComp;
    //Values
    private int colourIndex;
    private int textIndex;
    #endregion
    
    private void Start()
    {
        //Fill arrays
        FillColours();
        FillProblems();

        //Get random index for the two arrays.
        colourIndex = Random.Range(0, colours.Length);
        textIndex = Random.Range(0, text.Length);
        //Set random colour and text
        SR.color = colours[colourIndex];
        textComp.text = text[textIndex];
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

    private void FillProblems()
    {
        text = new string[10];
        text[0] = "School";
        text[1] = "Friend";
        text[2] = "Family";
        text[3] = "Money";
        text[4] = "Car Troubles";
        text[5] = "Illness";
        text[6] = "Self Harm";
        text[7] = "Exams";
        text[8] = "War";
        text[9] = "Society";
    }
}
