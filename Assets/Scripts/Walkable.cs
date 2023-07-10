using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkable : MonoBehaviour
{
    public List<GamePath> possiblePaths = new List<GamePath>();
    [Space] public Transform previousBlock;

    [Header("Booleans")] public bool isStair = false;
    public bool movingGround = false;
    public bool isButton;
    public bool dontRotate;
    [Space] [Header("Offsets")] public float walkPointOffset = 1f;
    float stairOffset = 1f;


    public Vector3 GetWalkPoint()
    {
        float stair = isStair ? stairOffset : 0;
        return transform.position + transform.up * walkPointOffset - transform.up * stair;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(GetWalkPoint(), .2f);
    }
}

[System.Serializable]
public class GamePath
{
    public Transform target;
    public bool active = true;
}