using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yuma.Editor.Bso
{
    [CreateAssetMenu(fileName = "BsoTestSetting", menuName = "Test/BsoTestSetting", order = 0)]
    internal class BsoTestSetting : BinaryScriptableObjectBase<BsoTestSetting>
    {
        [SerializeField,BinaryFieldId(0)]
        private int _intTest;
        [SerializeField,BinaryFieldId(1),Range(0, 1)]
        private float _sliderValue = 0.5f;
        [SerializeField,BinaryFieldId(2)]
        private string _testString;
        [SerializeField,BinaryFieldId(3)]
        private List<UnityEngine.Object> _testAssets = new List<UnityEngine.Object>();
        [SerializeField,BinaryFieldId(4)]
        private InnerTestSettingData _innerTestSetting = new InnerTestSettingData();
        //-----------------------------------------------------------------------------
        public int                      intTest          { get => _intTest;          set => _intTest = value; }
        public float                    sliderValue      { get => _sliderValue;      set => _sliderValue = value; }
        public string                   testString       { get => _testString;       set => _testString = value; }
        public List<UnityEngine.Object> testAssets       { get => _testAssets;       set => _testAssets = value; }
        public InnerTestSettingData     innerTestSetting { get => _innerTestSetting; set => _innerTestSetting = value; }
        //-----------------------------------------------------------------------------
        
        
        //～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～
        //↓データクラス関連
        
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class InnerTestSettingData
        {
            [BinaryFieldId(0)]
            public int innerIntTest;
            [BinaryFieldId(1),Range(0, 1)]
            public float innerSliderValue = 0.5f;
            [BinaryFieldId(2)]
            public string innerTestString;
            [BinaryFieldId(3)]
            public List<UnityEngine.Object> innerTestAssets = new List<UnityEngine.Object>();
        }
    }
}