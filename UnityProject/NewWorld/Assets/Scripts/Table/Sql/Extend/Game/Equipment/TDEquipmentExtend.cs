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
                    case "Hands":
                        return EquipmentType.Hands;
                    case "Legs":
                        return EquipmentType.Legs;
                    case "Hips":
                        return EquipmentType.Hips;
                    case "Shoulders":
                        return EquipmentType.Shoulders;
                }
                return EquipmentType.None;
            }
        }
    }
}