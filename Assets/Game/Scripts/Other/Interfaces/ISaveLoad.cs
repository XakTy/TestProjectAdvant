namespace Game.Scripts.Other.Interfaces
{
	public interface ISaveLoad
	{
		public T Load<T>(string key) where T : new();
		public void Save<T>(T saveObject, string key);
	}
}