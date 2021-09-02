using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventMng
{
    public delegate void EndBossFight();
    public static event EndBossFight EndBossFightEvent;

    public static void BossFightEnd()
    {
        EndBossFightEvent?.Invoke();
    }
}
