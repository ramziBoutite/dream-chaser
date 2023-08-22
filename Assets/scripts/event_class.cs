using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class event_class
{
    public static UnityAction<GameObject, int> char_damaged;
    public static UnityAction<GameObject, float> char_healed;
}