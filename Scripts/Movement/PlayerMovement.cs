using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 100f;
    
    private Animator animator;
    bool move = false;
    private Vector3 movementDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (move)
        {
            movementDirection = Vector3.forward * speed * Time.deltaTime;
            transform.Translate(movementDirection);

            HandleTouchInput();
            HandleKeyboardInput();
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float moveX = touch.deltaPosition.x * Time.deltaTime;

                transform.Translate(moveX, 0, 0);
            }
        }
    }

    void HandleKeyboardInput()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveX = -speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveX = speed * Time.deltaTime;

        transform.Translate(moveX, 0, 0);
    }

    public void RotatePlayer(float angle) => StartCoroutine(SmoothRotate(angle));

    public void StartMove() => move = true;

    public void StopMove() => move = false;

    public void SetAnimation(int i) => animator.SetInteger("AnimIndex", i);

    private IEnumerator SmoothRotate(float angle)
    {
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, angle, 0);
        float timeElapsed = 0f;

        while (timeElapsed < rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, timeElapsed / rotationSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
