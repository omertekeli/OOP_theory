using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : Ball
{

    private void newStart()
    {
        base.Start();//Get rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        newDestroy();
    }

    public override void MoveToPlayer()
    {
        speed = 600.0f;
        base.MoveToPlayer();
    }

    public void newDestroy()
    {
        base.Destroy();
    }
}
