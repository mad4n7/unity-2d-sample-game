using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    
    [SerializeField]
    private AudioSource deathSFX;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        _animator.SetTrigger("death");
        _rb.bodyType = RigidbodyType2D.Static;
        deathSFX.Play();
    }
    
    private void RestartLevel()
    {
        Debug.Log("Restarting level!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
