using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedCube : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ActivateCubeTransition(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ActivateCubeTransition(true);
        }
    }

    private void ActivateCubeTransition(bool p_isActivated) 
    {
        animator.SetBool("TransitionOn", p_isActivated);    
    }



}
