using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CinemachineSwitcherArray : MonoBehaviour
{

    [SerializeField] private InputAction action;
    [SerializeField] private InputAction action2;
   
    [SerializeField] private CinemachineVirtualCamera[] vcam;

    public int priority = 0;

    public Transform _player;
    private Rigidbody2D _rigidbody2D;

    public int heightPriority = 10;
    public int downPri = 50;

    public int offset = -10;
    
    private void Start()
    {
        action.performed += _ => Jump();//SwitchPriority();
        action2.performed += _ => NegPri();
        _rigidbody2D = _player.GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(0f, 10f);
    }

    private void Update()
    {
        print("DownPri: " + (downPri-5));
        if (_player.position.y < 1)
        {
            heightPriority = 10;
            downPri = 0;
        }
        
        if (_rigidbody2D.velocity.y > 0)
        {
            //print("Goin up");
            if (_player.position.y > heightPriority-5 && priority != vcam.Length-1)
            {
                //print("Goin up Again");
                priority++;
                priority = Mathf.Clamp(priority, 0, vcam.Length-1);
                vcam[priority].Priority += priority;
                heightPriority += 10;
                downPri += 10;
                downPri = Mathf.Clamp(downPri, 0, (vcam.Length-1)*10);
                heightPriority = Mathf.Clamp(heightPriority, 0, (vcam.Length-1)*10);
            }
        }
        else if (_rigidbody2D.velocity.y < 0)
        {
            if (_player.position.y < downPri-5)
            {
                vcam[priority].Priority -= priority;
                priority--;
                priority = Mathf.Clamp(priority, 0, vcam.Length-1);
                
                downPri -= 10;
                downPri = Mathf.Clamp(downPri, 0, (vcam.Length-1)*10);
            }
        }
    }


    private void SwitchPriority ()
    {
        priority++;
        priority = Mathf.Clamp(priority, 0, vcam.Length-1);
        vcam[priority].Priority += priority;
    }
    private void NegPri ()
    {
        vcam[priority].Priority -= priority;
        priority--;
        priority = Mathf.Clamp(priority, 0, vcam.Length-1);
    }

    private void OnEnable()
    {
        action.Enable();
        action2.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
        action2.Disable();
    }
}