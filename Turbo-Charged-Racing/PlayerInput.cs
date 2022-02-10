// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Car"",
            ""id"": ""9e8a4ca7-0637-4d3e-ae40-2b9440e8a840"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Value"",
                    ""id"": ""f8d0eefb-ed00-406c-b74c-d87a24dc7f2d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Decelerate"",
                    ""type"": ""Value"",
                    ""id"": ""ac338e9e-e532-497d-8565-f9491c030b80"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Handbrake"",
                    ""type"": ""Button"",
                    ""id"": ""0d5070fa-ecdb-44c3-8c96-ff653d7bdec3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraChange"",
                    ""type"": ""Button"",
                    ""id"": ""b2f82ea5-92f7-412b-9117-e22368d75765"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""92273782-6527-415c-ab37-d375da8f8608"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""8d5b12c4-a1b0-49bb-9508-f628959ee211"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ResetCarOrientation"",
                    ""type"": ""Button"",
                    ""id"": ""13ce0e1f-d885-41ad-8888-682343225112"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""a984d3b2-ac11-4bd6-bafb-9f53d1977217"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d34328f8-7b5b-4332-a0e5-995f0f983c4b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfc7aea6-8de8-4b7b-bcd8-c92d2d2965bb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""767095b4-9a1b-4275-9da9-8ae65d7638a3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f088bd95-6650-4cd9-a990-77d86c00fdd5"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1fded8dc-6644-49a7-9806-f70d8e3c0eca"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6cd7902d-b35f-4d29-9b18-46444c9d38d5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4486b529-0775-45e8-b672-3876b8cc0195"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc5a6964-d05f-45ac-aaf2-cddd9d23d49e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6761ba22-d7af-4b5e-85aa-ed96231faa0f"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77cf109e-ef60-4810-b062-4ad3b97014d4"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c3c108b-b7bc-43cd-85b6-6eb25fd132dd"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetCarOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a62bbd4d-fb47-43ed-90b5-018abf25cdb5"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetCarOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3cf442b-c6d1-4de7-a78e-9b85c3dc22be"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetCarOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""905eb00a-30f4-40c2-b734-81af28e4eab7"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad3bf232-7130-446b-8969-2ce8c3d86c70"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c5e85f1-58c7-4d8d-8bfb-f1d2f2bab816"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Accelerate = m_Car.FindAction("Accelerate", throwIfNotFound: true);
        m_Car_Decelerate = m_Car.FindAction("Decelerate", throwIfNotFound: true);
        m_Car_Handbrake = m_Car.FindAction("Handbrake", throwIfNotFound: true);
        m_Car_CameraChange = m_Car.FindAction("CameraChange", throwIfNotFound: true);
        m_Car_HorizontalMovement = m_Car.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_Car_Boost = m_Car.FindAction("Boost", throwIfNotFound: true);
        m_Car_ResetCarOrientation = m_Car.FindAction("ResetCarOrientation", throwIfNotFound: true);
        m_Car_PauseGame = m_Car.FindAction("PauseGame", throwIfNotFound: true);
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

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Accelerate;
    private readonly InputAction m_Car_Decelerate;
    private readonly InputAction m_Car_Handbrake;
    private readonly InputAction m_Car_CameraChange;
    private readonly InputAction m_Car_HorizontalMovement;
    private readonly InputAction m_Car_Boost;
    private readonly InputAction m_Car_ResetCarOrientation;
    private readonly InputAction m_Car_PauseGame;
    public struct CarActions
    {
        private @PlayerInput m_Wrapper;
        public CarActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Car_Accelerate;
        public InputAction @Decelerate => m_Wrapper.m_Car_Decelerate;
        public InputAction @Handbrake => m_Wrapper.m_Car_Handbrake;
        public InputAction @CameraChange => m_Wrapper.m_Car_CameraChange;
        public InputAction @HorizontalMovement => m_Wrapper.m_Car_HorizontalMovement;
        public InputAction @Boost => m_Wrapper.m_Car_Boost;
        public InputAction @ResetCarOrientation => m_Wrapper.m_Car_ResetCarOrientation;
        public InputAction @PauseGame => m_Wrapper.m_Car_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
                @Decelerate.started -= m_Wrapper.m_CarActionsCallbackInterface.OnDecelerate;
                @Decelerate.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnDecelerate;
                @Decelerate.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnDecelerate;
                @Handbrake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnHandbrake;
                @Handbrake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnHandbrake;
                @Handbrake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnHandbrake;
                @CameraChange.started -= m_Wrapper.m_CarActionsCallbackInterface.OnCameraChange;
                @CameraChange.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnCameraChange;
                @CameraChange.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnCameraChange;
                @HorizontalMovement.started -= m_Wrapper.m_CarActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnHorizontalMovement;
                @Boost.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBoost;
                @ResetCarOrientation.started -= m_Wrapper.m_CarActionsCallbackInterface.OnResetCarOrientation;
                @ResetCarOrientation.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnResetCarOrientation;
                @ResetCarOrientation.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnResetCarOrientation;
                @PauseGame.started -= m_Wrapper.m_CarActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Decelerate.started += instance.OnDecelerate;
                @Decelerate.performed += instance.OnDecelerate;
                @Decelerate.canceled += instance.OnDecelerate;
                @Handbrake.started += instance.OnHandbrake;
                @Handbrake.performed += instance.OnHandbrake;
                @Handbrake.canceled += instance.OnHandbrake;
                @CameraChange.started += instance.OnCameraChange;
                @CameraChange.performed += instance.OnCameraChange;
                @CameraChange.canceled += instance.OnCameraChange;
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @ResetCarOrientation.started += instance.OnResetCarOrientation;
                @ResetCarOrientation.performed += instance.OnResetCarOrientation;
                @ResetCarOrientation.canceled += instance.OnResetCarOrientation;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    public interface ICarActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnDecelerate(InputAction.CallbackContext context);
        void OnHandbrake(InputAction.CallbackContext context);
        void OnCameraChange(InputAction.CallbackContext context);
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnResetCarOrientation(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
}
