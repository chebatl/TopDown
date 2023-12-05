using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogueSettings dialogue;
    private bool playerOnDialogueArea;
    private List<string> sentences = new List<string>();

    private void Start() {
        GetNPCInfo();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && playerOnDialogueArea){
            DialogueControl.INSTANCE.Speech(sentences.ToArray());
        }
    }

    private void FixedUpdate() {
        ShowDialogue();
    }

    private void GetNPCInfo(){
        for (int i = 0; i < dialogue.sentences.Count; i++)
        {
            switch(DialogueControl.INSTANCE.activeLang){
                case DialogueControl.Lang.PT:
                    sentences.Add(dialogue.sentences[i].languages.portugues);
                    break;
                case DialogueControl.Lang.EN:
                    sentences.Add(dialogue.sentences[i].languages.english);
                    break;
                case DialogueControl.Lang.ES:
                    sentences.Add(dialogue.sentences[i].languages.spanish);
                    break;
            }
        }
    }

    private void ShowDialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null){
            playerOnDialogueArea = true;
        }else{
            playerOnDialogueArea = false;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
