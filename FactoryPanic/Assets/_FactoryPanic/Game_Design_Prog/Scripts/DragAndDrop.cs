using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDragging = false;
    private Vector2 TempPos = Vector2.zero;
    
    [SerializeField] private Texture2D cursor1;
    [SerializeField] private Texture2D cursor2;
    [SerializeField] private Texture2D cursor3;

    private Factory _factory = null;
    private int imatricule = -2;
    private bool isGood = false;
    


    private void OnMouseEnter()
    {
        if(!isDragging)
            Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.ForceSoftware);
        else
            Cursor.SetCursor(cursor3, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        if(!isDragging)
            Cursor.SetCursor(cursor1, Vector2.zero, CursorMode.ForceSoftware);
        else
            Cursor.SetCursor(cursor3, Vector2.zero, CursorMode.ForceSoftware);

    }

    private void OnMouseDown()
    {
        Cursor.SetCursor(cursor3, Vector2.zero, CursorMode.ForceSoftware);
        isDragging = true;
        TempPos = transform.position;   
      
    }

    private void OnMouseUp()
    {
        Cursor.SetCursor(cursor1, Vector2.zero, CursorMode.ForceSoftware);
        isDragging = false;
        transform.position = TempPos;
        if (imatricule != -2)
        {
            _factory.Sorter(isGood,imatricule);
        }
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

    public void SetTempPos(Vector2 vec2)
    {
        TempPos = vec2;
    }

    public void HitCleaner(Factory fact, int index,bool choices)
    {
        _factory = fact;
        imatricule = index;
        isGood = choices;
    }
}
