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
        Sprite[] sprites = new Sprite[6];
        int randType = UnityEngine.Random.Range(0, 3);
        int randPart = UnityEngine.Random.Range(0, 3);
        
        if (body == ClassRobot.Artiste)
        { 
            if (randType == 0) 
                sprites = Artiste1;
            else if (randType == 1)
                sprites = Artiste2;
            else if (randType == 2)
                sprites = Artiste3;
        }

        else if (body == ClassRobot.Banquier)
        {
            if (randType == 0)
                sprites = Banquier1;
            else if (randType == 1) 
                sprites = Banquier2;
            else if (randType == 2) 
                sprites = Banquier3;
        }

        else if (body == ClassRobot.Cuisto)
        {
            if (randType == 0)
                sprites = Cuisto1;
            else if (randType == 1)
                sprites = Cuisto2;
            else if (randType == 2)
                sprites = Cuisto3;
        }

        else if (body == ClassRobot.Sportif)
        {
            if (randType == 0)
                sprites = Sportif1;
            else if (randType == 1)
                sprites = Sportif2;
            else if (randType == 2)
                sprites = Sportif3;
        }
        
        
    }

    public void TypeRobot(GameObject rob, ClassRobot personality)
    {
        int rand = UnityEngine.Random.Range(0, 3);
        int count = 0;

        Sprite[] sprites = new Sprite[6];
        {
            if (personality == ClassRobot.Artiste)
            {
                if (rand == 0)
                    sprites = Artiste1;
                else if (rand == 1)
                    sprites = Artiste2;
                else if (rand == 2)
                    sprites = Artiste3;
            }

            else if (personality == ClassRobot.Banquier)
            {
                if (rand == 0)
                    sprites = Banquier1;
                else if (rand == 1)
                    sprites = Banquier2;
                else if (rand == 2)
                    sprites = Banquier3;
            }

            else if (personality == ClassRobot.Cuisto)
            {
                if (rand == 0)
                    sprites = Cuisto1;
                else if (rand == 1)
                    sprites = Cuisto2;
                else if (rand == 2)
                    sprites = Cuisto3;
            }

            else if (personality == ClassRobot.Sportif)
            {
                if (rand == 0)
                    sprites = Sportif1;
                else if (rand == 1)
                    sprites = Sportif2;
                else if (rand == 2)
                    sprites = Sportif3;
            }
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
                    sr.sprite = sprites[1];
                    count++;

                }    
                
                else if (rig.GetChild(i).name == "Pieds")
                {
                    sr.sprite = sprites[2];

                    count++;

                }
                
                else if (rig.GetChild(i).name == "Pieds2")
                {
                    sr.sprite = sprites[3];

                    count++;

                }    
                
                else if (rig.GetChild(i).name == "Tete")
                {
                    sr.sprite = sprites[4];

                    count++;

                }    
                
                else if (rig.GetChild(i).name == "Torse")
                {
                    sr.sprite = sprites[5];

                    count++;
                }   
            }
            
        }


    }
    
}
