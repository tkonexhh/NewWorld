namespace GameWish.Game
{
    public partial class TDItem
    {
        public void Reset()
        {

        }

        public ItemType itemType
        {
            get
            {
                switch (m_Type)
                {
                    case "Food":
                        return ItemType.Food;
                    case "Equipment":
                        return ItemType.Equipment;
                }
                return ItemType.Other;
            }
        }
    }
}