//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace Game.Logic
{
    public partial class TDEquipmentAppearance
    {

        		private long m_ID;
		private string m_Show;
		private string m_Hide;

        		public long ID{ get => m_ID;}
		public string Show{ get => m_Show;}
		public string Hide{ get => m_Hide;}


		public void ReadRow(SqliteDataReader reader)
        {
       	   
           		m_ID = (long)reader[0];
		m_Show = (string)reader[1];
		m_Hide = (string)reader[2];

        }
    }
}