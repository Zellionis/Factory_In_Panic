using System;
using Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Start is called before the first frame update
    public int Imatricule = 4;
    public bool sortable = false;
    private float TimeLerp = 0;
    [SerializeField] private NarrativeRobotBank bank;
    [SerializeField] private TextMesh robotText = default;
    private ClassRobot body = default;
    private ClassRobot personality = new ClassRobot();
    private DialogueData dialogue = default;
    private Coroutine currentCoroutine = default;

    public void SetClassRobot(ClassRobot newBody, ClassRobot newPersonality)
    {
        body = newBody;
        personality = newPersonality;
        dialogue = bank.GetRandomLine(newBody, newPersonality);
    }

    public void StartText()
    {
        robotText.gameObject.SetActive(true);
        currentCoroutine = StartCoroutine(SlowText());
    }

    public void StopText()
    {
        robotText.gameObject.SetActive(false);
        StopCoroutine(currentCoroutine);
        currentCoroutine = default;
    }

    private IEnumerator SlowText()
    {
        robotText.text = "";
        foreach (char letter in dialogue.text.ToCharArray())
        {
            robotText.text += letter;
            yield return new WaitForSeconds(dialogue.speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cleaner")
            sortable = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.tag == "Cleaner")
            sortable = false;
    }

    public ClassRobot GetPersonality()
    {
        return personality;
    }
    
}
public enum ClassRobot
{
    Artiste,
    Cuisto,
    Banquier,
    Sportif,

}
