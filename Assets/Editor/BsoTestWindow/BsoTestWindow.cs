using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Yuma.Editor.Bso
{
    internal class BsoTestWindow : EditorWindow
    {
        [SerializeField]
        private int _intTest;
        [SerializeField,Range(0, 1)]
        private float _sliderValue = 0.5f;
        [SerializeField]
        private string _testString;
        [SerializeField]
        private List<UnityEngine.Object> _testAssets = new List<UnityEngine.Object>();
        [SerializeField]
        private BsoTestSetting.InnerTestSettingData _innerTestSetting = new BsoTestSetting.InnerTestSettingData();
        //-----------------------------------------------------------------------------
        private SerializedObject _serializedObject = null;//このウィンドウのシリアライズオブジェクト
        private Vector2          _scrollPos        = Vector2.zero;//ウィンドウ全体のScrollViewの位置(GUI描画用)
        private BsoTestSetting   _testSetting      = null;//確認用設定
        //-----------------------------------------------------------------------------
        
        
        //～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～
        //↓システム関連
        
        /// <summary>
        /// ウィンドウを表示する関数
        /// </summary>
        [MenuItem("Test/BsoTestWindow")]
        private static void ShowWindow()
        {
            var fWindow = GetWindow<BsoTestWindow>();
            fWindow.titleContent = new GUIContent("BsoTestWindow");
            fWindow.Show();
        }

        /// <summary>
        /// ウィンドウ作成時イベント関数
        /// </summary>
        private void CreateGUI()
        {
            _serializedObject = new SerializedObject(this);
            
            LoadSetting();

            if ( _testSetting == null )
            {
                string fErrorMsg = "設定ファイルが見つかりません。初めに「プロジェクトウィンドウで右クリック→Create→Test→BsoTestSetting」で動作テスト用設定アセットを作成してください。";
                EditorLog.Err($"[{GetType().Name}.{nameof(CreateGUI)}]_{fErrorMsg}");
                EditorUtility.DisplayDialog("設定ファイル読み込みエラー", fErrorMsg, "OK");
                return;
            }
        }
        
        /// <summary>
        /// ウィンドウGUI描画イベント関数
        /// </summary>
        private void OnGUI()
        {
            if ( _testSetting == null ) { Close(); return; }
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("下記設定を弄って、画面下部の各種ボタンを押してください");
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(_serializedObject.FindProperty("_intTest"),true);
            EditorGUILayout.PropertyField(_serializedObject.FindProperty("_sliderValue"),true);
            EditorGUILayout.PropertyField(_serializedObject.FindProperty("_testString"),true);
            EditorGUILayout.PropertyField(_serializedObject.FindProperty("_testAssets"),true);
            EditorGUILayout.PropertyField(_serializedObject.FindProperty("_innerTestSetting"),true);
            if ( EditorGUI.EndChangeCheck() ) { _serializedObject.ApplyModifiedProperties(); }
            
            EditorGUILayout.EndScrollView();
            
            if ( GUILayout.Button("設定内容の初期化") ) { Clear(); }
            EditorGUILayout.Separator();
            if ( GUILayout.Button("設定読み込み") ) { LoadSetting(); }
            if ( GUILayout.Button("設定を保存") ) { SaveSetting(); }
        }
        
        
        //～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～
        //↓基本機能関連
        
        /// <summary>
        /// 設定内容を初期化する関数
        /// </summary>
        private void Clear()
        {
            _intTest     = default;
            _sliderValue = 0.5f;
            _testString  = string.Empty;
            
            _testAssets.Clear();

            _innerTestSetting.innerIntTest     = default;
            _innerTestSetting.innerSliderValue = 0.5f;
            _innerTestSetting.innerTestString  = string.Empty;
            
            _innerTestSetting.innerTestAssets.Clear();
            
            _serializedObject.UpdateIfRequiredOrScript();
        }

        /// <summary>
        /// 設定内容を読み込む関数
        /// </summary>
        private void LoadSetting()
        {
            BsoTestSetting fTestSetting = EditorAssetUtility.LoadSettingAssetAtFileName<BsoTestSetting>(nameof(BsoTestSetting));
            
            if ( fTestSetting == null ) { return; }//読み込みに失敗していたらここで中断。
            
            _testSetting = fTestSetting;
            
            _testSetting.LoadBinary();//LoadSettingAssetAtFileName内でデフォルトのファイルパスは設定されているので、読み込みだけ行なう。
            
            _intTest          = _testSetting.intTest;
            _sliderValue      = _testSetting.sliderValue;
            _testString       = _testSetting.testString;
            
            _testAssets.Clear();
            _testAssets.AddRange(_testSetting.testAssets);
            
            _innerTestSetting.innerIntTest     = _testSetting.innerTestSetting.innerIntTest;
            _innerTestSetting.innerSliderValue = _testSetting.innerTestSetting.innerSliderValue;
            _innerTestSetting.innerTestString  = _testSetting.innerTestSetting.innerTestString;
            
            _innerTestSetting.innerTestAssets.Clear();
            _innerTestSetting.innerTestAssets.AddRange(_testSetting.innerTestSetting.innerTestAssets);
            
            _serializedObject.UpdateIfRequiredOrScript();
        }

        /// <summary>
        /// 設定内容を保存する関数
        /// </summary>
        /// <returns>保存に成功したかどうか(trueで成功)</returns>
        private void SaveSetting()
        {
            if ( _testSetting == null ) { return; }
            
            _testSetting.intTest          = _intTest;
            _testSetting.sliderValue      = _sliderValue;
            _testSetting.testString       = _testString;
            
            _testSetting.testAssets.Clear();
            _testSetting.testAssets.AddRange(_testAssets);
            
            _testSetting.innerTestSetting.innerIntTest     = _innerTestSetting.innerIntTest;
            _testSetting.innerTestSetting.innerSliderValue = _innerTestSetting.innerSliderValue;
            _testSetting.innerTestSetting.innerTestString  = _innerTestSetting.innerTestString;
            
            _testSetting.innerTestSetting.innerTestAssets.Clear();
            _testSetting.innerTestSetting.innerTestAssets.AddRange(_innerTestSetting.innerTestAssets);
            
            EditorUtility.SetDirty(_testSetting);
            _testSetting.SaveBinary();
        }
    }
}