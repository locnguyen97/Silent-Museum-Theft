using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int curentPos = 0;

    public bool isMoving = false;
    bool isNeedMove = false;
    private Transform target;
    float speed = 1f;
    private int cacheIndex = 0;
    private Vector3 dir;
    public void MoveToPos(Transform pos,int index)
    {
        dir = pos.position - transform.position  ;
        target = pos;
        isNeedMove = true;
        cacheIndex = index;
    }

    private void Update()
    {
        if (isNeedMove)
        {
            transform.position += dir * speed * Time.deltaTime;
            if (Vector2.Distance(transform.position, target.position) <= 0.1f)
            {
                isMoving = false;
                isNeedMove = false;
                curentPos = cacheIndex;
                cacheIndex = 0;
            }
        }
    }
}
