//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace Game.Logic
{
    public partial class TDEquipment
    {

        		private long m_ID;
		private string m_Name;
		private string m_Part;
		private string m_SubType;
		private long m_Appearance;

        		public long ID{ get => m_ID;}
		public string Name{ get => m_Name;}
		public string Part{ get => m_Part;}
		public string SubType{ get => m_SubType;}
		public long Appearance{ get => m_Appearance;}


		public void ReadRow(SqliteDataReader reader)
        {
       	   
           		m_ID = (long)reader[0];
		m_Name = (string)reader[1];
		m_Part = (string)reader[2];
		m_SubType = (string)reader[3];
		m_Appearance = (long)reader[4];

        }
    }
}