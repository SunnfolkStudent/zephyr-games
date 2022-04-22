using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
  [SerializeField] private InputAction action;
  [SerializeField] private CinemachineVirtualCamera vcam1;
  [SerializeField] private CinemachineVirtualCamera vcam2;

  [SerializeField] private CinemachineVirtualCamera[] vcam;

  
  private Animator _animator;

  public bool Part1Camera = true;

  //private void Awake() => _animator = GetComponent<Animator>();

  private void Start() => action.performed += _ => SwitchPriority();

  private void SwitchState()
  {
    _animator.Play(Part1Camera ? "Part2" : "Part1");
    
    Part1Camera = !Part1Camera;
  }

  private void SwitchPriority ()
  {
      if (Part1Camera)
      {
        vcam1.Priority = 0;
        vcam2.Priority = 1;
      }
      else
      {
        vcam1.Priority = 1;
        vcam2.Priority = 0;
      }
      Part1Camera = !Part1Camera;
  }

  private void OnEnable() => action.Enable();
  private void OnDisable() => action.Disable();
}
