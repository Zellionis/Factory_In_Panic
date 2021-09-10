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
        Sprite[] spritesPerso = new Sprite[6];
        Sprite[] spritesBody = new Sprite[6];
        spritesPerso =  SelectType(personality);
        spritesBody =  SelectType(body);    

        int randPart = UnityEngine.Random.Range(0, 3);
        int randModify = UnityEngine.Random.Range(1, 3);
        
        if (randPart == 0)
        {
            spritesPerso[4] = spritesBody[4];
        }
            
        else if (randPart == 1)
        {
            spritesPerso[0] = spritesBody[0];
            spritesPerso[1] = spritesBody[1];
            spritesPerso[5] = spritesBody[5];
        }
            
        else
        {
            spritesPerso[2] = spritesBody[2];
            spritesPerso[3] = spritesBody[3];
        }

        if (randModify == 2)
        {
            int randPart2 = UnityEngine.Random.Range(0, 3);
            while(randPart == randPart2)
                randPart2 = UnityEngine.Random.Range(0, 3);
            
            if (randPart2 == 0)
            {
                spritesPerso[4] = spritesBody[4];
            }
            
            else if (randPart2 == 1)
            {
                spritesPerso[0] = spritesBody[0];
                spritesPerso[1] = spritesBody[1];
                spritesPerso[5] = spritesBody[5];

            }
            
            else
            {
                spritesPerso[2] = spritesBody[2];
                spritesPerso[3] = spritesBody[3];
            }
        }
        
        
        Transform rig =  rob.transform.Find("Squelette");
        ApplyTransform(rig, spritesPerso);
        
    }

    void ApplyTransform(Transform rig, Sprite[] sprites)
    {
        if (rig)
        {
            int count = 0;
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

    Sprite[] SelectType(ClassRobot cR)
    {
        Sprite[] sprites = new Sprite[6];

        int rand = UnityEngine.Random.Range(0, 3);

        if (cR == ClassRobot.Artiste)
        {
            if (rand == 0)
                sprites = Artiste1;
            else if (rand == 1)
                sprites = Artiste2;
            else if (rand == 2)
                sprites = Artiste3;
        }

        else if (cR == ClassRobot.Banquier)
        {
            if (rand == 0)
                sprites = Banquier1;
            else if (rand == 1)
                sprites = Banquier2;
            else if (rand == 2)
                sprites = Banquier3;
        }

        else if (cR == ClassRobot.Cuisto)
        {
            if (rand == 0)
                sprites = Cuisto1;
            else if (rand == 1)
                sprites = Cuisto2;
            else if (rand == 2)
                sprites = Cuisto3;
        }

        else if (cR == ClassRobot.Sportif)
        {
            if (rand == 0)
                sprites = Sportif1;
            else if (rand == 1)
                sprites = Sportif2;
            else if (rand == 2)
                sprites = Sportif3;
        }

        return sprites;
    }
    
    
}
