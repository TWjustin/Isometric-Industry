//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/TouchControls/TouchControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @TouchControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Zoom in/out"",
            ""id"": ""1d04f047-5791-4705-9965-df8883b6dfc2"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""5360ed14-4c52-4d13-90ad-742d06c8fa7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""ace05300-c6cf-490f-908a-84b8f8b43af4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""b2a47a08-7247-4040-94bc-d338f639df54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""e3374718-9980-4f0e-a81f-a277a11fb28d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""37b57bbd-d3c2-4329-8948-2b5074dfe2a5"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8ca9e1e-67a0-4669-b2d9-c33f93e15225"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a1283d4-8f90-456e-bcad-fa21aeff3563"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20e62aa6-99a5-47b0-b1ec-39779a9d4ece"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Swipe"",
            ""id"": ""aab7ceca-0825-49c0-bf8c-4c2d4c59b418"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e4e18409-4ab1-4aac-84ee-5f6c09249eba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""37bb115f-8bb9-4bfb-9691-f3558c977d4d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77c83a3d-6926-47e0-b885-62de7db54ef5"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f2714c8-2c6b-4111-9af6-6c75eca8d4d9"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Zoom in/out
        m_Zoominout = asset.FindActionMap("Zoom in/out", throwIfNotFound: true);
        m_Zoominout_PrimaryFingerPosition = m_Zoominout.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
        m_Zoominout_SecondaryFingerPosition = m_Zoominout.FindAction("SecondaryFingerPosition", throwIfNotFound: true);
        m_Zoominout_SecondaryTouchContact = m_Zoominout.FindAction("SecondaryTouchContact", throwIfNotFound: true);
        m_Zoominout_PrimaryTouchContact = m_Zoominout.FindAction("PrimaryTouchContact", throwIfNotFound: true);
        // Swipe
        m_Swipe = asset.FindActionMap("Swipe", throwIfNotFound: true);
        m_Swipe_PrimaryContact = m_Swipe.FindAction("PrimaryContact", throwIfNotFound: true);
        m_Swipe_PrimaryPosition = m_Swipe.FindAction("PrimaryPosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Zoom in/out
    private readonly InputActionMap m_Zoominout;
    private List<IZoominoutActions> m_ZoominoutActionsCallbackInterfaces = new List<IZoominoutActions>();
    private readonly InputAction m_Zoominout_PrimaryFingerPosition;
    private readonly InputAction m_Zoominout_SecondaryFingerPosition;
    private readonly InputAction m_Zoominout_SecondaryTouchContact;
    private readonly InputAction m_Zoominout_PrimaryTouchContact;
    public struct ZoominoutActions
    {
        private @TouchControls m_Wrapper;
        public ZoominoutActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFingerPosition => m_Wrapper.m_Zoominout_PrimaryFingerPosition;
        public InputAction @SecondaryFingerPosition => m_Wrapper.m_Zoominout_SecondaryFingerPosition;
        public InputAction @SecondaryTouchContact => m_Wrapper.m_Zoominout_SecondaryTouchContact;
        public InputAction @PrimaryTouchContact => m_Wrapper.m_Zoominout_PrimaryTouchContact;
        public InputActionMap Get() { return m_Wrapper.m_Zoominout; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ZoominoutActions set) { return set.Get(); }
        public void AddCallbacks(IZoominoutActions instance)
        {
            if (instance == null || m_Wrapper.m_ZoominoutActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ZoominoutActionsCallbackInterfaces.Add(instance);
            @PrimaryFingerPosition.started += instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.performed += instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.canceled += instance.OnPrimaryFingerPosition;
            @SecondaryFingerPosition.started += instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.performed += instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.canceled += instance.OnSecondaryFingerPosition;
            @SecondaryTouchContact.started += instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.performed += instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.canceled += instance.OnSecondaryTouchContact;
            @PrimaryTouchContact.started += instance.OnPrimaryTouchContact;
            @PrimaryTouchContact.performed += instance.OnPrimaryTouchContact;
            @PrimaryTouchContact.canceled += instance.OnPrimaryTouchContact;
        }

        private void UnregisterCallbacks(IZoominoutActions instance)
        {
            @PrimaryFingerPosition.started -= instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.performed -= instance.OnPrimaryFingerPosition;
            @PrimaryFingerPosition.canceled -= instance.OnPrimaryFingerPosition;
            @SecondaryFingerPosition.started -= instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.performed -= instance.OnSecondaryFingerPosition;
            @SecondaryFingerPosition.canceled -= instance.OnSecondaryFingerPosition;
            @SecondaryTouchContact.started -= instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.performed -= instance.OnSecondaryTouchContact;
            @SecondaryTouchContact.canceled -= instance.OnSecondaryTouchContact;
            @PrimaryTouchContact.started -= instance.OnPrimaryTouchContact;
            @PrimaryTouchContact.performed -= instance.OnPrimaryTouchContact;
            @PrimaryTouchContact.canceled -= instance.OnPrimaryTouchContact;
        }

        public void RemoveCallbacks(IZoominoutActions instance)
        {
            if (m_Wrapper.m_ZoominoutActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IZoominoutActions instance)
        {
            foreach (var item in m_Wrapper.m_ZoominoutActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ZoominoutActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ZoominoutActions @Zoominout => new ZoominoutActions(this);

    // Swipe
    private readonly InputActionMap m_Swipe;
    private List<ISwipeActions> m_SwipeActionsCallbackInterfaces = new List<ISwipeActions>();
    private readonly InputAction m_Swipe_PrimaryContact;
    private readonly InputAction m_Swipe_PrimaryPosition;
    public struct SwipeActions
    {
        private @TouchControls m_Wrapper;
        public SwipeActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryContact => m_Wrapper.m_Swipe_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_Swipe_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_Swipe; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwipeActions set) { return set.Get(); }
        public void AddCallbacks(ISwipeActions instance)
        {
            if (instance == null || m_Wrapper.m_SwipeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SwipeActionsCallbackInterfaces.Add(instance);
            @PrimaryContact.started += instance.OnPrimaryContact;
            @PrimaryContact.performed += instance.OnPrimaryContact;
            @PrimaryContact.canceled += instance.OnPrimaryContact;
            @PrimaryPosition.started += instance.OnPrimaryPosition;
            @PrimaryPosition.performed += instance.OnPrimaryPosition;
            @PrimaryPosition.canceled += instance.OnPrimaryPosition;
        }

        private void UnregisterCallbacks(ISwipeActions instance)
        {
            @PrimaryContact.started -= instance.OnPrimaryContact;
            @PrimaryContact.performed -= instance.OnPrimaryContact;
            @PrimaryContact.canceled -= instance.OnPrimaryContact;
            @PrimaryPosition.started -= instance.OnPrimaryPosition;
            @PrimaryPosition.performed -= instance.OnPrimaryPosition;
            @PrimaryPosition.canceled -= instance.OnPrimaryPosition;
        }

        public void RemoveCallbacks(ISwipeActions instance)
        {
            if (m_Wrapper.m_SwipeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISwipeActions instance)
        {
            foreach (var item in m_Wrapper.m_SwipeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SwipeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SwipeActions @Swipe => new SwipeActions(this);
    public interface IZoominoutActions
    {
        void OnPrimaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryTouchContact(InputAction.CallbackContext context);
        void OnPrimaryTouchContact(InputAction.CallbackContext context);
    }
    public interface ISwipeActions
    {
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
}
