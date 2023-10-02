using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostMove : MonoBehaviour
{
    public bool isLastPoint;
    public int indexPoint;
    public List<int> listCanMove = new List<int>();
    private void OnMouseDown()
    {
        if (GameManager.Instance.CheckAndMove(indexPoint))
        {
            Invoke(nameof(OnPlayerGoTo),0.5f);
        }
    }

    public void OnPlayerGoTo()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (isLastPoint)
        {
            GameManager.Instance.CheckLevelUp();
            return;
        }
        
    }
}
