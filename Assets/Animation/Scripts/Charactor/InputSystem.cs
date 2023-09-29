using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] Movement move;

    [SerializeField] private Vector3 velocity;
    
    public float camDistance = 5;
    public float camspeed = 5;

    public AudioSource Sound;
    

 

    Transform camCenter;    
    void Start()
    {
        move= GetComponent<Movement>();
        camCenter = Camera.main.transform.parent;
        

    }

    
    void Update()
    {
        
        move.CharacterMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move.CharacterPrint(Input.GetButton("Sprint"));
        
        rotateToCam();

        

        if (Input.GetMouseButtonDown(0) )
        {
            move.CharacterFight();
            Sound.Play();
        }

        
    }

    public void rotateToCam()
    {
        Vector3 camPos = camCenter.position;
        Vector3 LookPoint = camPos + (camCenter.forward * camDistance);
        Vector3 dir = LookPoint - transform.position;
        Quaternion LookRotate = Quaternion.LookRotation(dir);
        LookRotate.x = 0;
        LookRotate.z = 0;
        Quaternion final = Quaternion.Lerp(transform.rotation, LookRotate, Time.deltaTime * camspeed);
        transform.rotation = final;
    }
   


}






