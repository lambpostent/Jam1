using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int numberSpawned;
    public int spawnTarget;
    private bool spawningComplete;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (numberSpawned < spawnTarget)
        {
            GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);
            SpawnScript prob = instance.GetComponent<SpawnScript>();
            prob.SpawnNext.AddListener(this.Spawn);
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
