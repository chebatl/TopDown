using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialogue", menuName ="SOs/Dialogue")]
public class DialogueSettings : ScriptableObject{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;
    public List<Sentences> sentences = new List<Sentences>();
}

[System.Serializable]
public class Sentences{
    public string actorName;
    public Sprite profile;
    public Languages languages;
}

[System.Serializable]
public class Languages{
    public string portugues;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DialogueSettings ds = (DialogueSettings)target;
        Languages languages = new Languages();
        languages.portugues = ds.sentence;
        Sentences sentences = new Sentences();
        sentences.profile = ds.speakerSprite;
        sentences.languages = languages;

        if(GUILayout.Button("Create Dialogue")){
            if(ds.sentence != ""){
                ds.sentences.Add(sentences);
                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}
#endif