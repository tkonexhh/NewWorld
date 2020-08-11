//Auto Generate Don't Edit it
using Mono.Data.Sqlite;

namespace GameWish.Game
{
    public partial class TDEquipmentAppearance
    {

        		private long m_ID;

        		public long ID
		{
			get {return m_ID;}
		}


		public void ReadRow(SqliteDataReader reader)
        {
       	   
           		m_ID = (long)reader[0];

        }
    }
}