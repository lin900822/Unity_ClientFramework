using System;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Widget
{
    [Serializable]
    public class ShopPackageData : UIData
    {
        public int Count;
        public int Price;
    }

    public class ShopPackageWidget : UIWidget
    {
        [SerializeField] private Text   _gemCountTxt;
        [SerializeField] private Text   _priceTxt;
        [SerializeField] private Button _buyBtn;
        [SerializeField] private Button _hintBtn;

        private ShopPackageData _uiData;

        protected override void OnInit()
        {
            _buyBtn.onClick.AddListener(OnBuyBtnClicked);
            _hintBtn.onClick.AddListener(OnHintBtnClicked);
        }

        protected override void OnUIDataSet(UIData uiData)
        {
            if (uiData is ShopPackageData data)
            {
                _uiData = data;
                
                _gemCountTxt.text = "$" + data.Count;
                _priceTxt.text    = "$" + data.Price;
            }
        }

        private void OnBuyBtnClicked()
        {
            ConfirmPanelData data = new ConfirmPanelData()
            {
                Title           = "購買水晶",
                Message         = "確定購買嗎?",
                ConfirmCallback = () =>
                {
                    _uiSystem.InvokeEvent((int)UIEvents.BuyGem, _uiData);
                }
            };

            _uiSystem.ShowPanel(UIPanelDefine.Confirm.ToString(), data);
        }

        private void OnHintBtnClicked()
        {
            HintPanelData panelData = new HintPanelData()
            {
                Title    = "Tips",
                Message  = "這是最新優惠!",
            };

            _uiSystem.ShowPanel(UIPanelDefine.PackageHint.ToString(), panelData);
        }
    }
}