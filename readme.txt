MifuminLib.MifuminUITypeEditor

バージョン：1.0.0
制作者：美文
URL：https://tgws.plus/

【概要】
PropertyGridを便利にするクラス群です。
過去に公開していたPropertyGrid用のUITypeEditorを2種統合したものです。
EncodingEditorとEnumFlagEditorが含まれます。

【EncodingEditor】
文字エンコーディングをPropertyGridで編集できるようにします。
・Encoding型
・コードページIDのint型(Encoding.CodePage)
・IANA登録名のstring型(Encoding.WebName)
に対応しています。

※文字エンコーディングとして有効な値でのみ正常に動作します。
nullなど無効なデータのときに用いた場合、エラーが発生します。

【EncodingEditor使用例】
using System.ComponentModel;
using System.Drawing.Design;

class MyClass
{
    [TypeConverter(typeof(MifuminLib.MifuminUITypeEditor.EncodingTypeConverter))]
    [Editor(typeof(MifuminLib.MifuminUITypeEditor.EncodingEditor), typeof(UITypeEditor))]
    public int CodePage { get; set; }
}

【EnumFlagEditor】
Flags属性の付いた列挙型をPropertyGridで編集できるようにします。
現在、要素の基の型はintのみで、エラー処理はあまり行っておりません。
個人的にちょっと使うぐらいなら結構便利かも。

【EnumFlagEditor使用例】
using System;
using System.ComponentModel;
using System.Drawing.Design;

[Flags]
[Editor(typeof(MifuminLib.MifuminUITypeEditor.EnumFlagEditor), typeof(UITypeEditor))]
public enum MyFlag
{
    None = 0x0,
    Flag1 = 0x1,
    Flag2 = 0x2,
    Flag3 = 0x4,
    Flag4 = 0x8,
    All = 0xf,
}

【ライセンス】
本プログラムは、美文が著作権を保有しており、WTFPLにより利用許諾されます。
極力きれいな言葉でライセンス内容を要約しますと、「好きにしやがれクソ」という意味です。
詳しくは、license.txtをご覧ください。

【ソースコード】
https://github.com/mifumi323/MifuminUITypeEditor
にて、公開しています。
ライセンスは、バイナリ、ソースコード共に同じです。

【履歴】
1.0.0
　公開
