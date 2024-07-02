using UnityEngine;

[RequireComponent(typeof(Input), typeof(Rigidbody))]
public class PhysicsController : MonoBehaviour
{   
    protected Input _input;
    protected Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _input = new Input();
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void OnEnable() => _input.Enable();

    protected virtual void OnDisable() => _input.Disable();
}
