using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{
	private static BinaryFormatter formatter = new BinaryFormatter(); //Создание сериализатора 

	public static void SaveGame() //Метод для сохранения
	{
        string path = Application.persistentDataPath + "/Slot" + GameSettings.CurrentSettings.GetSlot() + ".save"; //Путь к сохранению. Вы можете использовать любое расширение
		
		FileStream fs = new FileStream (path, FileMode.Create); //Создание файлового потока

		SaveData data = new SaveData(); //Получение данных

		formatter.Serialize(fs, data); //Сериализация данных

		fs.Close(); //Закрытие потока

	}

	public static SaveData LoadGame(int slotNumber) //Метод загрузки
	{
        string path = Application.persistentDataPath + "/Slot" + slotNumber + ".save";

		if(File.Exists(path)) //Проверка существования файла сохранения
		{
			FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока

			SaveData data = formatter.Deserialize(fs) as SaveData; //Получение данных

			fs.Close(); //Закрытие потока

			return data; //Возвращение данных
		} 
		else 
		{
			return null; //Если файл не существует, будет возвращено null
		}
		
	}
}
