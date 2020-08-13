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

        public long ID
        {
            get { return m_ID; }
        }
        public long SubID
        {
            get { return m_SubID; }
        }
        public string Name
        {
            get { return m_Name; }
        }
        public string Type
        {
            get { return m_Type; }
        }
        public string Icon
        {
            get { return m_Icon; }
        }
        public float Weight
        {
            get { return m_Weight; }
        }
        public long Quality
        {
            get { return m_Quality; }
        }


        public void ReadRow(SqliteDataReader reader)
        {

            m_ID = (long)reader[0];
            m_SubID = (long)reader[1];
            m_Name = (string)reader[2];
            m_Type = (string)reader[3];
            m_Icon = (string)reader[4];
            m_Weight = (float)reader[5];
            m_Quality = (long)reader[6];

        }
    }
}