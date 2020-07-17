//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace GameWish.Game
{
    public partial class TDCharacterAppearance
    {

        private long m_ID;
        private long m_Sex;
        private string m_Part;
        private long m_Appearance;
        private string m_Name;

        public long ID
        {
            get { return m_ID; }
        }
        public long Sex
        {
            get { return m_Sex; }
        }
        public string Part
        {
            get { return m_Part; }
        }
        public long Appearance
        {
            get { return m_Appearance; }
        }
        public string Name
        {
            get { return m_Name; }
        }

        public void ReadRow(SqliteDataReader reader)
        {
            m_ID = (long)reader[0];
            m_Sex = (long)reader[1];
            m_Part = (string)reader[2];
            m_Appearance = (long)reader[3];
            m_Name = (string)reader[4];
        }

    }
}