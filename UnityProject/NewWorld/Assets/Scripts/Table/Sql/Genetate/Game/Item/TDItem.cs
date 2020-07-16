/************************
	FileName:/Scripts/Table/Sql/Genetate/Game/Item/TDItem.cs
	CreateAuthor:neo.xu
	CreateTime:7/16/2020 2:58:41 PM
	Tip:7/16/2020 2:58:41 PM
************************/



namespace GameWish.Game
{
	public partial class TDItem
	{
	    
	    private long m_ID;
	    
	    private long m_SubID;
	    
	    private string m_Name;
	    
	    private string m_Type;
	    
	    private string m_Icon;
	    
	    private float m_Weight;
	    
	    public long ID
	    {
	        get
	        {
	            return this.m_ID;
	        }
	    }
	    
	    public long SubID
	    {
	        get
	        {
	            return this.m_SubID;
	        }
	    }
	    
	    public string Name
	    {
	        get
	        {
	            return this.m_Name;
	        }
	    }
	    
	    public string Type
	    {
	        get
	        {
	            return this.m_Type;
	        }
	    }
	    
	    public string Icon
	    {
	        get
	        {
	            return this.m_Icon;
	        }
	    }
	    
	    public float Weight
	    {
	        get
	        {
	            return this.m_Weight;
	        }
	    }
	}
	
}