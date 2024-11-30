using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject cloudparticles_prefab;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Birds bird = collision.collider.GetComponent<Birds>();
        
        // check for  collision with the bird
        if (bird != null)
        {
            Instantiate(cloudparticles_prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // check for  collision with the enemy

        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if(enemy != null)
        {
            return;
        }


        if( collision.contacts[0].normal.y  < -0.1)
        {
            Instantiate(cloudparticles_prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
