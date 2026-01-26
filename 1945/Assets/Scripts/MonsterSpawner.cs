using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner instance = null;
    public GameObject[] monsters;
    public int interval;
    public GameObject boss;
    public bool swi = true;
    public bool swi2 = true;
    public GameObject text;
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
        Invoke("Stop", 10);
    }
    void Update()
    {
        
    }
    void Stop()
    {
        swi = false;
        StartCoroutine(Spawn2());
        Invoke("Stop2", 20);
    }
    void Stop2()
    {
        swi2 = false;
        StartCoroutine(BS());
    }

    IEnumerator Spawn()
    {
        while(swi)
        {
            float rand = Random.Range(-2f,2f);

            Vector3 spawn = new Vector3(rand, transform.position.y, 0);
            Instantiate(monsters[0], spawn, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
    IEnumerator Spawn2()
    {
        while(swi2)
        {
            float rand = Random.Range(-2f,2f);
            Vector3 spawn = new Vector3(rand, transform.position.y, 0);
            Instantiate(monsters[1], spawn, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator BS()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(1f);
        text.SetActive(false);
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
