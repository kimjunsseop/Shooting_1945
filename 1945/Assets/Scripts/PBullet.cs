using UnityEngine;

public class PBullet : MonoBehaviour
{

    [field:SerializeField] private float Speed {get;set;}
    [field:SerializeField] public int damage {get;set;}

    void Start()
    {

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
            //Monster mon = collision.gameObject.GetComponent<Monster>();
            //mon.Damege(1);
            //collision.gameObject.GetComponent<Monster>().Damege(1);
            collision.GetComponent<Monster>().Damege(damage);
            Destroy(gameObject);

        }
    }
}
