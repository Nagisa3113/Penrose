using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player;
    public List<PathCondition> pathConditions = new List<PathCondition>();
    public List<Transform> pivots;

    public Transform[] objectsToHide;

    private void Awake()
    {
        instance = this;
    }
}

[System.Serializable]
public class PathCondition
{
    public string pathConditionName;
    public List<Condition> conditions;
    public List<SinglePath> paths;
}

[System.Serializable]
public class Condition
{
    public Transform conditionObject;
    public Vector3 eulerAngle;
}

[System.Serializable]
public class SinglePath
{
    public Walkable block;
    public int index;
}