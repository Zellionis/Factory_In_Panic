using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDragging = false;
    private Vector2 TempPos = Vector2.zero;


    private void OnMouseDown()
    {

        isDragging = true;
        TempPos = transform.position;   
      
    }

    private void OnMouseUp()
    {
        isDragging = false;
        transform.position = TempPos;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }

    public bool IsDragging()
    {
        return isDragging;
    }
}
