using System.Collections.Generic;
using UnityEngine;

public abstract class StatesSO : ScriptableObject
{
    public List<StatesSO> states = new List<StatesSO>();
    public abstract void OnStateEnter(EnemyController ec);
    public abstract void OnStateExit(EnemyController ec);
    public abstract void OnStateUpdate(EnemyController ec);
}