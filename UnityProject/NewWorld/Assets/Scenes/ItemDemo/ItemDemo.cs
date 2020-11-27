/************************
	FileName:/Scenes/ItemDemo/ItemDemo.cs
	CreateAuthor:neo.xu
	CreateTime:11/27/2020 4:31:48 PM
	Tip:11/27/2020 4:31:48 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Logic
{
    public class ItemDemo : MonoBehaviour
    {
        [SerializeField] private List<InteractableObject> m_LstInteractObj;
        [SerializeField] private Button m_BtnInteract;
        [SerializeField] private Button m_BtnOver;

        private int m_CurIndex = 0;

        private void Awake()
        {
            m_BtnInteract.onClick.AddListener(OnClickInteract);
            m_BtnOver.onClick.AddListener(OnClickOver);
        }



        private void OnClickInteract()
        {
            m_LstInteractObj[m_CurIndex].Interact(null);
        }


        private void OnClickOver()
        {
            m_LstInteractObj[m_CurIndex].InteractOver(null);
        }

    }

}