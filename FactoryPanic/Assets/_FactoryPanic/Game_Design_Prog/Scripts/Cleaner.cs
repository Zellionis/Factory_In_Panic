using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
     public ClassRobot Type;

     [SerializeField] private Factory _factory;
     
     private void OnTriggerStay2D(Collider2D other)
     {
          if (other.tag == "Robot")
          {
               DragAndDrop drag = other.gameObject.GetComponent<DragAndDrop>();
               if (drag && drag.IsDragging())
               {
                    Robot rob = other.gameObject.GetComponent<Robot>();
                    if (rob)
                    {
                         if (Type == rob.GetPersonality())
                              _factory.Sorter(true);
                         else
                              _factory.Sorter(false);
                    }
                    
               }
          }
     }
}
