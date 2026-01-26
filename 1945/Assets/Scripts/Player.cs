using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [field:SerializeField] private float moveSpeed {get;set;}
    [field:SerializeField] private int power {get;set;}
    public List<GameObject> bullets;
    public Transform pos = null;
    public GameObject powerUp;
    public GameObject bomb;
    void Start()
    {
        moveSpeed = 5f;
        animator = GetComponent<Animator>();  
        power = 0; 
    }

    
    void Update()
    {  
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        SetAnim(h,v);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullets[power], pos.position, Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(bomb, new Vector3(0,0,0), Quaternion.identity);
        }

        transform.Translate(new Vector3(h,v,0).normalized * moveSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos; 
    }

    void SetAnim(float h, float v)
    {
        if(h <= -0.5f)
        {
            animator.SetBool("left", true);
        }
        else
        {
            animator.SetBool("left", false);
        }

        if(h >= 0.5f)
        {
            animator.SetBool("right", true);
        }
        else
        {
            animator.SetBool("right", false);
        }

        if(v >= 0.5f)
        {
            animator.SetBool("up", true);
        }
        else
        {
            animator.SetBool("up", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            power += 1;
            if(power >= 3)
            {
                power = 3;
            }
            GameObject go = Instantiate(powerUp, transform.position, Quaternion.identity);
            Destroy(go, 0.7f);
            Destroy(collision.gameObject);
        }      
    }
    public void TakeDamage(int damage)
    {
        Debug.Log($"{damage} 맞음");
    }
}
