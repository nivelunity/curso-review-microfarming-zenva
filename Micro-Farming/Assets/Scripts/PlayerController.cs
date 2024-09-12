using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
   public SpriteRenderer srHead;
   public SpriteRenderer srHoe;


   private void Update()
   {
      //Mover
      if (moveInput.magnitude != 0.0f)
      {
         facingDir = moveInput.normalized;

         bool isFlip = moveInput.x > 0;
         srHead.flipX = isFlip ;
         srHoe.flipX = isFlip;
      }
      
      
   }

   private void FixedUpdate()
   {
      rig.velocity = moveInput.normalized * moveSpeed;
   }

   private void TryInteractTile()
   {
      RaycastHit2D hit = Physics2D.Raycast((Vector2) transform.position + facingDir, Vector3.up, 0.1f, interactLayerMask);

      if (hit.collider != null)
      {
         FieldTile tile = hit.collider.GetComponent<FieldTile>();
         tile.Interact();
      }
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
