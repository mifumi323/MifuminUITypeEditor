using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MifuminLib.MifuminUITypeEditor
{
    /// <summary>
    /// Flags属性の付いた列挙型をPropertyGridで編集できるようにします。
    /// </summary>
    public class EnumFlagEditor : UITypeEditor
    {
        private CheckedListBox _ui = null;
        private int _value = 0;
        ItemCheckEventHandler _checkevent = null;
        
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (!value.GetType().IsEnum) throw new ArgumentException();
            IWindowsFormsEditorService editservice = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (_ui == null)
            {
                _ui = new CheckedListBox();
                _checkevent = new ItemCheckEventHandler(ui_ItemCheck);
            }
            SetItems(value);
            _value = (int)value;
            UpdateUI();
            editservice.DropDownControl(_ui);
            return _value;
        }

        private void UpdateUI()
        {
            _ui.ItemCheck -= _checkevent;
            for (int i = 0; i < _ui.Items.Count; i++)
            {
                int item = (int)_ui.Items[i];
                if (item != 0)
                {
                    _ui.SetItemChecked(i, (_value & item) == item);
                }
                else
                {
                    _ui.SetItemChecked(i, _value == 0);
                }
            }
            _ui.ItemCheck += _checkevent;
        }

        private void SetItems(object value)
        {
            var t = value.GetType();
            _ui.Items.Clear();
            Array values = t.GetEnumValues();
            object[] items = new object[values.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = values.GetValue(i);
            }
            _ui.Items.AddRange(items);
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override bool IsDropDownResizable
        { get { return true; } }

        public void ui_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int value = (int)_ui.Items[e.Index];
            if (value != 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    _value |= value;
                }
                else
                {
                    _value &= ~value;
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    _value = 0;
                }
                else
                {
                    foreach (var item in _ui.Items)
                    {
                        _value |= (int)item;
                    }
                }
            }
            UpdateUI();
        }
    }
}
