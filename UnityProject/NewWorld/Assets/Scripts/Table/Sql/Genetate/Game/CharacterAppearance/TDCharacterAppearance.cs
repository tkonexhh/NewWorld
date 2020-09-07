//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace Game.Logic
{
    public partial class TDCharacterAppearance
    {

        		private long m_ID;
		private long m_Sex;
		private string m_Part;
		private long m_Appearance;
		private string m_Name;

        		public long ID{ get => m_ID;}
		public long Sex{ get => m_Sex;}
		public string Part{ get => m_Part;}
		public long Appearance{ get => m_Appearance;}
		public string Name{ get => m_Name;}


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