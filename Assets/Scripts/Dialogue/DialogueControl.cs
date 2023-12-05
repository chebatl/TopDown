using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum Lang{
        PT, EN, ES
    }
    public Lang activeLang;
    public static DialogueControl INSTANCE;
    [Header("Components")]
    public GameObject dialogueBox;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float textSpeed;
    private bool isDialogueBoxVisible;
    private int index;
    private string[] sentences;

    private void Awake() {
        INSTANCE = this;
    }

    IEnumerator TypeSentenceSpeed(){
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextSentence(){
        if(speechText.text == sentences[index]){
            if(index < sentences.Length -1){
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentenceSpeed());
            }else{
                speechText.text = "";
                index = 0;
                dialogueBox.SetActive(false);
                sentences = null;
                isDialogueBoxVisible = false;
            }
        }
    }
    
    public void Speech(string[] dialouge){
        if(!isDialogueBoxVisible){
            dialogueBox.SetActive(true);
            sentences = dialouge;
            StartCoroutine(TypeSentenceSpeed());
            isDialogueBoxVisible = true;
        }
    }
}
