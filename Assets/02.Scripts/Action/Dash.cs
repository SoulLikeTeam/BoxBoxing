using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PlayerAction
{

    [SerializeField] private float dashPower;

    private int leftDashCount, rightDashCount;

    public override void Action()
    {
    }

    public override void Action(float value)
    {
    }

    public void Action(KeyCode key)
    {

        if(key == KeyCode.A)
        {

            StopAllCoroutines();

            leftDashCount++;
            rightDashCount = 0;

            if(leftDashCount >= 2)
            {

                leftDashCount = 0;
                rightDashCount = 0;
                playerRigid.AddForce(Vector2.left * dashPower, ForceMode2D.Impulse);
                StopAllCoroutines();

            }

            StartCoroutine(ResetDashCountCo());

        }
        else if(key == KeyCode.D)
        {

            StopAllCoroutines();

            rightDashCount++;
            leftDashCount = 0;

            if(rightDashCount >= 2)
            {

                leftDashCount = 0;
                rightDashCount = 0;
                playerRigid.AddForce(Vector2.right * dashPower, ForceMode2D.Impulse);
                StopAllCoroutines();

            }

            StartCoroutine(ResetDashCountCo());

        }

    }

    IEnumerator ResetDashCountCo()
    {

        yield return new WaitForSeconds(0.25f);
        leftDashCount = 0;
        rightDashCount = 0;

    }

}
