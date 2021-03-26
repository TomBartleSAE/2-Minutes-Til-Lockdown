using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ListComplete();
    public static event ListComplete ListCompleted;

    public static void OnListComplete()
    {
        ListCompleted();
    }
}
