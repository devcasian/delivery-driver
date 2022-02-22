using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}