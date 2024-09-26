using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private List<Tween> activeTweens = new List<Tween>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int i = activeTweens.Count;

        for (i = i - 1; i >= 0; i--)
        {
            Tween tween = activeTweens[i];

            float distance = Vector3.Distance(tween.Target.position, tween.EndPos);

            if (distance > 0.1f)
            {
                float elapsed = Time.time - tween.StartTime;
                float fraction = elapsed / tween.Duration;

                tween.Target.position = Vector3.Lerp(tween.StartPos, tween.EndPos, fraction);
            }
            else
            {
                tween.Target.position = tween.EndPos;
                activeTweens.RemoveAt(i);

            }
        }
    }

    public bool TweenExists(Transform target)
    {
        foreach (Tween t in activeTweens)
        {
            if (t.Target == target) return true;
        }
        return false;
    }

    public bool AddTween(Transform target, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (!TweenExists(target))
        {
            Tween t = new Tween(target, startPos, endPos, Time.time, duration);
            activeTweens.Add(t);
            return true;
        }return false;
    }

}
