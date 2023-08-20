using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class _parallel_effect : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    Vector2 start_pos;
    Vector2 camMovSinceStart => (Vector2)cam.transform.position - start_pos;
    float parallaxFactor => Mathf.Abs(z_distance_from_target) / clipping_plane;
    float clipping_plane => (cam.transform.position.z + (z_distance_from_target > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float z_distance_from_target => transform.position.z - target.position.z;
    float z_start;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        z_start = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newpos = start_pos +camMovSinceStart * parallaxFactor;
        transform.position = new Vector3(newpos.x,newpos.y,z_start);
    }
}
