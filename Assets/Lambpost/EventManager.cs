using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Variables

    //Player 1
    public GameObject knockout_1;
    public GameObject gameover_1;
    //Player 2
    public GameObject knockout_2;
    public GameObject gameover_2;
    //Player 3
    public GameObject knockout_3;
    public GameObject gameover_3;
    //Player 4
    public GameObject knockout_4;
    public GameObject gameover_4;
    //Flow control
    public int knockedout;

    #endregion

    private void Start()
    {
        knockedout = 0;
        //Disable knockout screen
        knockout_1.SetActive(false);
        knockout_2.SetActive(false);
        knockout_3.SetActive(false);
        knockout_4.SetActive(false);
        //Disable gameover screen
        gameover_1.SetActive(false);
        gameover_2.SetActive(false);
        gameover_3.SetActive(false);
        gameover_4.SetActive(false);
    }

    private void Update()
    {
        if(knockedout == 4)
        {
            GameOverFunction();
        }
    }

    public void KnockoutFunction(int playerID)
    {
        switch (playerID)
        {
            case 0:
                knockout_1.SetActive(true);
                knockedout++;
                break;
            case 1:
                knockout_2.SetActive(true);
                knockedout++;
                break;
            case 2:
                knockout_3.SetActive(true);
                knockedout++;
                break;
            case 3:
                knockout_4.SetActive(true);
                knockedout++;
                break;
        }
    }

    public void GameOverFunction()
    {
        //Disable knockout screen
        knockout_1.SetActive(false);
        knockout_2.SetActive(false);
        knockout_3.SetActive(false);
        knockout_4.SetActive(false);
        //Enable gameover screen
        gameover_1.SetActive(true);
        gameover_2.SetActive(true);
        gameover_3.SetActive(true);
        gameover_4.SetActive(true);
    }
}
