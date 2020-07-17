//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace GameWish.Game
{
    public partial class TDEquipment
    {

        		private long m_ID;
		private string m_Name;
		private string m_Part;
		private long m_Appearance;
		private string m_Icon;

        		public long ID
		{
			get {return m_ID;}
		}
		public string Name
		{
			get {return m_Name;}
		}
		public string Part
		{
			get {return m_Part;}
		}
		public long Appearance
		{
			get {return m_Appearance;}
		}
		public string Icon
		{
			get {return m_Icon;}
		}


		public void ReadRow(SqliteDataReader reader)
        {
       	   
           			m_ID = (long)reader[0];
			m_Name = (string)reader[1];
			m_Part = (string)reader[2];
			m_Appearance = (long)reader[3];
			m_Icon = (string)reader[4];

        }
    }
}