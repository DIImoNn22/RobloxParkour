using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public GameObject robloxPlayerBody;
    private Animator anim;
    private PlayerController _playerController;

    private void Start()
    {
        anim = robloxPlayerBody.GetComponentInChildren<Animator>();
        _playerController = gameObject.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        anim.SetInteger("IsRunning", (Input.GetKey("w") || Input.GetKey("s")) && _playerController.GroundedPlayer ? 1 : 0);
    }
}
