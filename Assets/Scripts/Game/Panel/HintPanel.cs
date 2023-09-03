using System;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [Serializable]
    public class HintPanelData : UIData
    {
        public string Title;
        public string Message;
    }
    
    public class HintPanel : UIPanel
    {
        [SerializeField] private Text          _titleTxt;
        [SerializeField] private Text          _messageTxt;
        
        protected override void OnUIDataSet(UIData data)
        {
            if (data is HintPanelData uiData)
            {
                _titleTxt.text   = uiData.Title;
                _messageTxt.text = uiData.Message;
            }
        }
    }
}