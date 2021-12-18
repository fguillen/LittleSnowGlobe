using UnityEngine;

// From: http://answers.unity.com/answers/42201/view.html
public class DraggableController : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    Rigidbody rb;
    bool dragging = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void FixedUpdate()
    {
        if(dragging)
            MoveTowardsCursor();
    }

    void MoveTowardsCursor()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        rb.velocity = (curPosition - transform.position) * 10;
    }
}
