MifuminLib.MifuminUITypeEditor

�o�[�W�����F1.0.0
����ҁF����
URL�Fhttps://tgws.plus/

�y�T�v�z
PropertyGrid��֗��ɂ���N���X�Q�ł��B
�ߋ��Ɍ��J���Ă���PropertyGrid�p��UITypeEditor��2�퓝���������̂ł��B
EncodingEditor��EnumFlagEditor���܂܂�܂��B

�yEncodingEditor�z
�����G���R�[�f�B���O��PropertyGrid�ŕҏW�ł���悤�ɂ��܂��B
�EEncoding�^
�E�R�[�h�y�[�WID��int�^(Encoding.CodePage)
�EIANA�o�^����string�^(Encoding.WebName)
�ɑΉ����Ă��܂��B

�������G���R�[�f�B���O�Ƃ��ėL���Ȓl�ł̂ݐ���ɓ��삵�܂��B
null�Ȃǖ����ȃf�[�^�̂Ƃ��ɗp�����ꍇ�A�G���[���������܂��B

�yEncodingEditor�g�p��z
using System.ComponentModel;
using System.Drawing.Design;

class MyClass
{
    [TypeConverter(typeof(MifuminLib.MifuminUITypeEditor.EncodingTypeConverter))]
    [Editor(typeof(MifuminLib.MifuminUITypeEditor.EncodingEditor), typeof(UITypeEditor))]
    public int CodePage { get; set; }
}

�yEnumFlagEditor�z
Flags�����̕t�����񋓌^��PropertyGrid�ŕҏW�ł���悤�ɂ��܂��B
���݁A�v�f�̊�̌^��int�݂̂ŁA�G���[�����͂��܂�s���Ă���܂���B
�l�I�ɂ�����Ǝg�����炢�Ȃ猋�\�֗������B

�yEnumFlagEditor�g�p��z
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

�y���C�Z���X�z
�{�v���O�����́A���������쌠��ۗL���Ă���AWTFPL�ɂ�藘�p��������܂��B
�ɗ͂��ꂢ�Ȍ��t�Ń��C�Z���X���e��v�񂵂܂��ƁA�u�D���ɂ��₪��N�\�v�Ƃ����Ӗ��ł��B
�ڂ����́Alicense.txt���������������B

�y�\�[�X�R�[�h�z
https://github.com/mifumi323/MifuminUITypeEditor
�ɂāA���J���Ă��܂��B
���C�Z���X�́A�o�C�i���A�\�[�X�R�[�h���ɓ����ł��B

�y�����z
1.0.0
�@���J
