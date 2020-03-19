using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    public ELEMENTS elements;
    public EmoteManager Emotes;
    private Player player;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;   
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void Say(string speech, string speaker)
    {
        StopSpeaking();
        speaking = StartCoroutine(Speaking(speech, speaker));

    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
            player.CanMove();
            speechPanel.SetActive(false);
        }
        speaking = null;

        
    }
    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector]public bool isWaitingForUserInput = false;
    Coroutine speaking = null;

    IEnumerator Speaking(string targetSpeech, string speaker = "") 
    {
        player.CanNotMove();
        Emotes.Emote();
        speechPanel.SetActive(true);
        speechText.text = "";
        speakerNameText.text = DetermineSpeaker(speaker);
        isWaitingForUserInput = false;

        while (speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }
        isWaitingForUserInput = true;
        while (isWaitingForUserInput)
        {
            yield return new WaitForEndOfFrame();
        }
        StopSpeaking();
    }
    string DetermineSpeaker(string s)
    {
        string retVal = speakerNameText.text;
        if (s != speakerNameText.text && s != "")
        {
            retVal = (s.ToLower().Contains("System")) ? "" : s;
        }
        return retVal;
    }
    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speechPanel;
        public Text speakerNameText;
        public Text speechText;
    }
    public GameObject speechPanel { get { return elements.speechPanel; } } 
    public Text speakerNameText { get { return elements.speakerNameText; } }
    public Text speechText { get { return elements.speechText; } }
}
