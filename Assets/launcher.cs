using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
public GameObject launcherPrefab;
    public void launch_event ()
    {
        //Quaternion arrowVector = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -143);
        Instantiate(launcherPrefab,transform.position,transform.rotation);
    }
}
