using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    public GameObject rotationPoint;
    public float rotationSpeed = 720f; // Degrees per second


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RotateTurret(Vector2 moveInput)
    {
        if (moveInput != Vector2.zero)
        {
            // rotate the y axis
            rotationPoint.transform.Rotate(Vector3.up, moveInput.x * rotationSpeed * Time.deltaTime);
        }
    }
}
