// Notes:
// The rule: If any Rock of size m_OriginalRockSize destroyed, 
// then the game should create m_NewRocksCount new Rocks from
// pool m_PoolOfNewRocks

[System.Serializable]
public class RockReplacementsRule
{
	public PoolOfObjects m_PoolOfNewRocks;
	public int m_OriginalRockSize = 0;
	public int m_NewRocksCount = 0;
}
