using UnityEngine;

public class defalutBullet : MonoBehaviour
{
    public float Speed = 3;
    Vector3 dir;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
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
