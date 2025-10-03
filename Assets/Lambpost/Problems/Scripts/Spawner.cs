using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameTracker gt;

    public int numberSpawned;
    public int spawnTarget;
    private bool spawningComplete;

    public UnityEvent SpawnProblem;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (numberSpawned < spawnTarget)
        {
            GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);
            SpawnProblem?.Invoke();
            SpawnScript prob = instance.GetComponent<SpawnScript>();
            prob.SpawnNext.AddListener(this.Spawn);
            prob.AddCount.AddListener(gt.AddCount);
            prob.RemoveCount.AddListener(gt.RemoveCount);
            numberSpawned++;
        }
        else if (numberSpawned >= spawnTarget)
        {
            StartCoroutine("EndGame");
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);

        spawningComplete = true;
        Debug.Log("GameOver");
    }
}
