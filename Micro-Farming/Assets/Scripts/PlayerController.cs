using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   public float moveSpeed;
   
   private Vector2 moveInput;
   private bool interactInput;

   private Vector2 facingDir;

   public LayerMask interactLayerMask;

   public Rigidbody2D rig;
   public SpriteRenderer sr;

   private void FixedUpdate()
   {
      rig.velocity = moveInput.normalized * moveSpeed;
   }
   
   public void OnMoveInput(InputAction.CallbackContext context)
   {
      moveInput = context.ReadValue<Vector2>();
   }
   
   public void OnInteractInput(InputAction.CallbackContext context)
   {
      if (context.phase == InputActionPhase.Performed)
      {
         interactInput = true;
      }
   }
}
