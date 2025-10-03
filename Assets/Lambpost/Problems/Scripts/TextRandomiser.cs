using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRandomiser : MonoBehaviour
{
    [SerializeField] private string[] textArray;
    public TMP_Text text;

    public void RandomiseText()
    {
        text.text = textArray[(Random.Range(0, textArray.Length))];
    }
}
