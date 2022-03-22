using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    //Player player;

    public float groundHeight;
    public float groundRight;
    public float screenRight;
    BoxCollider2D collider;

    bool didGenerateGround = false;

    private void Awake()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        collider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider.size.y / 2);
        screenRight = Camera.main.transform.position.x * 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Vector2 pos = transform.position;
        //pos.x -= player.velocity.x * Time.fixedDeltaTime;

        
        groundRight = transform.position.x + (collider.size.x / 2);

        if (groundRight < 0)
        {
            Destroy(gameObject);
        }
        if (!didGenerateGround)
        {
            if (groundRight < screenRight)
            {
                didGenerateGround = true;
                generateGround();
            }
        }

        //transform.position = pos;
    }

    void generateGround()
    {
        GameObject go = Instantiate(gameObject);
        //BoxCollider2D goCollider = go.GetComponent < BoxCollider2D();
        /*Vector2 pos;
        pos.x = screenRight + 30;
        pos.y = transform.position.y;
        go.transform.position = pos;*/
    }
}
