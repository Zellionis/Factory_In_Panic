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
            if (i < ListRobots.Count)
            {
                Robot rob = ListRobots[i].GetComponent<Robot>();
                if (rob)
                {
                    rob.Imatricule = i+1;
                }
            }
        }
        
        if(ListRobots.Count == 1)
            ListRobots[0].transform.position = Quart1Carpet;
        if(ListRobots.Count == 2)
            ListRobots[1].transform.position = Quart2Carpet;
        if(ListRobots.Count == 3)
            ListRobots[2].transform.position = EndCarpet;
    }

    // Update is called once per frame
    void Update()
    {
        if (StopCarpet)
            PauseCarpet();
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
                        MovingAndDraging(Quart1Carpet,StartCarpet, i);
                    else if (rob.Imatricule == 1)
                        MovingAndDraging(Quart2Carpet, Quart1Carpet, i);
                    else if (rob.Imatricule == 2)
                        MovingAndDraging(EndCarpet, Quart2Carpet, i);
                    else if (rob.Imatricule == 3)
                        MovingAndDraging(Spawn, EndCarpet, i);

                    if (TimeLerp == 1.0f)
                        StopCarpet = true;
                }
            }
        }
    }

    void MovingAndDraging(Vector2 start, Vector2 end, int index)
    {
        DragAndDrop drag = ListRobots[index].GetComponent<DragAndDrop>();
        if (drag)
        {
            if (drag.IsDragging())
                drag.SetTempPos(Vector2.Lerp(start, end, TimeLerp));
                
            else
                ListRobots[index].transform.position = Vector2.Lerp(start, end, TimeLerp);
        }
    }

    void PauseCarpet()
    {
        CurrentTimeStop += Time.deltaTime;
        if (timeStopCarpet <= CurrentTimeStop)
        {
            CurrentTimeStop = 0;
            StopCarpet = false;
            for (int i = 0; i < 4; i++)
            {
                if (i < ListRobots.Count)
                {
                    Robot rob = ListRobots[i].GetComponent<Robot>();
                    if (rob)
                    {
                        rob.Imatricule -= 1;
                        if (rob.Imatricule == -1 && ListRobots.Count == 5)
                            ListRobots[4].GetComponent<Robot>().Imatricule = 3;
                    }
                }
            } 
                
                
        }
        TimeLerp = 0;
    }
}
