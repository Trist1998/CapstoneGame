// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

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
            ""id"": ""05872b54-81c4-470c-a607-52d8eb3193e4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""32e02730-8d2f-42e2-84a7-33a24eb27c4b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""3faf3d0a-5169-461f-b3be-4141d7ad72f8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a050a97e-a092-4c7e-b2fe-bef07ac6e0d6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""8cc2987b-3fa3-4c56-b471-7755c545b549"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""e0f0ed70-5a9f-4206-add9-e2b1baa79b97"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""e9c2aba0-a12e-4f7e-872e-0041b69d825b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""439bfc55-8d2d-4a24-950d-1b5e6524ad80"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""809fe363-e050-4f65-8274-5d9f48e54758"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""363ff7f5-2ade-4a01-90b8-811b83cc1d3a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""3c1d6964-daf9-44af-ad9c-9649e55fe603"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""6b5346b8-4552-4550-b50e-bceaf1f7d89a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""2335b840-86ae-450f-b0ea-080360cdefe5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f54dfe82-4e7e-4f25-97cb-0f0839ca2893"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4fcfd70-c969-4640-bb09-9ffae3c0381c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99974d83-4a61-410c-a086-4fc6be648c13"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76040911-47c6-4ea8-ac42-50766c90e181"",
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
                    ""id"": ""f553b6b8-4bcc-4082-ac3c-a5b0744f51c8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e54c4be6-6272-4f19-82e1-98843d36298a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61e07be0-a633-4619-b6c7-c1f34a541da1"",
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
                    ""id"": ""eeb084c6-4768-481c-9b51-5083ae2cdc5e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce94aa20-024d-41ec-8862-07590b9bbb0c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2f18a65-bb1d-471b-9aef-f8173695dcc5"",
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
                    ""id"": ""13092802-b808-4888-9b7f-27d8c638a0df"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75db0269-5479-4d25-a9a5-66495c50197e"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MKB"",
            ""id"": ""9fd90251-748f-441e-bcce-b8f2a315c3be"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c25999e4-2966-4fb8-b763-b64f4b45b774"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""b5f266f9-5a9f-4d7d-8fb0-1bc43bc5873d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""d875eafc-5ac4-40ba-b1ba-7da4c8d82c9e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""7b999046-7360-44dd-bfa4-f599ec1588ee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""d05d8c28-19aa-4c8e-ad86-05a5b43149ad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1872221e-24de-4114-b130-73488a56d2ba"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""01dea2b5-d674-4cc1-9401-045ca76cb208"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""b201c668-0ca4-4545-b0a0-1964e2e5388b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""eb1b4740-98b5-49a2-bd4f-8f3eaeb6e157"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""aa7240d7-47b3-4916-af1e-d6b846eb528e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""b599af74-1f9c-4303-8339-6794c3ac0bad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""3ba34a26-0bcf-4d2e-a7a6-f858b28acf1a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""271d1381-e768-440b-adbf-f7eec0b59c57"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""02b9d2b5-27d3-4dc8-95fc-cf86d5476276"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92a85b7c-4257-4a63-ab03-eda65497ee6e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caf190b6-53f2-44e6-b4bd-d3c2c31a8165"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3112cc0-ae62-44ee-992e-0a3b2c3db3c4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36f5bd7a-acef-4059-a046-b20a72d49d0c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7318e0e6-ee78-43ec-9b57-47e83b1d025f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bd161ef-9bd6-41a0-8f36-0ddc674f9f11"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97e1efe8-6918-4635-95dc-5915b14c4e40"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfed182a-5cb3-49c4-9b23-b1806edfe5f5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c56427b4-1445-4307-9073-55f142a3676d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ea9bafa-f214-4139-9edd-e9da8d3a959f"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e533c27-ba2f-46cb-92a2-7351dc7a5f24"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""659f4a29-a5d3-4f9a-a8f9-e6784fe8d809"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2322e69-7ee7-4b6f-9b20-d4ac3decec60"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93f7d4a3-610c-403d-9193-3c9741c6ee00"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.GetActionMap("Gameplay");
        m_Gameplay_Move = m_Gameplay.GetAction("Move");
        m_Gameplay_Rotate = m_Gameplay.GetAction("Rotate");
        m_Gameplay_Jump = m_Gameplay.GetAction("Jump");
        m_Gameplay_Crouch = m_Gameplay.GetAction("Crouch");
        m_Gameplay_Primary = m_Gameplay.GetAction("Primary");
        m_Gameplay_Secondary = m_Gameplay.GetAction("Secondary");
        m_Gameplay_Interact = m_Gameplay.GetAction("Interact");
        m_Gameplay_Drop = m_Gameplay.GetAction("Drop");
        m_Gameplay_Swap = m_Gameplay.GetAction("Swap");
        m_Gameplay_Sprint = m_Gameplay.GetAction("Sprint");
        m_Gameplay_Pause = m_Gameplay.GetAction("Pause");
        m_Gameplay_Join = m_Gameplay.GetAction("Join");
        // MKB
        m_MKB = asset.GetActionMap("MKB");
        m_MKB_Jump = m_MKB.GetAction("Jump");
        m_MKB_Crouch = m_MKB.GetAction("Crouch");
        m_MKB_Sprint = m_MKB.GetAction("Sprint");
        m_MKB_Swap = m_MKB.GetAction("Swap");
        m_MKB_Drop = m_MKB.GetAction("Drop");
        m_MKB_Interact = m_MKB.GetAction("Interact");
        m_MKB_Secondary = m_MKB.GetAction("Secondary");
        m_MKB_Join = m_MKB.GetAction("Join");
        m_MKB_Forward = m_MKB.GetAction("Forward");
        m_MKB_Backward = m_MKB.GetAction("Backward");
        m_MKB_Left = m_MKB.GetAction("Left");
        m_MKB_Right = m_MKB.GetAction("Right");
        m_MKB_Primary = m_MKB.GetAction("Primary");
        m_MKB_Rotate = m_MKB.GetAction("Rotate");
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
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Crouch;
    private readonly InputAction m_Gameplay_Primary;
    private readonly InputAction m_Gameplay_Secondary;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Drop;
    private readonly InputAction m_Gameplay_Swap;
    private readonly InputAction m_Gameplay_Sprint;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Join;
    public struct GameplayActions
    {
        private PlayerControls m_Wrapper;
        public GameplayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
        public InputAction @Primary => m_Wrapper.m_Gameplay_Primary;
        public InputAction @Secondary => m_Wrapper.m_Gameplay_Secondary;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputAction @Swap => m_Wrapper.m_Gameplay_Swap;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Join => m_Wrapper.m_Gameplay_Join;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Crouch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                Crouch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                Crouch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                Primary.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimary;
                Primary.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimary;
                Primary.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimary;
                Secondary.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondary;
                Secondary.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondary;
                Secondary.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondary;
                Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                Swap.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwap;
                Swap.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwap;
                Swap.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwap;
                Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                Join.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoin;
                Join.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoin;
                Join.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoin;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Rotate.started += instance.OnRotate;
                Rotate.performed += instance.OnRotate;
                Rotate.canceled += instance.OnRotate;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Crouch.started += instance.OnCrouch;
                Crouch.performed += instance.OnCrouch;
                Crouch.canceled += instance.OnCrouch;
                Primary.started += instance.OnPrimary;
                Primary.performed += instance.OnPrimary;
                Primary.canceled += instance.OnPrimary;
                Secondary.started += instance.OnSecondary;
                Secondary.performed += instance.OnSecondary;
                Secondary.canceled += instance.OnSecondary;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
                Drop.started += instance.OnDrop;
                Drop.performed += instance.OnDrop;
                Drop.canceled += instance.OnDrop;
                Swap.started += instance.OnSwap;
                Swap.performed += instance.OnSwap;
                Swap.canceled += instance.OnSwap;
                Sprint.started += instance.OnSprint;
                Sprint.performed += instance.OnSprint;
                Sprint.canceled += instance.OnSprint;
                Pause.started += instance.OnPause;
                Pause.performed += instance.OnPause;
                Pause.canceled += instance.OnPause;
                Join.started += instance.OnJoin;
                Join.performed += instance.OnJoin;
                Join.canceled += instance.OnJoin;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // MKB
    private readonly InputActionMap m_MKB;
    private IMKBActions m_MKBActionsCallbackInterface;
    private readonly InputAction m_MKB_Jump;
    private readonly InputAction m_MKB_Crouch;
    private readonly InputAction m_MKB_Sprint;
    private readonly InputAction m_MKB_Swap;
    private readonly InputAction m_MKB_Drop;
    private readonly InputAction m_MKB_Interact;
    private readonly InputAction m_MKB_Secondary;
    private readonly InputAction m_MKB_Join;
    private readonly InputAction m_MKB_Forward;
    private readonly InputAction m_MKB_Backward;
    private readonly InputAction m_MKB_Left;
    private readonly InputAction m_MKB_Right;
    private readonly InputAction m_MKB_Primary;
    private readonly InputAction m_MKB_Rotate;
    public struct MKBActions
    {
        private PlayerControls m_Wrapper;
        public MKBActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_MKB_Jump;
        public InputAction @Crouch => m_Wrapper.m_MKB_Crouch;
        public InputAction @Sprint => m_Wrapper.m_MKB_Sprint;
        public InputAction @Swap => m_Wrapper.m_MKB_Swap;
        public InputAction @Drop => m_Wrapper.m_MKB_Drop;
        public InputAction @Interact => m_Wrapper.m_MKB_Interact;
        public InputAction @Secondary => m_Wrapper.m_MKB_Secondary;
        public InputAction @Join => m_Wrapper.m_MKB_Join;
        public InputAction @Forward => m_Wrapper.m_MKB_Forward;
        public InputAction @Backward => m_Wrapper.m_MKB_Backward;
        public InputAction @Left => m_Wrapper.m_MKB_Left;
        public InputAction @Right => m_Wrapper.m_MKB_Right;
        public InputAction @Primary => m_Wrapper.m_MKB_Primary;
        public InputAction @Rotate => m_Wrapper.m_MKB_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_MKB; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MKBActions set) { return set.Get(); }
        public void SetCallbacks(IMKBActions instance)
        {
            if (m_Wrapper.m_MKBActionsCallbackInterface != null)
            {
                Jump.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnJump;
                Crouch.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnCrouch;
                Crouch.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnCrouch;
                Crouch.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnCrouch;
                Sprint.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnSprint;
                Sprint.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnSprint;
                Sprint.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnSprint;
                Swap.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnSwap;
                Swap.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnSwap;
                Swap.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnSwap;
                Drop.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnDrop;
                Drop.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnDrop;
                Drop.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnDrop;
                Interact.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnInteract;
                Secondary.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnSecondary;
                Secondary.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnSecondary;
                Secondary.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnSecondary;
                Join.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnJoin;
                Join.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnJoin;
                Join.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnJoin;
                Forward.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnForward;
                Forward.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnForward;
                Forward.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnForward;
                Backward.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnBackward;
                Backward.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnBackward;
                Backward.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnBackward;
                Left.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnLeft;
                Left.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnLeft;
                Left.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnLeft;
                Right.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnRight;
                Right.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnRight;
                Right.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnRight;
                Primary.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnPrimary;
                Primary.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnPrimary;
                Primary.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnPrimary;
                Rotate.started -= m_Wrapper.m_MKBActionsCallbackInterface.OnRotate;
                Rotate.performed -= m_Wrapper.m_MKBActionsCallbackInterface.OnRotate;
                Rotate.canceled -= m_Wrapper.m_MKBActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_MKBActionsCallbackInterface = instance;
            if (instance != null)
            {
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Crouch.started += instance.OnCrouch;
                Crouch.performed += instance.OnCrouch;
                Crouch.canceled += instance.OnCrouch;
                Sprint.started += instance.OnSprint;
                Sprint.performed += instance.OnSprint;
                Sprint.canceled += instance.OnSprint;
                Swap.started += instance.OnSwap;
                Swap.performed += instance.OnSwap;
                Swap.canceled += instance.OnSwap;
                Drop.started += instance.OnDrop;
                Drop.performed += instance.OnDrop;
                Drop.canceled += instance.OnDrop;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
                Secondary.started += instance.OnSecondary;
                Secondary.performed += instance.OnSecondary;
                Secondary.canceled += instance.OnSecondary;
                Join.started += instance.OnJoin;
                Join.performed += instance.OnJoin;
                Join.canceled += instance.OnJoin;
                Forward.started += instance.OnForward;
                Forward.performed += instance.OnForward;
                Forward.canceled += instance.OnForward;
                Backward.started += instance.OnBackward;
                Backward.performed += instance.OnBackward;
                Backward.canceled += instance.OnBackward;
                Left.started += instance.OnLeft;
                Left.performed += instance.OnLeft;
                Left.canceled += instance.OnLeft;
                Right.started += instance.OnRight;
                Right.performed += instance.OnRight;
                Right.canceled += instance.OnRight;
                Primary.started += instance.OnPrimary;
                Primary.performed += instance.OnPrimary;
                Primary.canceled += instance.OnPrimary;
                Rotate.started += instance.OnRotate;
                Rotate.performed += instance.OnRotate;
                Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public MKBActions @MKB => new MKBActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnJoin(InputAction.CallbackContext context);
    }
    public interface IMKBActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnJoin(InputAction.CallbackContext context);
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnPrimary(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
