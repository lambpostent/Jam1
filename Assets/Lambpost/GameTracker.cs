using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTracker : MonoBehaviour
{
    public UnityEvent KnockoutEvent;
    public UnityEvent MoveUp;
    public UnityEvent MoveDown;

    #region Variables
    public int lives;
    public int platformCount;
    #endregion

    public void AddCount()
    {
        platformCount += 1;
        MoveDown?.Invoke();
    }

    public void RemoveCount()
    {
        platformCount -= 1;
        MoveUp?.Invoke();
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
