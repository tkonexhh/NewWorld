namespace Game.Logic
{
    public partial class TDCharacterAppearance
    {
        public void Reset()
        {

        }

        private AppearanceSlot m_Slot = AppearanceSlot.Length;
        public AppearanceSlot slot
        {
            get
            {
                if (m_Slot == AppearanceSlot.Length)
                {
                    m_Slot = CharacterEnumHelper.GetSlotByName(Part);
                }
                return m_Slot;
            }
        }

        public Sex sex => m_Sex == 0 ? Game.Logic.Sex.Male : Game.Logic.Sex.Female;


    }
}