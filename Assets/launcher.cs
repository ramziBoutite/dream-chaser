using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    public Transform Transform;
public GameObject launcherPrefab;
    public void launch_event ()
    {
        //Quaternion arrowVector = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -143);
       GameObject arrow = Instantiate(launcherPrefab,Transform.position,transform.rotation);
        arrow.transform.localScale = new Vector3( arrow.transform.localScale.x *transform.localScale.x,arrow.transform.localScale.y,arrow.transform.localScale.z);
    }
}
