// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Character/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""5b5ec2a1-5557-4eef-a06e-66be557ed226"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""7ba59e26-cf83-4693-b836-b31c897315f9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""257f0e73-a3a9-46cc-8622-8c11c03a545f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e7cac10e-5291-4b9d-8d39-72a6f1c7f662"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""363ff96c-4554-4136-9541-0de16257223c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""08334264-b9d1-43f0-9100-b2d5f25e9045"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""d8025606-1fac-4da1-83de-af7628372853"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch1"",
                    ""type"": ""Button"",
                    ""id"": ""f97d9877-ebee-4ae4-adbd-b5f767f67978"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch2"",
                    ""type"": ""Button"",
                    ""id"": ""913ea4c2-2beb-4c3d-882f-02ec7ef8d5e0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""0ec40830-27de-4ae9-a731-cc847d914b6b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c1f0a87a-4cc0-4251-a9bb-7ceb6d5c3f95"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""c79dd0bf-876d-454d-bcbf-1967e0b8853b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dc69815d-5765-413a-ae2c-678c3dbb43e7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd5164bc-41db-42b0-9dbe-8a08efb5ac6a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dd1d361-9823-40b4-972b-3e0732840d89"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""807df9e2-f787-42ed-b92f-d48058505245"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a79a238b-2ddf-4253-ae18-71bb26909de6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdafbd5a-ddf8-4743-aecc-9fcf2c12f879"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""086f96de-8f1a-4f01-88d9-7c807ade3820"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fa1225e-0611-4c9e-add0-bbcfd3ebf69b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06404b9b-af37-4831-8cc9-ef71a26794d9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec0f4771-c5e8-42fa-bbc7-6536f372bcee"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfd343c8-fb90-4b50-8491-59c1d6abeb1f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        /*m_Gameplay = asset.GetActionMap("Gameplay");
        m_Gameplay_Movement = m_Gameplay.GetAction("Movement");
        m_Gameplay_Rotation = m_Gameplay.GetAction("Rotation");
        m_Gameplay_Jump = m_Gameplay.GetAction("Jump");
        m_Gameplay_PrimaryFire = m_Gameplay.GetAction("PrimaryFire");
        m_Gameplay_Sprint = m_Gameplay.GetAction("Sprint");
        m_Gameplay_Crouch = m_Gameplay.GetAction("Crouch");
        m_Gameplay_Switch1 = m_Gameplay.GetAction("Switch1");
        m_Gameplay_Switch2 = m_Gameplay.GetAction("Switch2");
        m_Gameplay_SecondaryFire = m_Gameplay.GetAction("SecondaryFire");
        m_Gameplay_Interact = m_Gameplay.GetAction("Interact");
        m_Gameplay_Drop = m_Gameplay.GetAction("Drop");*/
    }

    ~PlayerControls()
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Rotation;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_PrimaryFire;
    private readonly InputAction m_Gameplay_Sprint;
    private readonly InputAction m_Gameplay_Crouch;
    private readonly InputAction m_Gameplay_Switch1;
    private readonly InputAction m_Gameplay_Switch2;
    private readonly InputAction m_Gameplay_SecondaryFire;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Drop;
    public struct GameplayActions
    {
        private PlayerControls m_Wrapper;
        public GameplayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Rotation => m_Wrapper.m_Gameplay_Rotation;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @PrimaryFire => m_Wrapper.m_Gameplay_PrimaryFire;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
        public InputAction @Switch1 => m_Wrapper.m_Gameplay_Switch1;
        public InputAction @Switch2 => m_Wrapper.m_Gameplay_Switch2;
        public InputAction @SecondaryFire => m_Wrapper.m_Gameplay_SecondaryFire;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                Rotation.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                Rotation.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                Rotation.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                PrimaryFire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryFire;
                PrimaryFire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryFire;
                PrimaryFire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryFire;
                Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Crouch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                Crouch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                Crouch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                Switch1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch1;
                Switch1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch1;
                Switch1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch1;
                Switch2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch2;
                Switch2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch2;
                Switch2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch2;
                SecondaryFire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryFire;
                SecondaryFire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryFire;
                SecondaryFire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryFire;
                Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                Rotation.started += instance.OnRotation;
                Rotation.performed += instance.OnRotation;
                Rotation.canceled += instance.OnRotation;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                PrimaryFire.started += instance.OnPrimaryFire;
                PrimaryFire.performed += instance.OnPrimaryFire;
                PrimaryFire.canceled += instance.OnPrimaryFire;
                Sprint.started += instance.OnSprint;
                Sprint.performed += instance.OnSprint;
                Sprint.canceled += instance.OnSprint;
                Crouch.started += instance.OnCrouch;
                Crouch.performed += instance.OnCrouch;
                Crouch.canceled += instance.OnCrouch;
                Switch1.started += instance.OnSwitch1;
                Switch1.performed += instance.OnSwitch1;
                Switch1.canceled += instance.OnSwitch1;
                Switch2.started += instance.OnSwitch2;
                Switch2.performed += instance.OnSwitch2;
                Switch2.canceled += instance.OnSwitch2;
                SecondaryFire.started += instance.OnSecondaryFire;
                SecondaryFire.performed += instance.OnSecondaryFire;
                SecondaryFire.canceled += instance.OnSecondaryFire;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
                Drop.started += instance.OnDrop;
                Drop.performed += instance.OnDrop;
                Drop.canceled += instance.OnDrop;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPrimaryFire(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSwitch1(InputAction.CallbackContext context);
        void OnSwitch2(InputAction.CallbackContext context);
        void OnSecondaryFire(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
    }
}
