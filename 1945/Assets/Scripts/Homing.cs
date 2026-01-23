using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject player;
    Vector2 dir;
    Vector2 dirNo;
    public int Speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dir = (player.transform.position - transform.position).normalized;
    }
    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
