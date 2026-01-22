using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public int interval;
    void Start()
    {
        interval = 2;
        StartCoroutine(Spawn());
    }
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            float rand = Random.Range(-2f,2f);
            Vector3 spawn = new Vector3(rand, transform.position.y, 0);
            Instantiate(monster, spawn, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
