/************************
	FileName:/Scripts/Table/Sql/Genetate/Game/Equipment/TDEquipment.cs
	CreateAuthor:neo.xu
	CreateTime:7/16/2020 2:58:41 PM
	Tip:7/16/2020 2:58:41 PM
************************/



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
	        get
	        {
	            return this.m_ID;
	        }
	    }
	    
	    public string Name
	    {
	        get
	        {
	            return this.m_Name;
	        }
	    }
	    
	    public string Part
	    {
	        get
	        {
	            return this.m_Part;
	        }
	    }
	    
	    public long Appearance
	    {
	        get
	        {
	            return this.m_Appearance;
	        }
	    }
	    
	    public string Icon
	    {
	        get
	        {
	            return this.m_Icon;
	        }
	    }
	}
	
}