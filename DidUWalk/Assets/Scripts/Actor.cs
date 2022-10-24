using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Actor : MonoBehaviour
{
    [Header("--Unique Values--")]
    [Tooltip("This object's public name. To identify object in game.")]
    [SerializeField] protected string myName = "";
    public string Name { get { return myName; } set { myName = value; } }

    [Header("--Position & Rotation--")]
    [Tooltip("This object's starting position, when initialized")]
    [SerializeField] protected Vector3 startPosition = Vector3.zero;
    [Tooltip("This object's starting rotation, when initialized")]
    [SerializeField] protected Quaternion startRotation = Quaternion.identity;
    public Vector3 StartPosition { get { return startPosition; } set { startPosition = value; } }
    public Quaternion StartRotation { get { return startRotation; } set { startRotation = value; } }

    [Header("--Collider--")]
    [Tooltip("My root collider")]
    protected Collider _collider = null;
    [Tooltip("My all colliders include root and children's")]
    [SerializeField] protected Collider[] _colliders = null;
    // Get my root collider
    public virtual void InitCollider()
    {
        if (TryGetComponent<Collider>(out Collider collider))
        {
            _collider = collider;
        }
        else Debug.Log(this.name + ".cs : Trying Get Collider Failed");
    }
    // Get my all collider include root and child
    public virtual void InitAllColliders() { _colliders = GetComponentsInChildren<Collider>(); }
    // Get my all collider exclude root collider
    public virtual void InitChildrenColliders() { _colliders = GetComponentsInChildren<Collider>().Skip(1).ToArray(); }
    // Return my root collider
    public Collider GetCollider() { if (_collider == null) InitCollider(); return _collider; }
    // Return colliders, default : Children colliders exclude root
    public Collider[] GetColliders() { if (_colliders == null) InitChildrenColliders(); return _colliders; }


    [Header("--Rigidbody--")]
    [Tooltip("My root rigidbody.")]
    protected Rigidbody _rigidbody = null;
    [Tooltip("My all rigidbodies include root and children's")]
    [SerializeField] protected Rigidbody[] _rigidbodies = null;
    // Get my root rigidbody
    public virtual void InitRigidbody()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            _rigidbody = rigidbody;
        }
        else Debug.Log(this.name + ".cs : Trying Get Rigidbody Failed");
    }
    // Get my rigidbodies include root and children's
    public virtual void InitAllRigidbodies() { _rigidbodies = GetComponentsInChildren<Rigidbody>(); }
    // Get my rigidbodies exclude root rigidbody
    public virtual void InitChildrenRigidbodies() { _rigidbodies = GetComponentsInChildren<Rigidbody>().Skip(1).ToArray(); }
    // Return my root rigidbody
    public Rigidbody GetRigidbody() { if (_rigidbody == null) InitRigidbody(); return _rigidbody; }
    // Return rigidbodies, default : Children rigidbodies exclude root
    public Rigidbody[] GetRigidbodies() { if (_rigidbodies == null) InitChildrenRigidbodies(); return _rigidbodies; }

    [Header("Animator")]
    [Tooltip("My root animator")]
    protected Animator _animator = null;
    // Get my root animator
    public void InitAnimator() { _animator = GetComponent<Animator>(); }
    // Return my root animator
    public Animator GetAnimator() { if (_animator == null) InitAnimator(); return _animator; }
}