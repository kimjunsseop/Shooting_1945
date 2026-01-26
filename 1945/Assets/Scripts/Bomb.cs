using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 1.5f;
    public int damage = 1;
    public LayerMask hitLayers = Physics2D.DefaultRaycastLayers;
    void Start()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, hitLayers);
        var damaged = new HashSet<Monster>();
        foreach (var hit in hits)
        {
            if(hit == null) continue;
            Monster monster = hit.GetComponent<Monster>();
            if(monster != null && !damaged.Contains(monster))
            {
                monster.Damege(damage);
                damaged.Add(monster);
            }
        }
        Destroy(gameObject, 3f);
    }
    private void OawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, explosionRadius);       
    }

    void Update()
    {
        
    }
}
