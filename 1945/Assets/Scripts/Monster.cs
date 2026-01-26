using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    [field:SerializeField] public int Hp {get;set;}
    [field:SerializeField] public float Speed {get;set;}
    [field:SerializeField] public float Delay {get;set;}
    [field:SerializeField] public int Score {get;set;}
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    [field:SerializeField] public GameObject item;
    [field:SerializeField] public GameObject effect;
    void Start()
    {
        Invoke("CreateBullet", Delay);
    }
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if(transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }
    public virtual void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);
        Invoke("CreateBullet", Delay);
    }
    public virtual void Damege(int attack)
    {
        Hp -= attack;
        if(Hp <= 0)
        {
            if(item != null)
            {
                int rand = UnityEngine.Random.Range(0,101);
                if(rand <= 40)
                {
                    Instantiate(item, transform.position, Quaternion.identity);   
                }   
            }
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(go, 1f);
            GameManager.instance.AddScore(Score);
            Destroy(gameObject);
        }
    }


}
