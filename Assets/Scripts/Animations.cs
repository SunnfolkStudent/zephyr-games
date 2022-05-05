using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
   #region VARIABLES

   private Animator _animator;
   private Input _Input;
   private Rigidbody2D _rigidbody2D;
   private jumpKing2 _movement;
   private Dash _dash;

   public AnimatorOverrideController _left;
   public AnimatorOverrideController _right;

   private bool canJump;

   public enum States
   {
      Start,
      Ground,
      Jump,
      Fall,
   }
   
   public States state;
   public string previousState;
   private static readonly int Direction = Animator.StringToHash("Direction");

   #endregion

   private void Start()
   {
      _animator = GetComponent<Animator>();
      _Input = GetComponent<Input>();
      _rigidbody2D = GetComponent<Rigidbody2D>();
      _movement = GetComponent<jumpKing2>();
      _dash = GetComponent<Dash>();
      
      StartState();
   }

   private void Update()
   {
      FlipAnimation();
      
      switch (state)
      {
         case States.Start:
            StartState();
            break;
         case States.Ground:
            GroundState();
            break;
         case States.Jump:
            JumpState();
            break;
         case States.Fall:
            FallState();
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }

   void FlipAnimation()
   {
      if (_Input.MoveInput.x != 0)
      {
         _animator.runtimeAnimatorController = _Input.MoveInput.x < 0 ? _left : _right;
      }
   }

   void StartState()
   {
      previousState = state.ToString();
      state = _movement.isGrounded ? States.Ground : States.Fall;
   }

   void GroundState()
   {
      if (previousState == States.Fall.ToString()) 
      { 
         _animator.Play("Land");
         CinemachineShake.Instance.ShakeCamera(Mathf.Abs(_rigidbody2D.velocity.y * 0.1f), 0.3f);
      }
      if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) { previousState = state.ToString(); }
      
      if (previousState == States.Fall.ToString()) return;

      _animator.Play(_Input.MoveInput.x != 0 ? "Walk" : "Idle");

      if (!_movement.isGrounded) { state = States.Fall; }
      else if (_Input.JumpPressed) { _animator.Play("jumpPressed"); canJump = true; state = States.Jump; }
   }

   void JumpState()
   {
      if (canJump) { _animator.Play("jumpPressed"); canJump = false; }
      
      if (_Input.JumpReleased || _movement.jumpValue >= _movement.maxJumpValue)
      {
         _animator.Play("jumpReleased");
      }
      
      previousState = state.ToString();
      if (_rigidbody2D.velocity.y < 0 && _animator.GetCurrentAnimatorStateInfo(0).IsName("jumpFinal")) { state = States.Fall; }
      else if (_Input.DashSpressed) { state = States.Fall; }
   }
   

   void FallState()
   {
      if (_rigidbody2D.velocity.y < 0 && !_dash._isDashing)
      {
         _animator.Play("Fall");
      }
      else if (_dash._isDashing)
      {
         _animator.Play("Dash");
      }

      previousState = state.ToString();
      if (_movement.isGrounded) { state = States.Ground; }
   }
}