using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBall : Ball
{
    private void newStart()
    {
        base.Start(); //Get rigidbody
    }

    private void Update()
    {
        MoveToPlayer();
        newDestroy();
    }
    public override void MoveToPlayer()
    {
        speed = 200.0f;
        base.MoveToPlayer();
    }
    public void newDestroy()
    {
        base.Destroy();
    }
}
