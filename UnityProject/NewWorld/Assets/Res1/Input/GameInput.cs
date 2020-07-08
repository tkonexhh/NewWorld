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
                    ""name"": ""Any"",
                    ""type"": ""Button"",
                    ""id"": ""3d362ae9-4043-47e0-b08f-d7154babde03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
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
                },
                {
                    ""name"": """",
                    ""id"": ""495bd8fd-f2b2-43bc-a53c-432ea6b6c715"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Any"",
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
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Main
            m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
            m_Main_Any = m_Main.FindAction("Any", throwIfNotFound: true);
            m_Main_Move = m_Main.FindAction("Move", throwIfNotFound: true);
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
        private readonly InputAction m_Main_Any;
        private readonly InputAction m_Main_Move;
        public struct MainActions
        {
            private @GameInput m_Wrapper;
            public MainActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Any => m_Wrapper.m_Main_Any;
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
                    @Any.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAny;
                    @Any.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAny;
                    @Any.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAny;
                    @Move.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_MainActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Any.started += instance.OnAny;
                    @Any.performed += instance.OnAny;
                    @Any.canceled += instance.OnAny;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public MainActions @Main => new MainActions(this);
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
            void OnAny(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
        }
    }
}
