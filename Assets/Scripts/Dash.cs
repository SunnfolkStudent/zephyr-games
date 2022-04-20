using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dash : MonoBehaviour
{
   private TrailRenderer _trailRenderer;

   [Header("Dashing")] 
   [SerializeField] private float _dashingVelocity = 14f;
   [SerializeField] private float _dashingTime = 0.5f;
   private Vector2 _dashingDir;
   private bool _isDashing;
   private bool _canDash = true;

   private Animator _animator;
   private Rigidbody2D _rigidbody;
   private bool IsGrounded;
   
   
   private void Start()
   {
      _animator = GetComponent<Animator>();
      _trailRenderer = GetComponent<TrailRenderer>();
      _rigidbody = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      var dashInput = Input.GetButtonDown("Dash");


      if (dashInput && _canDash)
      {
         _isDashing = true;
         _canDash = false;
         _trailRenderer.emitting = true;
         _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
         if (_dashingDir == Vector2.zero)
         {
            _dashingDir = new Vector2(transform.localScale.x, 0);
         }

         StartCoroutine(StopDashing());
      }

      _animator.SetBool("IsDashing", _isDashing);

      if (_isDashing)
      {
         _rigidbody.velocity = _dashingDir.normalized * _dashingVelocity;
         return;
      }

      if (IsGrounded)
      {
         _canDash = true;
      }
   }

   private IEnumerator StopDashing()
   {
      yield return new WaitForSeconds(_dashingTime);
      _trailRenderer.emitting = false;
      _isDashing = false;
   }
}