using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
   private TrailRenderer _trailRenderer;

   [Header("Dashing")] 
   [SerializeField] private float _dashingVelocity = 14f;
   [SerializeField] private float _dashingTime = 0.5f;
   [SerializeField] private Vector2 _dashingDir;
   [SerializeField] public bool _isDashing;
   [SerializeField] private bool _canDash = true;
   [SerializeField] private FlashImage _flashImage = null;
   [SerializeField] Color _newColor = Color.white;

   private Animator _animator;
   private Rigidbody2D _rigidbody;
   private bool IsGrounded;

   private Input input;
   private jumpKing2 playerController;

   private float previousxVelocity;

   private void Start()
   {
      _animator = GetComponent<Animator>();
      _trailRenderer = GetComponent<TrailRenderer>();
      _rigidbody = GetComponent<Rigidbody2D>();
      input = GetComponent<Input>();
      playerController = GetComponent<jumpKing2>();
   }

   private void Update()
   {
      if (!_isDashing && playerController.isGrounded)
      {
         _canDash = true;
      }

      if (!_isDashing)
      {
         previousxVelocity = _rigidbody.velocity.x;
      }
      
      if (input.DashSpressed && _canDash && !playerController.isGrounded)
      {
         if (_dashingDir == Vector2.zero)
         {
            _dashingDir = new Vector2(transform.localScale.x, 0);
         }
         _flashImage.StartFlash(0.25f, 0.5f, _newColor);
         _canDash = false;
         _isDashing = true;
         _trailRenderer.emitting = true;
         StartCoroutine(StopDashing());
      }

      if (_isDashing)
      {
         _rigidbody.velocity = _dashingDir * _dashingVelocity;
        
      }
      else
      {
         _dashingDir = input.MoveInput;
      }
   }

   private IEnumerator StopDashing()
   {
      print("Start Dash");
      yield return new WaitForSeconds(_dashingTime);
      print("Finsihed Dash");
      _rigidbody.velocity = new Vector2(previousxVelocity, _rigidbody.velocity.y);
      _isDashing = false;
      _trailRenderer.emitting = false;
   }
}