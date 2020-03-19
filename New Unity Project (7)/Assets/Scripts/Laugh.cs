using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laugh : MonoBehaviour
{
    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("is_laughing", true);
    }

    // Update is called once per frame
    public void SelfDestroy()
    {
        Destroy(this);
    }
}
