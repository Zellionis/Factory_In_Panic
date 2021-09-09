using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
public class RobotGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Sprite[] Cuisto1 = new Sprite[6];
    [SerializeField] Sprite[] Cuisto2 = new Sprite[6];
    [SerializeField] Sprite[] Cuisto3 = new Sprite[6];
    [SerializeField] Sprite[] Sportif1 = new Sprite[6];
    [SerializeField] Sprite[] Sportif2 = new Sprite[6];
    [SerializeField] Sprite[] Sportif3 = new Sprite[6];
    [SerializeField] Sprite[] Banquier1 = new Sprite[6];
    [SerializeField] Sprite[] Banquier2 = new Sprite[6];
    [SerializeField] Sprite[] Banquier3 = new Sprite[6];
    [SerializeField] Sprite[] Artiste1 = new Sprite[6];
    [SerializeField] Sprite[] Artiste2 = new Sprite[6];
    [SerializeField] Sprite[] Artiste3 = new Sprite[6];
    
    
    public void RandomRobot(GameObject rob, ClassRobot personality, ClassRobot body)
    {
        TypeRobot(rob, personality);
        Sprite[] sprite = new Sprite[6];
        
        if (body == ClassRobot.Artiste)
        {
            
        }

        else if (body == ClassRobot.Banquier)
        {
            
        }
        
        else if (body == ClassRobot.Cuisto)
        { 
          
        }
        
        else if (body == ClassRobot.Sportif)
        {
            
        }
    }

    public void TypeRobot(GameObject rob, ClassRobot personality)
    {
        int rand = UnityEngine.Random.Range(0, 3);
        int count = 0;

        Sprite[] sprites = new Sprite[6];
        
        if (personality == ClassRobot.Artiste)
        {
            sprites = Cuisto1;
        }

        else if (personality == ClassRobot.Banquier)
        {
            
        }
        
        else if (personality == ClassRobot.Cuisto)
        {

            //RandomType(rand, Cuistos, sprites);
        }
        
        else if (personality == ClassRobot.Sportif)
        {
            
        }
        
        Transform rig =  rob.transform.Find("Squelette");
        if (rig)
        {
            for (int i = 0; i < rig.transform.childCount; i++)
            {
                if (count == 6)
                    break;

                SpriteRenderer sr = rig.GetChild(i).GetComponent<SpriteRenderer>();
                if (!sr)
                    break;

                if (rig.GetChild(i).name == "Bras")
                {
                   sr.sprite = sprites[0];
                    count++;
                }    
                
                else if (rig.GetChild(i).name == "Bras2")
                {
                    //sr.sprite = ;

                    count++;

                }    
                
                else if (rig.GetChild(i).name == "Pieds")
                {
                    //sr.sprite = ;

                    count++;

                }
                
                else if (rig.GetChild(i).name == "Pieds2")
                {
                    //sr.sprite = ;

                    count++;

                }    
                
                else if (rig.GetChild(i).name == "Tete")
                {
                    //sr.sprite = ;

                    count++;

                }    
                
                else if (rig.GetChild(i).name == "Torse")
                {
                    //sr.sprite = ;

                    count++;
                }   
            }
            
        }


    }
    
}
