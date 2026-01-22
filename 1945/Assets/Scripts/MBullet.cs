using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float Speed {get;set;}
    void Start()
    {
        Speed = 4f;
    }
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
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
