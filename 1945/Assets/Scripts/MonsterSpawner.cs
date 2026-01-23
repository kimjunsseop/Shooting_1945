using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner instance = null;
    public GameObject[] monsters;
    public int interval;
    public GameObject boss;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
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

    public void BossSpawn()
    {
        if(boss != null)
        {
            Instantiate(boss, transform.position, Quaternion.identity);
        }
        Debug.Log("보스 생성");
    }
}
