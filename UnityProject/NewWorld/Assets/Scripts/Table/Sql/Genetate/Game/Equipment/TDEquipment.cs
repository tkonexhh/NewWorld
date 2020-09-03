//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace Game.Logic
{
    public partial class TDEquipment
    {

        private long m_ID;
        private string m_Name;
        private string m_Part;
        private long m_Appearance;
        private string m_Icon;

        public long ID { get => m_ID; }
        public string Name { get => m_Name; }
        public string Part { get => m_Part; }
        public long Appearance { get => m_Appearance; }


        public void ReadRow(SqliteDataReader reader)
        {

            m_ID = (long)reader[0];
            m_Name = (string)reader[1];
            m_Part = (string)reader[2];
            m_Appearance = (long)reader[3];

        }
    }
}