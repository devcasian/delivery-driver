using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private float boostSpeed;
    [SerializeField] private int boostDuration;

    private float _regularSpeed;
    private bool _isBoostActivated;
    private bool _hasCarCrashed;

    private void Start()
    {
        _regularSpeed = moveSpeed;
    }

    private void Update()
    {
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (_isBoostActivated)
        {
            moveSpeed = boostSpeed;
        }

        if (_hasCarCrashed)
        {
            moveSpeed = slowSpeed;
        }
    }

    private void OnCollisionEnter2D()
    {
        if (!_hasCarCrashed)
        {
            Debug.Log("Slowing player speed");
            _hasCarCrashed = true;
        }

        Invoke(nameof(EndCrash), boostDuration);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            if (!_isBoostActivated)
            {
                Debug.Log("Boosting player speed");
                _isBoostActivated = true;
            }

            Invoke(nameof(EndBoost), boostDuration);
        }

        if (other.CompareTag("Player"))

            if (!_hasCarCrashed)
            {
                Debug.Log("Slowing player speed");
                _hasCarCrashed = true;
            }

        Invoke(nameof(EndCrash), boostDuration);
    }

    private void EndBoost()
    {
        _isBoostActivated = false;
        moveSpeed = _regularSpeed;
    }

    private void EndCrash()
    {
        _hasCarCrashed = false;
        moveSpeed = _regularSpeed;
    }
}