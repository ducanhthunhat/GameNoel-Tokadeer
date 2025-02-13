using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health = 100f;
    private string currentName;
    public Animator anim;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    public void TakeDamage(float damage)
    {
        changeAnim("takedamage");
        health -= damage;
        audioManager.PlaySFX(audioManager.takedamage);

        Invoke("resetTakedamage", 0.5f);
        if (health <= 0)
        {
            Die();
        }
    }

    // Phương thức khi enemy chết
    private void Die()
    {
        Destroy(gameObject);
        changeAnim("die");

    }
    private void changeAnim(string animName)
    {
        if (currentName != animName)
        {
            anim.ResetTrigger(animName);
            currentName = animName;
            anim.SetTrigger(currentName);
        }
    }

    private void resetTakedamage()
    {
        changeAnim("walk");
    }
}
