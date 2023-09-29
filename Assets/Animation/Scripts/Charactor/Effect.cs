using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] Movement movement;
    public LayerMask collidinglayer;
    public GameObject VFX;
    public List<GameObject> Games;

    private bool anim = false;
    private GameObject vfx;
    private GameObject effectToSpaw;

    public AudioSource audioEffect;
   

    void Start()
    {
        movement = GetComponent<Movement>();
        vfx = Instantiate(VFX) as GameObject;
        vfx.SetActive(false);
        if(Games.Count > 0 )
        {
            effectToSpaw = Games[0];
        }
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim = true;
            vfx.SetActive(true);
            movement.effectFight();
            if (anim)
            {
                var Vfx = Instantiate(effectToSpaw, vfx.transform.position, Quaternion.identity);
                Destroy(Vfx, 5);
                audioEffect.Play();
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim = false;
            vfx.SetActive(false);
        }
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    if (anim)
        //    {
        //        var Vfx = Instantiate(effectToSpaw, vfx.transform.position, Quaternion.identity) as GameObject;
        //        Destroy(Vfx, 1);
        //        audioEffect.Play();

        //    }

        //}
        if (anim)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit,Mathf.Infinity,collidinglayer))
            {
                vfx.SetActive(true);
                vfx.transform.position = hit.point;
            }
            else
            {
                vfx.SetActive(false) ;
            }
        }    
    }
}
