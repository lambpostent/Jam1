using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No longer in use, was used for spawning physics based game objects that fall to create a word cloud effect.

public class ProblemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] problem;

    public void SpawnProblem()
    {
        int randomInt = Random.Range(0, 10);

        switch (randomInt)
        {
            case 0:
                Instantiate(problem[0], transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(problem[1], transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(problem[2], transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(problem[3], transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(problem[4], transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(problem[5], transform.position, Quaternion.identity);
                break;
            case 6:
                Instantiate(problem[6], transform.position, Quaternion.identity);
                break;
            case 7:
                Instantiate(problem[7], transform.position, Quaternion.identity);
                break;
            case 8:
                Instantiate(problem[8], transform.position, Quaternion.identity);
                break;
            case 9:
                Instantiate(problem[9], transform.position, Quaternion.identity);
                break;
        }
    }
}
