using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropTiles : MonoBehaviour
{

    [SerializeField]
    private Transform tileSocket;

    private Vector2 initialPosition;

    private float deltaX, deltaY;

    public static bool locked;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        var position = transform.position;
                        deltaX = touchPos.x - position.x;
                        deltaY = touchPos.y - position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - tileSocket.position.x) <= 1f &&
                        Mathf.Abs(transform.position.y - tileSocket.position.y) <= 1f)
                    {
                        transform.position = new Vector2(tileSocket.position.x, tileSocket.position.y);
                        // locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
        }
    }
}
