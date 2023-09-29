using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera maincamera;
    Transform center;
    Transform target;
    
    public float camSpeed = 5;
    float Xcam=0;
    float Ycam=0;

    public float XcamSmooth = 5;
    public float YcamSmooth = 5;
    public float min = -30;
    public float max = 90;
    public float rotatespeed = 5;
    void Start()
    {
        maincamera = Camera.main;
        center = transform.GetChild(0);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (!target)
            return;
        RotateCam();
    }
    private void LateUpdate()
    {
        if(target)
        {
            FollowPlayer();
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    public void FollowPlayer()
    {
        Vector3 camFollow = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * camSpeed);
        transform.position = camFollow;
    }

    void RotateCam()
    {
        Xcam += Input.GetAxis("Mouse Y") * YcamSmooth;
        Ycam += Input.GetAxis("Mouse X") * XcamSmooth;

        Xcam = Mathf.Clamp(Xcam, min, max);
        Ycam = Mathf.Repeat(Ycam, 360f);

        Vector3 rotating = new Vector3(Xcam, Ycam, 0);
        Quaternion rotate = Quaternion.Slerp(center.transform.localRotation, Quaternion.Euler(rotating), rotatespeed * Time.deltaTime );
        center.transform.localRotation = rotate;
    }
}
