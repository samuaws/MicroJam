//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/Actions/Actions.inputactions
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

public partial class @Actions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""Abilities"",
            ""id"": ""2f388ed2-ff43-43aa-91d9-69ae6e3128eb"",
            ""actions"": [
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""46fb544b-0d72-45d0-901c-d73a98950451"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""547979ed-5265-4fe8-948f-df5e5bcd48bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Invisible"",
                    ""type"": ""Button"",
                    ""id"": ""e7619b69-4048-422c-8114-a66f40522130"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""342070f0-6634-41a6-96a0-2435995e371e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c09ce72f-dfab-46c9-84bb-8ecccfbb320b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ec596eb-cf78-40bd-b86b-ac765e894ccc"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Invisible"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Abilities
        m_Abilities = asset.FindActionMap("Abilities", throwIfNotFound: true);
        m_Abilities_Ability = m_Abilities.FindAction("Ability", throwIfNotFound: true);
        m_Abilities_Dash = m_Abilities.FindAction("Dash", throwIfNotFound: true);
        m_Abilities_Invisible = m_Abilities.FindAction("Invisible", throwIfNotFound: true);
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

    // Abilities
    private readonly InputActionMap m_Abilities;
    private List<IAbilitiesActions> m_AbilitiesActionsCallbackInterfaces = new List<IAbilitiesActions>();
    private readonly InputAction m_Abilities_Ability;
    private readonly InputAction m_Abilities_Dash;
    private readonly InputAction m_Abilities_Invisible;
    public struct AbilitiesActions
    {
        private @Actions m_Wrapper;
        public AbilitiesActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ability => m_Wrapper.m_Abilities_Ability;
        public InputAction @Dash => m_Wrapper.m_Abilities_Dash;
        public InputAction @Invisible => m_Wrapper.m_Abilities_Invisible;
        public InputActionMap Get() { return m_Wrapper.m_Abilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilitiesActions set) { return set.Get(); }
        public void AddCallbacks(IAbilitiesActions instance)
        {
            if (instance == null || m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Add(instance);
            @Ability.started += instance.OnAbility;
            @Ability.performed += instance.OnAbility;
            @Ability.canceled += instance.OnAbility;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Invisible.started += instance.OnInvisible;
            @Invisible.performed += instance.OnInvisible;
            @Invisible.canceled += instance.OnInvisible;
        }

        private void UnregisterCallbacks(IAbilitiesActions instance)
        {
            @Ability.started -= instance.OnAbility;
            @Ability.performed -= instance.OnAbility;
            @Ability.canceled -= instance.OnAbility;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Invisible.started -= instance.OnInvisible;
            @Invisible.performed -= instance.OnInvisible;
            @Invisible.canceled -= instance.OnInvisible;
        }

        public void RemoveCallbacks(IAbilitiesActions instance)
        {
            if (m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAbilitiesActions instance)
        {
            foreach (var item in m_Wrapper.m_AbilitiesActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AbilitiesActions @Abilities => new AbilitiesActions(this);
    public interface IAbilitiesActions
    {
        void OnAbility(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnInvisible(InputAction.CallbackContext context);
    }
}