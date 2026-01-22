using UnityEngine;

public class PBullet : MonoBehaviour
{

    private float Speed {get;set;}

    void Start()
    {
        Speed = 5f;
    }
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            Monster mon = collision.gameObject.GetComponent<Monster>();
            mon.Damege(1);
            Destroy(gameObject);

        }
    }
}
