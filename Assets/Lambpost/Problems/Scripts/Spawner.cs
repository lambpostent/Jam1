using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameTracker gt;
    public Transform platform;

    public int numberSpawned;
    public int spawnTarget;
    private bool spawningComplete;

    private Vector2 minX;
    private Vector2 maxX;

    public UnityEvent SpawnProblem;

    void Start()
    {
        minX = new Vector2(transform.position.x - 2f, 6f);
        maxX = new Vector2(transform.position.x + 2f, 6f);
        Spawn();
    }

    public void Spawn()
    {
        if (numberSpawned < spawnTarget)
        {
            float tempPoint = Random.Range(0f, 1f);
            Vector2 spawnLocation = Vector2.Lerp(minX, maxX, tempPoint);

            GameObject instance = Instantiate(prefab, spawnLocation, Quaternion.identity);
            SpawnProblem?.Invoke();

            ParentingMethod prob = instance.GetComponent<ParentingMethod>();
            prob.SpawnNext.AddListener(this.Spawn);
            prob.SetPlatform(platform);
            //prob.AddCount.AddListener(gt.AddCount);
            //prob.RemoveCount.AddListener(gt.RemoveCount);
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
