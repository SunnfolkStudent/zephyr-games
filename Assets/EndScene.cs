using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    
    private float Timer = 0;
    private Animator _animator;
    
    private void Start()
    {
        
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("n"))
        {
            if (Timer < Time.time)
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Timer = Time.time + _animator.GetCurrentAnimatorStateInfo(0).length + 2f;
            _animator.Play("n");
        }
    }
    public void LoadEnd()
    {
        SceneManager.LoadScene("WinMenu");
    }
}
