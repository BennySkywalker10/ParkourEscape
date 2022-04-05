using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;
    

    [SerializeField] Rigidbody2D rb;

    private void Update()
    {
        tap = swipeLeft = swipeRight = false;

        //Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }

        //Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Vector2 endTouch = Input.GetTouch(0).position;
                
                Vector2 swipe = new Vector2(endTouch.x - startTouch.x, endTouch.y - startTouch.y);
                
                if(swipe.magnitude < 0.17f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 15f);
                    //jump

                }
                else
                {

                    isDragging = false;
                    Reset();
                }
                
            }
        }

        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if(swipeDelta.magnitude > 125)
        {
            //Which Direction?
            float x = swipeDelta.x;
            //float y = swipeDelta.y;
            //if(Mathf.Abs(x) > Mathf.Abs(y))
            //{
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }

                Reset();

            //}
        }
    }

    void FixedUpdate ()
    { 
    }

    private void Reset()
    {
       // startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
}
