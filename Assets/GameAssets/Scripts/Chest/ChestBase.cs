using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.LeftControl;
    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]
    public GameObject notification;
    public float tweenDuration = .2f;
    public Ease tweenEase = Ease.OutBack;
    private bool _cheestOpened = false;

    [Space]
    public ChestItemBase chestItem;

    private float startScale;

    void Start()
    {
        startScale = notification.transform.localScale.x;   
        HideNotification();
    }



    [NaughtyAttributes.Button]
    private void OpenChest()
    {
        if (_cheestOpened) return;
        animator.SetTrigger(triggerOpen);
        _cheestOpened = true;
        HideNotification();
        Invoke(nameof(ShowItem), 1f);
    }

    private void ShowItem()
    {
        chestItem.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }

    private void CollectItem() 
    {
        chestItem.Collect();
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerControllerTurning p = other.GetComponent<PlayerControllerTurning>();
        if (p != null) 
        {
            ShowNotification();
        }
    }


    public void OnTriggerExit(Collider other)
    {
        PlayerControllerTurning p = other.GetComponent<PlayerControllerTurning>();
        if (p != null)
        {
            HideNotification();
        }
    }

    [NaughtyAttributes.Button]
    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale, tweenDuration);
    }

    [NaughtyAttributes.Button]
    private void HideNotification()
    {
        notification.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && notification.activeSelf) 
        {
        OpenChest();
        
        }
    }


}
