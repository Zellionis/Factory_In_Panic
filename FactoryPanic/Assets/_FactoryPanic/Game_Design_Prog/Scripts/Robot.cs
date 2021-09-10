using System;
using Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Robot : MonoBehaviour
{
    // Start is called before the first frame update
    public int Imatricule = 4;
    public bool sortable = false;
    private float TimeLerp = 0;
    [SerializeField] private NarrativeRobotBank bank;
    [SerializeField] private TextMeshPro robotText = default;
    [SerializeField] private GameObject robotBox = default;
    [SerializeField] private GameObject bgBox = default;
    [SerializeField] private TextMeshPro robotText2 = default;
    [SerializeField] private GameObject robotBox2 = default;
    [SerializeField] private GameObject bgBox2 = default;
    private ClassRobot body = default;
    private ClassRobot personality = new ClassRobot();
    private DialogueData dialogue = default;
    private Coroutine currentCoroutine = default;
    private bool lockCoroutine = false;

    private TextMeshPro currentText = default;
    private GameObject currentBox = default;
    private GameObject currentBgBox = default;

    private static bool down = true;

    public void SetClassRobot(ClassRobot newBody, ClassRobot newPersonality)
    {
        body = newBody;
        personality = newPersonality;
        dialogue = bank.GetRandomLine(newBody, newPersonality);
    }

    public void StartText(bool box)
    {
        if (!lockCoroutine)
        {
            currentBox.SetActive(true);
            currentBgBox.SetActive(box);
            currentCoroutine = StartCoroutine(SlowText());
            lockCoroutine = true;
        }
    }

    public void SetBox()
    {
        if (down)
        {
            currentBgBox = bgBox;
            currentBox = robotBox;
            currentText = robotText;
        }
        else
        {
            currentBgBox = bgBox2;
            currentBox = robotBox2;
            currentText = robotText2;
        }
        down = !down;
    }

    public void StopText()
    {
        Debug.Log("StopText");
        currentBox.SetActive(false);
        if (currentCoroutine!=null)StopCoroutine(currentCoroutine);
        currentCoroutine = default;
    }

    private IEnumerator SlowText()
    {
        currentText.text = "";
        foreach (char letter in dialogue.text.ToCharArray())
        {
            currentText.text += letter;
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
    
    public ClassRobot GetBody()
    {
        return body;
    }
}
public enum ClassRobot
{
    Artiste,
    Cuisto,
    Banquier,
    Sportif,

}
