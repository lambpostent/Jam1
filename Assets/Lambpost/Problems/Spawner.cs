using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);
        RandomProblem prob = instance.GetComponent<RandomProblem>();
        prob.SpawnNext.AddListener(this.Spawn);
    }
}
