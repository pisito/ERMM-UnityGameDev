using ERMM.GenericData.Utility;

namespace ERMM.GenericData
{
    public enum ENUM_ItemType
    {
        [DisplayText("Equipment")]
        Equipment,
        [DisplayText("Consumable")]
        Consumable,
        [DisplayText("Quest")]
        Quest,
        [DisplayText("Misc")]
        Misc 
    }
}