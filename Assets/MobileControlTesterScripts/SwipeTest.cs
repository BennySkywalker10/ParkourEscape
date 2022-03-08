using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public MobileControls swipeControls;
    public Transform player;
    private Vector2 desiredPosition;

    private void Start()
    {
        desiredPosition = player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (swipeControls.SwipeLeft)
        {
            desiredPosition += Vector2.left * 10;
        }
        if (swipeControls.SwipeRight)
        {
            desiredPosition += Vector2.right * 10;
        }
        desiredPosition.y = player.transform.position.y;
        //Debug.Log("desiredPosition="+desiredPosition+" position="+ player.transform.position);
        player.transform.position = Vector2.MoveTowards(player.transform.position, desiredPosition, 15f * Time.deltaTime);
    }
}
