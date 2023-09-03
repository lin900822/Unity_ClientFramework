using Game.Widget;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class ShopPanel : UIPanel
    {
        [SerializeField] private Button _backBtn;

        [SerializeField] private Button[] _packageBtns;

        [SerializeField] private ShopPackageWidget[] _shopPackageWidgets;

        [SerializeField] private ShopPackageData[] _datas;

        private int _selectedIndex = 0;

        protected override void OnInit()
        {
            _backBtn.onClick.AddListener(OnBackBtnClicked);

            for (int i = 0; i < _packageBtns.Length; i++)
            {
                int j = i;
                _packageBtns[i].onClick.AddListener(() =>
                {
                    _selectedIndex = j;
                    OnPackageBtnClicked(j);
                });
            }
        }

        protected override void OnStartShow()
        {
            ShowSelectWidget(_selectedIndex);
            
            _uiSystem.ShowPanel(UIPanelDefine.Info.ToString());
        }

        private void OnBackBtnClicked()
        {
            _uiSystem.HidePeekPanel();
        }

        private void OnPackageBtnClicked(int index)
        {
            ShowSelectWidget(index);
        }

        private void ShowSelectWidget(int index)
        {
            for (var i = 0; i < _shopPackageWidgets.Length; i++)
            {
                if (i == index)
                {
                    _shopPackageWidgets[index].SetData(_datas[index]);
                    _shopPackageWidgets[index].StartShow();
                }
                else
                {
                    _shopPackageWidgets[i].StartHide(false);
                }
            }
        }
    }
}