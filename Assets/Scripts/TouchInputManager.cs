using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputManager : MonoBehaviour
{
    #region 
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void CancelTouch(Vector2 position, float time);
    public event CancelTouch OnCancelTouch;
    #endregion
    private TaxiActions taxiActions;
    private void Awake() {
        taxiActions = new TaxiActions();
    }
    private void OnEnable() {
        taxiActions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        taxiActions.Player.AndroidPrimaryContact.started += ctx => StartPrimaryContact(ctx);
        taxiActions.Player.AndroidPrimaryContact.canceled += ctx => CancelPrimaryContact(ctx);
    }
    private void StartPrimaryContact(InputAction.CallbackContext context){
        if(OnStartTouch!=null){
            OnStartTouch(taxiActions.Player.AndroidPrimaryPosition.ReadValue<Vector2>(),(float)context.startTime);
        }
    }
     private void CancelPrimaryContact(InputAction.CallbackContext context){
         if(OnCancelTouch!=null){
            OnCancelTouch(taxiActions.Player.AndroidPrimaryPosition.ReadValue<Vector2>(),(float)context.time);
        }
    }
}
