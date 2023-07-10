using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PathPlanner : MonoBehaviour
{
    public Transform player;

    public List<Transform> paths;

    private void Awake()
    {
        foreach (var trans in transform.GetComponentsInChildren<Transform>())
        {
            paths.Add(trans);
        }
    }

    private bool isTop = true;

    void Start()
    {
        Sequence s = DOTween.Sequence();
        for (int i = 1; i <= paths.Count - 1; i++)
        {
            var curTrans = paths[i];
            float distance = Vector3.Distance(paths[i - 1].transform.position, paths[i].transform.position);
            float duration = distance * 0.1f;
            bool ii = paths[i].GetComponent<PathPoint>().changeLayer;

            if (i > 1 && paths[i - 1].GetComponent<PathPoint>().isTrans)
                duration = 0f;

            s.Append(player.transform.DOMove(paths[i].transform.position, duration)
                .OnComplete(() => { isTop = ii; })
                .SetEase(Ease.Linear));

            if (curTrans.gameObject.GetComponent<PathPoint>().isTrans == true)
            {
                s.Append(player.transform.DOMove(paths[i].GetComponent<PathPoint>().nextPos.position, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTop)
        {
            player.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Top");
        }
        else
        {
            player.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}