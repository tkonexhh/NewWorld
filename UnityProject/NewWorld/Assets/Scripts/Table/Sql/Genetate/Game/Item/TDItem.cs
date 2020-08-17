//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace Game.Logic
{
    public partial class TDItem
    {

        private long m_ID;
        private long m_SubID;
        private string m_Name;
        private string m_Type;
        private string m_Icon;
        private float m_Weight;
        private long m_Quality;
        private long m_Width;
        private long m_Height;

        public long ID { get => m_ID; }
        public long SubID { get => m_SubID; }
        public string Name { get => m_Name; }
        public string Type { get => m_Type; }
        public string Icon { get => m_Icon; }
        public float Weight { get => m_Weight; }
        public long Quality { get => m_Quality; }
        public long Width { get => m_Width; }
        public long Height { get => m_Height; }


        public void ReadRow(SqliteDataReader reader)
        {

            m_ID = (long)reader[0];
            m_SubID = (long)reader[1];
            m_Name = (string)reader[2];
            m_Type = (string)reader[3];
            m_Icon = (string)reader[4];
            m_Weight = (float)reader[5];
            m_Quality = (long)reader[6];
            m_Width = (long)reader[7];
            m_Height = (long)reader[8];

        }
    }
}