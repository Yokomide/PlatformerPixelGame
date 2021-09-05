using UnityEngine;
using UnityEngine.Events;

public class PlayerController2D : MonoBehaviour
{
	public CharacterController2D controller;

    public float runSpeed = 40f;

	float horizontalMove = 0f;

	void Update()
    {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}