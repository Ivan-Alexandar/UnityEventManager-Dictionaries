using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Fields
    //fields
    static Dictionary<EventName, List<IntEventInvoker>> invokers = new Dictionary<EventName, List<IntEventInvoker>>();
    static Dictionary<EventName, List<UnityAction<int>>> listeners = new Dictionary<EventName, List<UnityAction<int>>>();

    #endregion

    #region Methods
    //methods
    public static void Initialize()
    {
        foreach (EventName name in Enum.GetValues(typeof(EventName)))
        {
            if (!invokers.ContainsKey(name))
            {
                invokers.Add(name, new List<IntEventInvoker>());
                listeners.Add(name, new List<UnityAction<int>>());
            }
            else
            {
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }

    public static void AddInvoker(EventName name, IntEventInvoker invoker)
    {
        foreach (UnityAction<int> listener in listeners[name])
        {
            invoker.AddListener(name, listener);
        }
        invokers[name].Add(invoker);
    }

    public static void AddListener(EventName name, UnityAction<int> listener)
    {
        foreach (IntEventInvoker invoker in invokers[name])
        {
            invoker.AddListener(name, listener);
        }
        listeners[name].Add(listener); 
    }
    public static void RemoveInvoker(EventName name, IntEventInvoker invoker)
    {
        invokers[name].Remove(invoker);

    }

    #endregion
}
