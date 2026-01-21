using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    private float moveSpeed {get;set;}
    void Start()
    {
        moveSpeed = 2f;
        animator = GetComponent<Animator>();    
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        SetAnim(h,v);

        transform.Translate(new Vector3(h,v,0) * moveSpeed * Time.deltaTime);
    }

    void SetAnim(float h, float v)
    {
        if(h == 0 && v == 0)
        {
            animator.SetBool("isStop", true);
        }
        else
        {
            animator.SetBool("isStop", false);
            animator.SetInteger("hMove",(int)h);
            animator.SetInteger("vMove",(int)v);
        }
    }
}
