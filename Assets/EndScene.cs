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
    private SpriteRenderer _renderer;
    
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           // Timer = Time.time + _animator.GetCurrentAnimatorStateInfo(0).length + 2f;
           _renderer.sortingOrder = 100;
            _animator.Play("n");
            other.gameObject.SetActive(false);
        }
    }
    public void LoadEnd()
    {
        SceneManager.LoadScene("WinMenu");
    }
}
