using Com.IsartDigital.FactoryPanic.GameDesignProg.Narrative;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Start is called before the first frame update
    public int Imatricule = 4;
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
}
public enum ClassRobot
{
    Artiste,
    Boulanger,
    Banquier,
    Sportif,

}
