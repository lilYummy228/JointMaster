using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpringJoint))]
public class Catapult : PhysicsController
{
    [SerializeField] private float _force = 50f;
    [SerializeField] private Rigidbody _missileRigidbody;
    
    private SpringJoint _springJoint;
    private WaitForFixedUpdate _waitForFixedUpdate;
    private Vector3 _initialPosition;
    private Vector3 _missilePlace;
    private float _distance = 0.3f;
    private float _basicForce = 0f;

    protected override void Awake()
    {
        base.Awake();
        _springJoint = GetComponent<SpringJoint>();
        _waitForFixedUpdate = new WaitForFixedUpdate();
        _missilePlace = _missileRigidbody.transform.position;
        _initialPosition = transform.position;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _input.Phisics.Launch.performed += OnLaunch;
        _input.Phisics.Reload.performed += OnReload;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _input.Phisics.Launch.performed -= OnLaunch;
        _input.Phisics.Reload.performed -= OnReload;
    }

    private void OnLaunch(InputAction.CallbackContext context)
    {
        _springJoint.spring = _force;
        _rigidbody.WakeUp();
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        _springJoint.spring = _basicForce;
        _rigidbody.WakeUp();

        StartCoroutine(PutMissile());
    }

    private IEnumerator PutMissile()
    {
        while (enabled)
        {
            if (Vector3.Distance(_initialPosition, transform.position) <= _distance)
            {
                _missileRigidbody.velocity = Vector3.zero;
                _missileRigidbody.transform.position = _missilePlace;
                break;
            }

            yield return _waitForFixedUpdate;
        }
    }
}
