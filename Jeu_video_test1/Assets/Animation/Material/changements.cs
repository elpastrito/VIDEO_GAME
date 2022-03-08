using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public AnimatorOverrideController Run;
    public AnimatorOverrideController Walk;

    public void Running()
    {
        GetComponent<Animator>().runtimeAnimatorController = Run as RuntimeAnimatorController;
    }

    public void Walking()
    {
        GetComponent<Animator>().runtimeAnimatorController = Walk as RuntimeAnimatorController;
    }
}
