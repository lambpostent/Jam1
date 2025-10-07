using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTracker : MonoBehaviour
{
    #region Variables
    public float blocks;
    private bool flowControl;

    public UnityEvent Knockout;
    #endregion

    private void Start()
    {
        flowControl = false;
    }

    private void Update()
    {
        if (blocks >= 10 && !flowControl)
        {
            Knockout?.Invoke();
            flowControl = true;
        }
    }
    
}
