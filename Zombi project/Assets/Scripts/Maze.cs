using UnityEngine;
using UnityEngine.InputSystem;

public class Maze : MonoBehaviour
{
    
    public GameObject maze;
    public float turnSpeed = 5;

    private InputAction turn;
    
    void Start()
    {
        turn = InputSystem.actions.FindAction("Move");
    }
    
    void Update()
    {
        Vector2 turnValue = turn.ReadValue<Vector2>();
        maze.transform.Rotate(new Vector3(-turnValue.x, 0, turnValue.y) * turnSpeed * Time.deltaTime);
        Debug.Log("Turn val x:" + turnValue.x + " turn val y:" + turnValue.y);
    }
}
