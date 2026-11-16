using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EventBus
{
    public event Action<GameObject, int> OnDamage;
    public event Action<GameObject> OnDestroy;
    private static EventBus _instance;
    public static EventBus Instance { get
        {
            if( _instance == null )
                _instance = new EventBus();
            return _instance;
        }
    }

    private EventBus()
    {

    }

    public void DoDamage(GameObject target, int damage)
    {
        OnDamage?.Invoke(target, damage);
    }

    public void DoDestroy(GameObject entity)
    {
        OnDestroy?.Invoke(entity);
        Debug.Log($"{entity} has been killed.");
    }
}
