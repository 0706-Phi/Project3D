using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DetectionRange : MonoBehaviour
{
    [SerializeField] private Transform tfmPlayer;
    public EnemyController controller;
    bool isTracing = false;
    public AudioSource audioR;
    private void Update()
    {
        if (Vector3.Distance(transform.position, tfmPlayer.position) <= 300f && !isTracing)
        {
            isTracing = true;
            controller.Run();
            audioR.Play();
            controller.playerInDetection = true;
        }

        else if (Vector3.Distance(transform.position, tfmPlayer.position) > 300f && isTracing)
        {
                isTracing = false;
                controller.Idle();
                audioR.Stop();
                controller.playerInDetection = false;
        }
    }

    
}
