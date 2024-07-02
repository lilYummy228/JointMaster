using UnityEngine;
using UnityEngine.InputSystem;

public class Swing : PhysicsController
{
    [SerializeField] private float _force = 200f;        

    protected override void Awake()
    {
        base.Awake();        
    }

    protected override void OnEnable()
    {       
        base.OnEnable();
        _input.Phisics.Force.performed += OnForce;
    }

    protected override void OnDisable()
    {        
        base.OnDisable();
        _input.Phisics.Force.performed -= OnForce;
    }

    private void OnForce(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(Vector3.right * _force);
    }
}
