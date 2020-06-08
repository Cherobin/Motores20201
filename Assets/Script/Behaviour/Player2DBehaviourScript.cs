using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DBehaviourScript : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");


        animator.SetFloat("Horizontal", moveHorizontal);
        animator.SetFloat("Vertical", moveVertical);


        if (!isEqual(moveHorizontal, 0) || !isEqual(moveVertical, 0))
        {
            animator.speed = 0.7f;
        }
        else {
            animator.speed = 0.0f;
        }

     /*  if (!isEqual(moveHorizontal, 0) || !isEqual(moveVertical, 0))
       {
           animator.speed = 0.7f;
       }

       if (moveHorizontal > 0)
       {
           animator.SetBool("rigth", true);
       }
       else if (moveHorizontal < 0)
       {
           animator.SetBool("left", true);
       }
       else if (moveVertical > 0)
       {
           animator.SetBool("up", true);
       }
       else if (moveVertical < 0)
       {
           animator.SetBool("down", true); 
       }
       else
       {
           animator.SetBool("rigth", false);
           animator.SetBool("left", false);
           animator.SetBool("down", false);
           animator.SetBool("up", false);
           animator.speed = 0;
       }
       */

    }

    bool isEqual(float a, float b)
    {
        if (a >= b - Mathf.Epsilon && a <= b + Mathf.Epsilon)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
