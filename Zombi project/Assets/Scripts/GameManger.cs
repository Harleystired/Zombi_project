using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManger : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    public Vector3 selectedSize;
    InputAction left, right;
    private int selectedIndex = 0;
    InputAction jump;
    public Vector3 pushForce;
    public TMP_Text timerText;
    private float time = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SelectZombie( 0);
        left = InputSystem.actions.FindAction("PreviusZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        jump = InputSystem.actions.FindAction("Jump");
    }

    void SelectZombie(int index)
    {
        if (selectedZombie != null)
            selectedZombie.transform.localScale = Vector3.one;
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected: " + selectedZombie.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (left.triggered)
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 3;
            SelectZombie(selectedIndex);
            Debug.Log("left pressed");
        }
         
        if (right.triggered)
        {
            selectedIndex++;
            if(selectedIndex >= zombies.Length)
                selectedIndex = 0;
            SelectZombie(selectedIndex);
            Debug.Log("right pressed");
        }
        if(jump.triggered)
        {
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            rb.AddForce(pushForce);
            Debug.Log("jumped");
        }
        time += Time.deltaTime;
        timerText.text = "Time: " + time.ToString("F1") + "s";
    }
}
