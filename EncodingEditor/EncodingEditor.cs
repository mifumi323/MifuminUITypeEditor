using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MifuminLib.MifuminUITypeEditor
{
    /// <summary>
    /// 文字エンコーディングをPropertyGridで編集できるようにします。
    /// </summary>
    public class EncodingEditor : UITypeEditor
    {
        private ListBox ui = null;

        private class EncodingListItem
        {
            private int _codepage;
            public EncodingListItem(int codepage) { _codepage = codepage; }
            public EncodingListItem(Encoding e) : this(e.CodePage) { }
//            public EncodingListItem(EncodingInfo ei) : this(ei.CodePage) { }
            public EncodingListItem(string name) : this(Encoding.GetEncoding(name)) { }
            public EncodingListItem(object obj)
            {
                if (obj is int) { _codepage = (int)obj; }
                else if (obj is Encoding) { _codepage = ((Encoding)obj).CodePage; }
                else if (obj is string) { _codepage = Encoding.GetEncoding((string)obj).CodePage; }
                else throw new ArgumentException();
            }

            public override string ToString()
            {
                return Encoding.GetEncoding(_codepage).EncodingName;
            }
            public override bool Equals(object obj)
            {
                if (!(obj is EncodingListItem)) return false;
                return ((EncodingListItem)obj)._codepage == _codepage;
            }
            public override int GetHashCode()
            {
                return _codepage;
            }

            public object GetObject(Type type)
            {
                if (type == typeof(int)) return _codepage;
                if (type == typeof(Encoding)) return Encoding.GetEncoding(_codepage);
                if (type == typeof(string)) return Encoding.GetEncoding(_codepage).WebName;
                throw new ArgumentException();
            }
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            EncodingListItem item = new EncodingListItem(value);
            IWindowsFormsEditorService editservice = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (ui == null)
            {
                ui = new ListBox();
                ui.Items.AddRange(GetEncodings());
            }
            ui.SelectedItem = item;
            editservice.DropDownControl(ui);
            return ((EncodingListItem)(ui.SelectedItem)).GetObject(value.GetType());
        }

        private EncodingListItem[] GetEncodings()
        {
            EncodingInfo[] infos = Encoding.GetEncodings();
            EncodingListItem[] items = new EncodingListItem[infos.Length];
            for (int i = 0; i < infos.Length; i++)
            {
                items[i] = new EncodingListItem(infos[i].CodePage);
            }
            return items;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override bool IsDropDownResizable
        { get { return true; } }
    }

    /// <summary>
    /// 文字エンコーディングの名前を表示します。
    /// </summary>
    public class EncodingTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value is int) return Encoding.GetEncoding((int)value).EncodingName;
                if (value is Encoding) return ((Encoding)value).EncodingName;
                if (value is string) return Encoding.GetEncoding((string)value).EncodingName;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
