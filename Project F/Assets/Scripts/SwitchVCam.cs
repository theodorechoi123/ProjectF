using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmount = 10;
    [SerializeField]
    private Animator animator;
    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];

    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
        // float currentLayerWeight = animator.GetLayerWeight(1);
        // float layerWeight = Mathf.Lerp(currentLayerWeight, 1f, Time.deltaTime * 10);
        animator.SetLayerWeight(1, 1f);
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
        // float currentLayerWeight = animator.GetLayerWeight(1);
        // float layerWeight = Mathf.Lerp(currentLayerWeight, 0f, Time.deltaTime * 10);
        animator.SetLayerWeight(1, 0f);

    }
}
