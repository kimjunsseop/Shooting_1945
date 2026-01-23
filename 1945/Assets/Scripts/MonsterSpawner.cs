using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsters;
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
            int rrand = Random.Range(0,101);
            int index = -1;
            if(rrand <= 80)
            {
                index = 0;
            }
            else
            {
                index = 1;
            }
            Vector3 spawn = new Vector3(rand, transform.position.y, 0);
            Instantiate(monsters[index], spawn, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
