using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator CharAnimator;
    // Start is called before the first frame update
    void Start()
    {
        CharAnimator = GetComponent<Animator>();
    }

    void AttackNow(){
        CharAnimator.SetTrigger("Attacking");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            print("Spaci Kepencet!");
            AttackNow();
        }
    }
}
