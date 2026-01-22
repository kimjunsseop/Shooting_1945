using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Hp {get;set;}
    public float Speed {get;set;}
    public float Delay {get;set;}
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    void Start()
    {
        Hp = 3;
        Speed = 1f;
        Delay = 0.5f;
        Invoke("CreateBullet", Delay);
    }
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);
        Invoke("CreateBullet", Delay);
    }
    public void Damege(int attack)
    {
        Hp -= attack;
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
