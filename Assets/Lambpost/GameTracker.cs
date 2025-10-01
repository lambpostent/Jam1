using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTracker : MonoBehaviour
{
    public UnityEvent KnockoutEvent;

    #region Variables
    public int lives;
    #endregion

    private void Start()
    {
        lives = 3;
    }

    public void LoseLife()
    {
        lives -= 1;

        if (lives <= 0)
        {
            KnockoutEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
