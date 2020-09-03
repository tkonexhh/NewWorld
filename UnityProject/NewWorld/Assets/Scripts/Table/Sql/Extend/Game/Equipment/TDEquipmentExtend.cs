namespace Game.Logic
{
    public partial class TDEquipment
    {
        public void Reset()
        {

        }


        public EquipmentType equipmentType
        {
            get
            {
                switch (m_Part)
                {
                    case "Helmet":
                        return EquipmentType.Helmet;
                    case "Torso":
                        return EquipmentType.Torso;
                }
                return EquipmentType.None;
            }
        }
    }
}