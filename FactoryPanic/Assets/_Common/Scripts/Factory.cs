using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    // Start is called before the first frame update
    private int countGoodRob = 0;

    [SerializeField] private int NumRob = 0;

    [SerializeField] private float SpeedCarpet = 0.0f;

    [SerializeField]
    Vector2 StartCarpet = Vector2.zero;
    
    [SerializeField]
    Vector2 Quart1Carpet = Vector2.zero;
    
    [SerializeField]
    Vector2 Quart2Carpet = Vector2.zero;
    
    [SerializeField]
    Vector2 EndCarpet = Vector2.zero;
    
    [SerializeField]
    Vector2 Spawn = Vector2.zero;

    [SerializeField] 
    private float timeStopCarpet = 0.0f;
    
    private float CurrentTimeStop = 0.0f;
    
    private bool StopCarpet = false;
    
    private float TimeLerp = 0;
    
    List<GameObject> ListRobots = new List<GameObject>();
    
    [SerializeField] 
    List<GameObject> ListType = new List<GameObject>();
    
    void Start()
    {
        CreateRobot();
        for (int i = 0; i < 3; i++)
        {
            Robot rob = ListRobots[i].GetComponent<Robot>();
            if (rob)
            {
                rob.Imatricule = i+1;
            }
        }

        ListRobots[0].transform.position = Quart1Carpet;
        ListRobots[1].transform.position = Quart2Carpet;
        ListRobots[2].transform.position = EndCarpet;
    }

    // Update is called once per frame
    void Update()
    {
        if (StopCarpet)
        {
            CurrentTimeStop += Time.deltaTime;
            if (timeStopCarpet <= CurrentTimeStop)
            {
                CurrentTimeStop = 0;
                StopCarpet = false;
                for (int i = 0; i < 4; i++)
                {
                    Robot rob = ListRobots[i].GetComponent<Robot>();
                    if (rob)
                    {
                        rob.Imatricule -= 1;
                        if (rob.Imatricule == -1)
                            ListRobots[4].GetComponent<Robot>().Imatricule = 3;
                    }
                } 
                
                
            }
            TimeLerp = 0;
        }
        else
            MoveCarpet();
    }

    void CreateRobot()
    {
        for (int i = 0; i < NumRob; i++)
        {
            GameObject rob = Instantiate(ListType[0]); 
            
            rob.transform.position = Spawn;
            
            ListRobots.Add(rob);
        }
    }

    void MoveCarpet()
    {
        if (ListRobots.Count > 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i >= ListRobots.Count)
                    break;
                Robot rob = ListRobots[i].GetComponent<Robot>();

                if (rob)
                {
                    TimeLerp += SpeedCarpet;

                    if (TimeLerp > 1.0)
                        TimeLerp = 1.0f;
                    
                    if (rob.Imatricule == 0)
                    { 
                        ListRobots[i].transform.position = Vector2.Lerp(Quart1Carpet,StartCarpet, TimeLerp);
                    }
                    
                    else if (rob.Imatricule == 1)
                    { 
                        ListRobots[i].transform.position = Vector2.Lerp(Quart2Carpet, Quart1Carpet, TimeLerp);
                    }
                    else if (rob.Imatricule == 2) 
                    { 
                        ListRobots[i].transform.position = Vector2.Lerp(EndCarpet, Quart2Carpet, TimeLerp);
                    }
                    else if (rob.Imatricule == 3)
                    { 
                        ListRobots[i].transform.position = Vector2.Lerp(Spawn, EndCarpet, TimeLerp);
                    }

                    if (TimeLerp == 1.0f)
                        StopCarpet = true;
                }
            }
        }
    }
}
