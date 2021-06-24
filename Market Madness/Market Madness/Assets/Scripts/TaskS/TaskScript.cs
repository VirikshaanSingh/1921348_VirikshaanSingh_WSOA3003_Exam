using UnityEngine;

public class TaskScript : MonoBehaviour
{
    Vector3 mouseOffset;
    public 
    
    Vector3 MousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    void OnMouseDown()
    {
        mouseOffset = transform.position - MousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = mouseOffset + MousePosition();
    }

}
