using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
     public ClassRobot Type;

     [SerializeField] private Factory _factory=default;
     [SerializeField] private Animator _animator=default;
     [SerializeField] private Animator _animatorPanel=default;
     [SerializeField] private Animator _animatorTube=default;
     [SerializeField] private List<ParticleSystem> yesEffect=default;
     [SerializeField] private List<ParticleSystem> noEffect =default;


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
                    {
                        drag.HitCleaner(_factory, rob.Imatricule, true,this);
                        
                    }
                    else { 
                        drag.HitCleaner(_factory, rob.Imatricule, false,this);
                        
                    }
                    }
               }
          }
     }

    public void PlayYesParticle()
    {
        _animatorTube.SetTrigger("Triggered");
        _animator.SetTrigger("True");
        _animatorPanel.SetTrigger("True");
        for (int i = 0; i < yesEffect.Count; i++)
        {
            yesEffect[i].Play();
        }
    }
    public void PlayNoParticle()
    {
        _animator.SetTrigger("Wrong");
        _animatorPanel.SetTrigger("Wrong");
        for (int i = 0; i < noEffect.Count; i++)
        {
            noEffect[i].Play();
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
                              drag.HitCleaner(_factory, -3, true,this);
                    }
               }
          }
     }
     
}
