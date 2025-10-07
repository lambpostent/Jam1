using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTracker : MonoBehaviour
{
    #region Variables
    public float blocks;
    #endregion

    private void Update()
    {
        if (blocks >= 10)
        {
            Debug.Log("Platform reached bottom!");
        }
    }
    
}
