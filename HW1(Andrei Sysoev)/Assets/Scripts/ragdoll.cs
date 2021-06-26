using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] Rbs;
    [SerializeField] private Collider[] colls;
    [SerializeField] private Animator anim;

    [SerializeField] private float KillForce = 20f;
    void Awake()
    {
        anim = GetComponent<Animator>();
        Rbs = GetComponentsInChildren<Rigidbody>();
        colls = GetComponentsInChildren<Collider>();
        Revive();
    }

   void Kill()
    {
        SetRagdoll(true);
        SetMain(false);
    }

    void Revive()
    {
        SetRagdoll(false);
        SetMain(true);
    }

    void SetMain(bool active)
    {
        anim.enabled = active;
        Rbs[0].isKinematic = !active;
        colls[0].enabled = active;
    }

    void SetRagdoll(bool active)
    {
        for(int i = 0; i<Rbs.Length; i++)
        {
            Rbs[i].isKinematic = !active;
            Rbs[i].AddForce(Vector3.forward * KillForce, ForceMode.Impulse);
        }
        for(int i = 0; i< colls.Length; i++)
        {
            colls[i].enabled = active;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Kill();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Revive();
        }
    }
}
