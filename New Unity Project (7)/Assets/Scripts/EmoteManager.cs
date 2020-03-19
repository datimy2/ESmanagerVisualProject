using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteManager : MonoBehaviour
{
    [SerializeField]
    private GameObject laugh;
    private Player player;
    private int _emotestate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Emote()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _emotestate = player.getEmoteState();
        Vector3 pos = new Vector3(0,1f,0);

        if (_emotestate == 1)
        {
            Instantiate(laugh, player.transform.position + pos,Quaternion.identity);
        }
    }
    void DestroyEmote()
    {
        Laugh laugh =  GameObject.Find("Laugh").GetComponent<Laugh>();
        laugh.SelfDestroy();
            
    }
}
