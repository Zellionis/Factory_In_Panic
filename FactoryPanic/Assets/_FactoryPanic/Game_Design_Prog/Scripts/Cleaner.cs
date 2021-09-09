using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
     public ClassRobot Type;

     [SerializeField] private Factory _factory;


     private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.tag == "Robot")
          {
               DragAndDrop drag = other.gameObject.GetComponent<DragAndDrop>();
               if (drag)
               {
                    Robot rob = other.gameObject.GetComponent<Robot>();
                    if (rob)
                    {
                         if (Type == rob.GetPersonality())
                              drag.HitCleaner(_factory, rob.Imatricule, true);
                         else
                              drag.HitCleaner(_factory, rob.Imatricule, false);
                    }
               }
          }
     }

     private void OnTriggerExit2D(Collider2D other)
     {
          if (other.tag == "Robot")
          {
               DragAndDrop drag = other.gameObject.GetComponent<DragAndDrop>();
               if (drag)
               {
                    Robot rob = other.gameObject.GetComponent<Robot>();
                    if (rob)
                    {
                         if (Type == rob.GetPersonality())
                              drag.HitCleaner(_factory, -3, true);
                    }
               }
          }
     }
     
}
