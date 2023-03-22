using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform eyes;


    public float rotationSpeed;

   
    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.None : CursorLockMode.Confined;
    }
    // Update is called once per frame
    void Update()
    {

      

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 8;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3;
        }


        Move(GetMovementInput());
        Rotate(GetRotationInput().normalized);

    }


    private void Rotate(Vector2 p_scrollDelta)
    {
        transform.Rotate(Vector3.up, p_scrollDelta.x * rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector2 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X");
        var l_mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(l_mouseX, l_mouseY);
    }

    private Vector3 GetMovementInput()
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");
        return new Vector3(l_horizontal, 0, l_vertical).normalized;
    }

    private void Move(Vector3 p_inputMovement)
    {
        var transform1 = transform;
        transform1.position += (p_inputMovement.z * transform1.forward + p_inputMovement.x * transform1.right) *
                               (moveSpeed * Time.deltaTime);

    }

  
    
}
