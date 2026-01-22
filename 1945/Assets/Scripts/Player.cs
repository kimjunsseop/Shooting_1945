using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    private float moveSpeed {get;set;}
    public GameObject bullet;
    public Transform pos = null;
    void Start()
    {
        moveSpeed = 5f;
        animator = GetComponent<Animator>();   
    }

    
    void Update()
    {  
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        SetAnim(h,v);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, pos.position, Quaternion.identity);
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

    
}
