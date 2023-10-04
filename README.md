# BSOSampleProject
BinaryScriptableObjectのUnityサンプルプロジェクト。  
機能追加・調整開発や動作確認等にお使いください。

## ■対応UnityEditorバージョン
2020.3.7f1以降  
※UPされているプロジェクトは2020.3.7f1でセットアップされています。  
※2020.3.7f1以降の場合は自動コンバートを行ってください。

## ■確認用ツールの使用方法
UnityのメニューバーのTest→BsoTestWindowで起動できます。  
起動したら、下記画像の赤枠内の設定を好きなように弄って、  
画面下部（緑枠）の各種ボタンを押して、動作を確認してください。  
<img width="600" src="https://raw.githubusercontent.com/YumaEdwards/BSOSampleProject/feature/UpdateReadme/DocumentAssets/HowToUse/img_20231004_00.png">  
※現状、循環参照に関する問題がある為、BsoTestSetting設定アセットとバイナリ設定アセットはセットしないようにしてください。  
　将来的に修正を行いますので、しばらくの間、ご不便をおかけしますが、上記設定は行わないようにお願いします。

## ■保存状態確認について
保存状態の確認は簡易的になりますが、下記設定アセットでご確認ください。  
`Assets/Editor/BsoTestWindow/_Resource/BsoTestSetting.asset`  
この設定アセットを選択しながら、確認用ツールで読み書きを行うことで保存状態を確認できます。  
<img width="600" src="https://raw.githubusercontent.com/YumaEdwards/BSOSampleProject/feature/UpdateReadme/DocumentAssets/HowToUse/img_20231004_01.png">  

## ■サンプルスクリプトのコードについて
サンプルスクリプトのコードは下記に保存されています。  
<table>
  <thead>
    <tr>
      <th>ファイルパス</th>
      <th>説明</th>
    </tr>
  </thead>
  <tr>
    <td>Assets/Editor/BsoTestWindow/BsoTestWindow.cs</td>
    <td>確認用ツールのウィンドウ本体</td>
  </tr>
  <tr>
    <td>Assets/Editor/BsoTestWindow/BsoTestSetting.cs</td>
    <td>確認用ツールの設定ファイル制御用。<br />実装方法・使用方法はこちらのソースコードを参考にしてください。</td>
  </tr>
</table>
