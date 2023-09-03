using System;
using UIFramework;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private UISettings _uiSettings;
        
        [Inject]
        private UISystem _uiSystem;
        
        private void Start()
        {
            _uiSystem.Init(_uiSettings);
            
            _uiSystem.ShowPanel(UIPanelDefine.Lobby.ToString());
            _uiSystem.ShowPanel(UIPanelDefine.Info.ToString(), new InfoPanelData()
            {
                Level = 99,
                Gem = 3000,
                Power = 10
            });
        }

        private void Update()
        {
            
        }
    }
}