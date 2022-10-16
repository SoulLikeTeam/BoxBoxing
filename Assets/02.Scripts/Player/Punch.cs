using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punch : MonoBehaviour
{

    private bool isGuarding; //가드 하는중인가?
    private bool isPunching;
    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

        Controll();

    }

    private void Controll()
    {
        if (Input.GetMouseButtonDown(0) && isPunching == false)
        {

            int n = Random.Range(0, 2);
            isGuarding = false;
            isPunching = true;
            animator.SetTrigger("Punch");
            animator.SetInteger("PunchInt", n);

        }
        else if(isPunching == false && Input.GetMouseButtonDown(1) && isGuarding == false)
        {

            isGuarding = true;
            animator.SetTrigger("Guard");

        }

        if(Input.GetMouseButtonUp(1) && isGuarding == true && isPunching == false)
        {

            isGuarding = false;
            animator.SetTrigger("DeGuard");

        }

    }

    public void SetIsPunch()
    {

        isPunching = false;

    }

}
