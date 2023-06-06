using TMPro;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private enum MovementDirection { Left, Right, Up, Down };
    public GameObject player;
    private Rigidbody playerRigidbody;
    private bool isGrounded = false;
    private int score;
    public TextMeshProUGUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();

        transform.localRotation = Quaternion.Euler(0, -90, 0);
        Debug.Log("Game Started");
    }

    private void Update()
    {
        scoreUI.text = "Score" + score;
        // Check if Grounded
        if (playerRigidbody.position.y < 0.40) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
                Debug.Log("up");
            if (isGrounded) {
                MovePlayer(MovementDirection.Up);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
                Debug.Log("down");
            if (isGrounded) {
                MovePlayer(MovementDirection.Down);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
                Debug.Log("right");
            if (isGrounded) {
                MovePlayer(MovementDirection.Right);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
                Debug.Log("left");
            if (isGrounded) {
                MovePlayer(MovementDirection.Left);
            }
        }
    }

    private void MovePlayer(MovementDirection d)
    {   
        switch (d)
        {
            case MovementDirection.Up:
                transform.localRotation = Quaternion.Euler(0, -90, 0);
                playerRigidbody.AddForce(0, 70, 100);
                score += 5;
            break;

            case MovementDirection.Down:
                transform.localRotation = Quaternion.Euler(0, 90, 0);
                playerRigidbody.AddForce(0, 70, -100);
            break;

            case MovementDirection.Left:
                transform.localRotation = Quaternion.Euler(0, -180, 0);
                playerRigidbody.AddForce(-50, 70, 0);
            break;

            case MovementDirection.Right:
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                playerRigidbody.AddForce(50, 70, 0);
            break;
        }
    }
}
