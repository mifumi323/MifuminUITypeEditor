using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace MifuminUITypeEditorSample
{
    class MyClass
    {
        [Description("EncodingEditorの使用例です。")]
        [TypeConverter(typeof(MifuminLib.MifuminUITypeEditor.EncodingTypeConverter))]
        [Editor(typeof(MifuminLib.MifuminUITypeEditor.EncodingEditor), typeof(UITypeEditor))]
        public int CodePage { get; set; }

        [Description("EnumFlagEditorの使用例です。")]
        public MyFlag Flags { get; set; }
    }

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

}
