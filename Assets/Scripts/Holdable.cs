using Unity.VisualScripting;
using UnityEngine;

public class Holdable : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Transform _lastParent;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if( _rigidbody == null )
            _rigidbody= GetComponentInChildren<Rigidbody>();
        _lastParent = transform.parent;
    }

    public void Hold(Transform holder)
    {
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;

        var t = transform;
        
        t.parent = holder;
        t.rotation = holder.rotation;
    }

    public void Drop()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        transform.parent = _lastParent;
    }
    
}
