using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float swipeSpeed = 5f;
    private Vector2 touchStart;
    private bool isSwiping = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isSwiping = false;
            }
        }

        if (isSwiping)
        {
            Vector2 swipeDirection = (Vector2)Input.mousePosition - touchStart;


            if (swipeDirection.x > 0 && transform.position.x >= -23)
            {
                MoveCameraLeft();
            }
            else if (swipeDirection.x < 0 && transform.position.x <= 23)
            {
                MoveCameraRight();
            }
        }
    }

    void MoveCameraRight()
    {
        transform.Translate(Vector3.right * swipeSpeed * Time.deltaTime);
    }

    void MoveCameraLeft()
    {
        transform.Translate(Vector3.left * swipeSpeed * Time.deltaTime);
    }
}
