// GENERATED AUTOMATICALLY FROM 'Assets/Res1/Input/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GameWish.Game
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
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""eb9e8b92-9731-4492-9c19-510b5ed5d7c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""4b268592-915f-4df5-bf3d-249fdcdf48a4"",
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
                    ""name"": ""SetpUpRotate"",
                    ""type"": ""Value"",
                    ""id"": ""7674ccc0-f445-4d0d-baa3-4e08a5f4f53c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SetpUpRotateMode"",
                    ""type"": ""Button"",
                    ""id"": ""59ea45cd-7091-4c30-9abc-3a5b02fddecd"",
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
                    ""name"": """",
                    ""id"": ""4132a3d7-eca2-439d-99d3-7ebd74e1fa56"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=2,y=2)"",
                    ""groups"": """",
                    ""action"": ""SetpUpRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51bef014-b058-4ff4-a1de-bd8724616fb0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetpUpRotateMode"",
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
            m_Main_Move = m_Main.FindAction("Move", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Any = m_UI.FindAction("Any", throwIfNotFound: true);
            m_UI_Move = m_UI.FindAction("Move", throwIfNotFound: true);
            m_UI_SetpUpRotate = m_UI.FindAction("SetpUpRotate", throwIfNotFound: true);
            m_UI_SetpUpRotateMode = m_UI.FindAction("SetpUpRotateMode", throwIfNotFound: true);
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
        private readonly InputAction m_Main_Move;
        public struct MainActions
        {
            private @GameInput m_Wrapper;
            public MainActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Main_Move;
            public InputActionMap Get() { return m_Wrapper.m_Main; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
            public void SetCallbacks(IMainActions instance)
            {
                if (m_Wrapper.m_MainActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_MainActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public MainActions @Main => new MainActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Any;
        private readonly InputAction m_UI_Move;
        private readonly InputAction m_UI_SetpUpRotate;
        private readonly InputAction m_UI_SetpUpRotateMode;
        public struct UIActions
        {
            private @GameInput m_Wrapper;
            public UIActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Any => m_Wrapper.m_UI_Any;
            public InputAction @Move => m_Wrapper.m_UI_Move;
            public InputAction @SetpUpRotate => m_Wrapper.m_UI_SetpUpRotate;
            public InputAction @SetpUpRotateMode => m_Wrapper.m_UI_SetpUpRotateMode;
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
                    @SetpUpRotate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSetpUpRotate;
                    @SetpUpRotate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSetpUpRotate;
                    @SetpUpRotate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSetpUpRotate;
                    @SetpUpRotateMode.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSetpUpRotateMode;
                    @SetpUpRotateMode.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSetpUpRotateMode;
                    @SetpUpRotateMode.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSetpUpRotateMode;
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
                    @SetpUpRotate.started += instance.OnSetpUpRotate;
                    @SetpUpRotate.performed += instance.OnSetpUpRotate;
                    @SetpUpRotate.canceled += instance.OnSetpUpRotate;
                    @SetpUpRotateMode.started += instance.OnSetpUpRotateMode;
                    @SetpUpRotateMode.performed += instance.OnSetpUpRotateMode;
                    @SetpUpRotateMode.canceled += instance.OnSetpUpRotateMode;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
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
            void OnMove(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnAny(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnSetpUpRotate(InputAction.CallbackContext context);
            void OnSetpUpRotateMode(InputAction.CallbackContext context);
        }
    }
}
