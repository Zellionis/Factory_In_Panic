using Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative;
using Com.IsartDigital.FactoryPanic.Sound;
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
    private int imatricule = -3;
    private bool isGood = false;
    private Cleaner triggeredVaccum = default;
    


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
        if (!NarrationManager.textShowedStatic) {
            SoundManager.Instance.PlayGrab();
            Cursor.SetCursor(cursor3, Vector2.zero, CursorMode.ForceSoftware);
            isDragging = true;
            TempPos = transform.position;
            gameObject.GetComponent<Robot>().StopText();
        }
    }

    private void OnMouseUp()
    {
        Cursor.SetCursor(cursor1, Vector2.zero, CursorMode.ForceSoftware);
        isDragging = false;
        transform.position = TempPos;
        if (imatricule != -3)
        {
            if (isGood) triggeredVaccum?.PlayYesParticle();
            else triggeredVaccum?.PlayNoParticle();

            _factory.Sorter(isGood,imatricule);
        }
    }

    private void Start()
    {
        Cursor.SetCursor(cursor1, Vector2.zero, CursorMode.ForceSoftware);
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

    public void HitCleaner(Factory fact, int index,bool choices,Cleaner vaccum)
    {
        _factory = fact;
        imatricule = index;
        isGood = choices;
        triggeredVaccum = vaccum;
    }

}
