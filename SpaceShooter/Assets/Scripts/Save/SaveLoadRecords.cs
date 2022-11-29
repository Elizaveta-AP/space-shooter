using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadRecords
{
    private static BinaryFormatter formatter = new BinaryFormatter(); //Создание сериализатора 
	

	public static void SaveLeaderboard() //Метод для сохранения
	{
        string path = Application.persistentDataPath + "/Leaderboard.save"; //Путь к сохранению. Вы можете использовать любое расширение
		
		FileStream fs = new FileStream (path, FileMode.Create); //Создание файлового потока

		LeaderboardData data = new LeaderboardData(); //Получение данных

		formatter.Serialize(fs, data); //Сериализация данных

		fs.Close(); //Закрытие потока
	}


	public static LeaderboardData LoadLeaderboard() //Метод загрузки
	{
        string path = Application.persistentDataPath + "/Leaderboard.save";

		if(File.Exists(path)) //Проверка существования файла сохранения
		{
			FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока

			LeaderboardData data = formatter.Deserialize(fs) as LeaderboardData; //Получение данных

			fs.Close(); //Закрытие потока

			return data; //Возвращение данных
		} 
		else 
		{
			return null; //Если файл не существует, будет возвращено null
		}
	}
}
