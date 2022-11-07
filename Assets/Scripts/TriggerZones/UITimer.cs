using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UITimer : MonoBehaviour
{
    public Action OnTimerEnd;

    [SerializeField]
    private Text graphicTimer;
    private int currenTime = 3, MaxTime = 3;
    private Coroutine Timer;

    public void StartTimer()
    {
        Timer = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        StopCoroutine(Timer);
        Timer = null;
    }

    IEnumerator TimerCoroutine()
    {
        currenTime = MaxTime;
        graphicTimer.gameObject.SetActive(true);
        while(currenTime > 0)
        {
            graphicTimer.text = currenTime--.ToString();
            yield return new WaitForSeconds(1f);
        }
        OnTimerEnd?.Invoke();
    }
}
