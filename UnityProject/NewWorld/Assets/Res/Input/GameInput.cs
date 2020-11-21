// GENERATED AUTOMATICALLY FROM 'Assets/Res/Input/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game.Logic
{
    public class @GameInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""d2ad7121-9cd0-43ee-b6d4-c1e965cc7f78"",
            ""actions"": [
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""80550caf-c344-4839-b854-5bc366143838"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eb9e8b92-9731-4492-9c19-510b5ed5d7c0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6f357db9-2900-4946-a8ec-dd54e5e97d72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Any"",
                    ""type"": ""Button"",
                    ""id"": ""92f933a8-6bd2-4500-b0c7-ed1c9f97f06b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""b5def97d-d91c-4af8-a2ce-a5143666f523"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackL"",
                    ""type"": ""Button"",
                    ""id"": ""e18bc34b-721b-4e98-87d7-cc05b5664230"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackR"",
                    ""type"": ""Button"",
                    ""id"": ""80cd85ad-9515-46a0-950d-cab81a73ac3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""4b268592-915f-4df5-bf3d-249fdcdf48a4"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""87dce656-a56a-48aa-8d19-f43b4c554a54"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7b30697e-92b7-42da-94c3-1b3ae122af18"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""96b6b766-94e2-41eb-8518-d55fad7d5096"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""591e0881-ce7e-428b-88b4-ac11563bb117"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""e268f849-8a38-469c-86f1-4d1f5fb4a757"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ccc9fc6d-cb57-477a-be7d-ee913d50740b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8768dc02-3733-43c9-99d9-c361ee765a4a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cae92e3d-0bf0-43fe-a9dd-a2b41e3b80c8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a0e62697-2fb4-400c-b8bb-356e83bef4c2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f509e303-1cf0-49cf-9bf7-9b0e4451cbf0"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Any"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29e5d86e-fdc3-4152-bcd9-dc0c8a91b99f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe538169-b4ac-4c3e-b780-32c6de44c33b"",
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
                    ""id"": ""d3c1bf15-11dc-4011-b2ad-6182d07438a1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61033f5b-d9f7-44ff-9eec-12f50e4520c0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2816e6e-86ec-4e71-964a-031f8ef32b6c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""387aa068-4484-40aa-bed9-c92f6abe791d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""68d7f72e-b2ac-42f7-b1cb-c12029c32907"",
            ""actions"": [
                {
                    ""name"": ""Any"",
                    ""type"": ""Button"",
                    ""id"": ""c53eb222-b329-4f3e-be01-0184aa8a061e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""e8d1360e-4c24-4607-a533-72ecc11001fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""d9a0dcd1-eb2d-4d01-858c-b2c0c28be808"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8abcf496-9dd4-4b53-871d-0e2f7b6c85f9"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Any"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WSAD"",
                    ""id"": ""a060da69-906f-4ad0-9909-eb877c6e14c8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""738924d5-72f9-4673-8c33-9b575b830827"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ce2c0ae-fd88-4885-8de2-5f3080a2abae"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5f44915d-3fc5-4ea9-bbee-d15275b1cdd7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eeb6301f-1b72-490b-a4a7-989a1745e671"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""3be16d5a-c4f1-4a77-b6eb-d6066d57210d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""82956700-259f-4987-ab5e-32e47499410e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b10343ea-cffe-4e51-8dc7-2906c4fdb6d4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2814f739-3e3e-4ad6-b5e5-729385ca415a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6679bcc0-60f7-4724-8db7-fe9cf9d02cc6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""77a6ede1-8f17-4921-a3ee-c114f58c4398"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f6a97f26-3a00-4038-bdec-a290eea31d7f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""911f8308-611f-45f2-9638-1b39d5087696"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Shortcut"",
            ""id"": ""f79117a0-28f6-41bf-a1ba-54763ee3664d"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""9cab53e5-e000-4192-9c1c-d08f8ccb764b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9acad71e-74a5-4416-b502-5010da23be24"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard"",
            ""bindingGroup"": ""KeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Main
            m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
            m_Main_Camera = m_Main.FindAction("Camera", throwIfNotFound: true);
            m_Main_Move = m_Main.FindAction("Move", throwIfNotFound: true);
            m_Main_Jump = m_Main.FindAction("Jump", throwIfNotFound: true);
            m_Main_Any = m_Main.FindAction("Any", throwIfNotFound: true);
            m_Main_Run = m_Main.FindAction("Run", throwIfNotFound: true);
            m_Main_AttackL = m_Main.FindAction("AttackL", throwIfNotFound: true);
            m_Main_AttackR = m_Main.FindAction("AttackR", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Any = m_UI.FindAction("Any", throwIfNotFound: true);
            m_UI_Move = m_UI.FindAction("Move", throwIfNotFound: true);
            m_UI_Rotate = m_UI.FindAction("Rotate", throwIfNotFound: true);
            // Shortcut
            m_Shortcut = asset.FindActionMap("Shortcut", throwIfNotFound: true);
            m_Shortcut_Inventory = m_Shortcut.FindAction("Inventory", throwIfNotFound: true);
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

        // Main
        private readonly InputActionMap m_Main;
        private IMainActions m_MainActionsCallbackInterface;
        private readonly InputAction m_Main_Camera;
        private readonly InputAction m_Main_Move;
        private readonly InputAction m_Main_Jump;
        private readonly InputAction m_Main_Any;
        private readonly InputAction m_Main_Run;
        private readonly InputAction m_Main_AttackL;
        private readonly InputAction m_Main_AttackR;
        public struct MainActions
        {
            private @GameInput m_Wrapper;
            public MainActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Camera => m_Wrapper.m_Main_Camera;
            public InputAction @Move => m_Wrapper.m_Main_Move;
            public InputAction @Jump => m_Wrapper.m_Main_Jump;
            public InputAction @Any => m_Wrapper.m_Main_Any;
            public InputAction @Run => m_Wrapper.m_Main_Run;
            public InputAction @AttackL => m_Wrapper.m_Main_AttackL;
            public InputAction @AttackR => m_Wrapper.m_Main_AttackR;
            public InputActionMap Get() { return m_Wrapper.m_Main; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
            public void SetCallbacks(IMainActions instance)
            {
                if (m_Wrapper.m_MainActionsCallbackInterface != null)
                {
                    @Camera.started -= m_Wrapper.m_MainActionsCallbackInterface.OnCamera;
                    @Camera.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnCamera;
                    @Camera.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnCamera;
                    @Move.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_MainActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnJump;
                    @Any.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAny;
                    @Any.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAny;
                    @Any.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAny;
                    @Run.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRun;
                    @Run.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRun;
                    @Run.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRun;
                    @AttackL.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAttackL;
                    @AttackL.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAttackL;
                    @AttackL.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAttackL;
                    @AttackR.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAttackR;
                    @AttackR.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAttackR;
                    @AttackR.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAttackR;
                }
                m_Wrapper.m_MainActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Camera.started += instance.OnCamera;
                    @Camera.performed += instance.OnCamera;
                    @Camera.canceled += instance.OnCamera;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Any.started += instance.OnAny;
                    @Any.performed += instance.OnAny;
                    @Any.canceled += instance.OnAny;
                    @Run.started += instance.OnRun;
                    @Run.performed += instance.OnRun;
                    @Run.canceled += instance.OnRun;
                    @AttackL.started += instance.OnAttackL;
                    @AttackL.performed += instance.OnAttackL;
                    @AttackL.canceled += instance.OnAttackL;
                    @AttackR.started += instance.OnAttackR;
                    @AttackR.performed += instance.OnAttackR;
                    @AttackR.canceled += instance.OnAttackR;
                }
            }
        }
        public MainActions @Main => new MainActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Any;
        private readonly InputAction m_UI_Move;
        private readonly InputAction m_UI_Rotate;
        public struct UIActions
        {
            private @GameInput m_Wrapper;
            public UIActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Any => m_Wrapper.m_UI_Any;
            public InputAction @Move => m_Wrapper.m_UI_Move;
            public InputAction @Rotate => m_Wrapper.m_UI_Rotate;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Any.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAny;
                    @Any.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAny;
                    @Any.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAny;
                    @Move.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                    @Rotate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRotate;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Any.started += instance.OnAny;
                    @Any.performed += instance.OnAny;
                    @Any.canceled += instance.OnAny;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                }
            }
        }
        public UIActions @UI => new UIActions(this);

        // Shortcut
        private readonly InputActionMap m_Shortcut;
        private IShortcutActions m_ShortcutActionsCallbackInterface;
        private readonly InputAction m_Shortcut_Inventory;
        public struct ShortcutActions
        {
            private @GameInput m_Wrapper;
            public ShortcutActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Inventory => m_Wrapper.m_Shortcut_Inventory;
            public InputActionMap Get() { return m_Wrapper.m_Shortcut; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ShortcutActions set) { return set.Get(); }
            public void SetCallbacks(IShortcutActions instance)
            {
                if (m_Wrapper.m_ShortcutActionsCallbackInterface != null)
                {
                    @Inventory.started -= m_Wrapper.m_ShortcutActionsCallbackInterface.OnInventory;
                    @Inventory.performed -= m_Wrapper.m_ShortcutActionsCallbackInterface.OnInventory;
                    @Inventory.canceled -= m_Wrapper.m_ShortcutActionsCallbackInterface.OnInventory;
                }
                m_Wrapper.m_ShortcutActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Inventory.started += instance.OnInventory;
                    @Inventory.performed += instance.OnInventory;
                    @Inventory.canceled += instance.OnInventory;
                }
            }
        }
        public ShortcutActions @Shortcut => new ShortcutActions(this);
        private int m_KeyBoardSchemeIndex = -1;
        public InputControlScheme KeyBoardScheme
        {
            get
            {
                if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
                return asset.controlSchemes[m_KeyBoardSchemeIndex];
            }
        }
        public interface IMainActions
        {
            void OnCamera(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAny(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnAttackL(InputAction.CallbackContext context);
            void OnAttackR(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnAny(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
        }
        public interface IShortcutActions
        {
            void OnInventory(InputAction.CallbackContext context);
        }
    }
}
