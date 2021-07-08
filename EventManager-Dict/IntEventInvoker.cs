using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEventInvoker : MonoBehaviour
{
    #region Fields
    //fields
    protected Dictionary<EventName, UnityEvent<int>> unityEvents = new Dictionary<EventName, UnityEvent<int>>();


    #endregion

    #region Methods
    //methods

    public void AddListener(EventName eventName, UnityAction<int> listener)
    {
        if (unityEvents.ContainsKey(eventName))
        {
            unityEvents[eventName].AddListener(listener);
        }
    }


    #endregion
}
