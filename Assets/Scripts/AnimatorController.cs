using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : Actor
{
    public virtual void Anim_Move()
    {

    }
    public virtual void Anim_Jump()
    {

    }
    public virtual void Anim_Grounded()
    {

    }
    public virtual void RagdollToggle(bool value) // My ragdoll on / off toggle
    {
        _animator.enabled = value;

        if (_rigidbody == null) { InitRigidbody(); }
        if (_rigidbodies == null) { InitChildrenRigidbodies(); }
        else if (_rigidbodies[0] == _rigidbody) { InitChildrenRigidbodies(); }

        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = value;
        }

        if (_collider == null) { InitCollider(); }
        if (_colliders == null) { InitChildrenColliders(); }
        else if (_colliders[0] == _collider) { InitChildrenColliders(); }

        foreach (Collider collider in _colliders)
        {
            collider.isTrigger = value;
        }
    }
}