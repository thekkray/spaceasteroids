/// <summary>
/// RockReplacementsConfig
/// Instead of one rock of size m_OriginalRockSize will be
/// created m_NewRocksCount rocks of size m_NewRocksSize
/// m_PoolOfNewRocks contains a link to pool to spawn new rocks
/// </summary>
[System.Serializable]
public class RockReplacementsRule
{
	public PoolOfObjects m_PoolOfNewRocks;
	public int m_OriginalRockSize = 0;
	public int m_NewRocksCount = 0;
}
