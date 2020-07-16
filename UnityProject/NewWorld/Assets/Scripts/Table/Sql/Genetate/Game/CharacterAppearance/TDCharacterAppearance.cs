/************************
	FileName:/Scripts/Table/Sql/Genetate/Game/CharacterAppearance/TDCharacterAppearance.cs
	CreateAuthor:neo.xu
	CreateTime:7/16/2020 2:58:41 PM
	Tip:7/16/2020 2:58:41 PM
************************/



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
	        get
	        {
	            return this.m_ID;
	        }
	    }
	    
	    public long Sex
	    {
	        get
	        {
	            return this.m_Sex;
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
	    
	    public string Name
	    {
	        get
	        {
	            return this.m_Name;
	        }
	    }
	}
	
}