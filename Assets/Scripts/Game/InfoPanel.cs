using Game.Widget;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class InfoPanelData : UIData
    {
        public int Level;
        public int Gem;
        public int Power;
    }
    
    public class InfoPanel : UIPanel
    {
        [SerializeField] private Text _levelTxt;
        [SerializeField] private Text _gemTxt;
        [SerializeField] private Text _powerTxt;

        private InfoPanelData _uiData;

        protected override void OnInit()
        {
            _uiSystem.RegisterEventHandler((int)UIEvents.BuyGem, HandleBuyGem);
        }

        private void HandleBuyGem(UIData data)
        {
            ShopPackageData shopPackageData = data as ShopPackageData;
            if (shopPackageData != null)
            {
                _uiData.Gem += shopPackageData.Count;
                OnUIDataSet(_uiData);
            }
        }

        protected override void OnUIDataSet(UIData data)
        {
            if (data is InfoPanelData uiData)
            {
                _uiData = uiData;
                
                _levelTxt.text = uiData.Level.ToString();
                _gemTxt.text   = uiData.Gem.ToString();
                _powerTxt.text = uiData.Power.ToString();
            }
        }
    }
}