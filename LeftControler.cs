using System;
using UniRx;
using UnityEngine;
using DG.Tweening;
using _VIRAL._03_Scripts;

public class LeftControler : MonoBehaviour
{
    [SerializeField] private ControlPanel controlPanel;
    [SerializeField] private OVRHand.HandFinger fingerPinch = OVRHand.HandFinger.Index;
    private Vector3 controlTransform;

    private bool controlOn = true;

    //private BoolReactiveProperty pinched = new BoolReactiveProperty(true);
    //private BoolReactiveProperty unPinched = new BoolReactiveProperty(false);

    private Hand hand;

    private readonly Subject<bool> onPinched = new Subject<bool>();


    private readonly Subject<bool> onPinchOff = new Subject<bool>();



    private void Awake()
    {
        hand = GetComponentInParent<Hand>();
        controlTransform = controlPanel.transform.localScale;
    }

    void Start()
    {



        hand.DoublePinch(fingerPinch).Subscribe(x =>
        {

            controlPanel.transform.DOScale(new Vector3(0, 1, 1), 0.5f);

            onPinchOff.OnNext(this);

        }).AddTo(this);

        onPinchOff.Subscribe(u =>
        {
            hand.DoublePinch(fingerPinch).Subscribe(_ =>
            {

                controlPanel.transform.DOScale(controlTransform, 0.5f);


                onPinched.OnNext(this);

            });

        }).AddTo(this);

        onPinched.Subscribe(p =>
        {
            hand.DoublePinch(fingerPinch).Subscribe(_ =>
            {

                controlPanel.transform.DOScale(new Vector3(0, 1, 1), 0.5f);

                onPinchOff.OnNext(this);
            });

        }).AddTo(this);













        //controlPanel.gameObject.SetActive(!controlPanel.gameObject.activeSelf); //this is a little nift bit of code that easily allowas to implement the opposite of whatever the active state is


    }
    

}
