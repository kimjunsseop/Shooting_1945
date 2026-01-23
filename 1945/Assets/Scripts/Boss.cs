using Unity.VisualScripting;
using UnityEngine;

public class Boss : Monster
{
    public Transform target;
    void Start()
    {
        // Vector3.Lerp(transform.position,new Vector3(0,1.6f,0), 1.5f);
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, target.position, 0.001f);
    }
    public override void CreateBullet()
    {
        
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
    }
}
