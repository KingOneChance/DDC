using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Actor
{
    [Header("--Movement Values--")]
    [Tooltip("Movement speed used by normal")]
    [SerializeField] protected float moveSpeed = 2f;
    [Tooltip("Normal walk speed")]
    [SerializeField, Range(0f, 20f)] protected float walkSpeed = 2f;
    [Tooltip("Run speed")]
    [SerializeField, Range(0f, 40f)] protected float runSpeed = 4f;
    [Tooltip("Jump Power")]
    [SerializeField, Range(0f, 100f)] protected float jumpPower = 6f;
    [Tooltip("Rotation speed")]
    [SerializeField, Range(0f, 200f)] protected float rotationSpeed = 2f;
    [Tooltip("Is moving now?")]
    [SerializeField] protected bool isMove = false;
    [Tooltip("Is running now?")]
    [SerializeField] protected bool isRun = false;
    [Tooltip("Is jumping now?")]
    [SerializeField] protected bool isJump = false;
    [Tooltip("Is Dead?")]
    [SerializeField] protected bool isDead = false;
    [Tooltip("Grounded checking sphere radius")]
    [SerializeField, Range(0f, 5f)] protected float checkingRadius = 0.3f;

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public bool IsMove { get { return isMove; } }
    public bool IsRun { get { return isRun; } }
    public bool IsJump { get { return isJump; } }
    public bool IsDead { get { return isDead; } }
    // Checking human is on grounded by sphere
    public bool OnGrounded() { return Physics.CheckSphere(transform.position, checkingRadius); }

    [Header("Information Values")]
    [Tooltip("My max hp")]
    [SerializeField, Range(0f, 500f)] protected float maxHp = 100f;
    [Tooltip("My current hp")]
    [SerializeField] protected float hp = 100f;
    public virtual void InitHp() { hp = maxHp; } // Initialize first hp state
    public enum Bone
    {
        neck,
        upperchest,
        chest,
    }
    [Header("Bones")]
    [SerializeField] protected Transform head = null;
    [SerializeField] protected Transform spine = null;
    // Get Head Bones 
    public virtual void GetHeadBone() { head = _animator.GetBoneTransform(HumanBodyBones.Head); }
    // Get Spine Bones
    public virtual void GetSpineBone() { spine = _animator.GetBoneTransform(HumanBodyBones.Spine); }
    public virtual Transform GetBone(Bone bone) // Get bones whatever I want
    {
        switch (bone)
        {
            case Bone.neck: { return _animator.GetBoneTransform(HumanBodyBones.Neck); }
            case Bone.upperchest: { return _animator.GetBoneTransform(HumanBodyBones.UpperChest); }
            case Bone.chest: { return _animator.GetBoneTransform(HumanBodyBones.Chest); }
            default: { Debug.Log(this.name + ".cs : " + "GetBone() -> There's no parameter."); return null; }
        }
    }
    public virtual void Awake()
    {
        InitHp();
    }
#if UNITY_EDITOR
    public virtual void OnDrawGizmosSelected() // Draw gizmo grounded checking sphere
    {
        Gizmos.DrawSphere(transform.position, checkingRadius);
    }
#endif
}