using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKcreator : MonoBehaviour
{
    
    [SerializeField] private Animator animatorGO;
    [SerializeField] private Transform handObj;
    [SerializeField] private Transform handObj1;
    [SerializeField] private Transform lookObj;
    [SerializeField] private float distancelook;

    [SerializeField] private float rightHandWeight;
    [SerializeField] private float LeftHandWeight;

    [SerializeField] private Transform rightLegRay;
    [SerializeField] private Transform rightFoot;

    [SerializeField] private float rightFootWeight;

    [SerializeField] private LayerMask Mask;

    private Vector3 rightFootPosition;
    private Quaternion rightFootRotation;

    private int rightHand;
    private int LeftHand;

    void Start()
    {
        animatorGO = GetComponent<Animator>();
        rightHand = Animator.StringToHash("right_leg");

        rightFoot = animatorGO.GetBoneTransform(HumanBodyBones.RightFoot);
        rightLegRay = animatorGO.GetBoneTransform(HumanBodyBones.RightLowerLeg);
    }


    private void OnAnimatorIK(int layerIndex)
    {
        rightFootWeight = 1; //animatorGO.GetFloat(rightHash);

        animatorGO.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        animatorGO.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);


        RaycastHit hit;

        if(Physics.Raycast(rightLegRay.position, Vector3.down, out hit, 1.2f, Mask))
        {
            rightFootPosition = Vector3.Lerp(rightFoot.position, hit.point+Vector3.up * 0.3f, Time.deltaTime * 10f);
            rightFootRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        animatorGO.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPosition);
        animatorGO.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);

        if (handObj)
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);

            animatorGO.SetIKPosition(AvatarIKGoal.RightHand, handObj.position);
            animatorGO.SetIKRotation(AvatarIKGoal.RightHand, handObj.rotation);

        }
        if (handObj1)
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftHandWeight);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftHandWeight);

            animatorGO.SetIKPosition(AvatarIKGoal.LeftHand, handObj1.position);
            animatorGO.SetIKRotation(AvatarIKGoal.LeftHand, handObj1.rotation);

        }


        if (lookObj!= null)
        {
            animatorGO.SetLookAtWeight(1);
           
                animatorGO.SetLookAtPosition(lookObj.position);                 
        }
        
     
        
          
            
        

    }
}
