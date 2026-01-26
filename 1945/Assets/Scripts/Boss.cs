using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.WSA;

public class Boss : Monster
{
    private bool isReady = true;
    public float moveSpeed = 1.5f;
    public Vector3 tar = new Vector3(0,1.5f,0);
    void OEnable()
    {
        isReady = true;
    }
    void Start()
    {
        StartCoroutine((Enter()));
    }

    IEnumerator Enter()
    {
        while(Vector3.Distance(transform.position, tar) > 0.01f)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, tar, 0.001f);   
            yield return null;
        }
        isReady = true;
    }

    
    void Update()
    {

    }
    void LateUpdate()
    {
        Vector3 newPos = Camera.main.WorldToViewportPoint(transform.position);
        newPos.x = Mathf.Clamp01(newPos.x);
        newPos.y = Mathf.Clamp01(newPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(newPos);
    }
    public override void CreateBullet()
    {
        
    }

    public override void Damege(int attack)
    {
        Hp -= attack;
        if(Hp <= 0)
        {
            if(item != null)
            {
                Instantiate(item, transform.position, Quaternion.identity);   
            }
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(go, 1f);
            GameManager.instance.AddScore(Score);
            Destroy(gameObject);
        }
    }

    IEnumerator Wave()
    {
        isReady = false;
        for(int i = 0; i <= 20; i++)
        {
            Instantiate(bullet, ms1.transform.position, Quaternion.Euler(0, 0, 100 + (i * 8)));
            Instantiate(bullet, ms2.transform.position, Quaternion.Euler(0, 0, 260 - (i * 8)));
            yield return new WaitForSeconds(0.05f);
        }
        isReady = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PBullet"))
        {
            if(isReady)
            {
                StartCoroutine(Move());
                StartCoroutine(Wave());   
            }
        }
    }
    IEnumerator Move()
    {
        float randX = Random.Range(-2f, 2f);
        float randY = Random.Range(-2f, 2f);
        float duration = 1.5f;
        float time = 0;
        while(time < duration)
        {
            transform.Translate(new Vector3(randX, randY, 0) * moveSpeed * Time.deltaTime);    
            time += Time.deltaTime;
            yield return null;
        }   
    }
    void OnBecameInvisible()
    {
    }
}
