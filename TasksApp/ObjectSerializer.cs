using System.Text.Json;

namespace TasksApp
{
    public class ObjectSerializer
    {
        public async static Task SerializeToFile<T>(string filePath, T obj)
        {
            try
            {
                string json = JsonSerializer.Serialize(obj);
                await File.WriteAllTextAsync(filePath, json);  
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Field to serialize data", ex.Message, "OK");
            }
        }

        public static async Task<T> DeserializeFromFile<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = await File.ReadAllTextAsync(filePath);
                    return JsonSerializer.Deserialize<T>(json);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Field to deserialize data", ex.Message, "OK");
            }

            return default(T);
        }
    }
}
