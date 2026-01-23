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
    }
    public virtual void CreateBullet()
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

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
