using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] float bounceforce;
    [SerializeField] float bounceRadius;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag == playerTag)
        {
            Rigidbody2D otherRB = collision.rigidbody;
            //otherRB.AddExplosionForce(bounceforce, collision.contacts[0].point, bounceRadius);
            //otherRB.AddExplosionForce(bounceforce, this.transform.position, 5);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
