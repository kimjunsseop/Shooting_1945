using UnityEngine;

public class Item : MonoBehaviour
{
    public float ItemVelocity {get;set;}
    Rigidbody2D rig = null;
    void Start()
    {
        ItemVelocity = 100f;
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }
    void Update()
    {
        
    }
}
