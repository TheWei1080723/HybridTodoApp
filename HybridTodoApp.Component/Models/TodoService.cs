using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HybridTodoApp.Models;

public class TodoService
{
    string file = string.Empty;

    /// <summary>
    /// 創建檔案路徑，且存在 本地端
    /// </summary>
    public TodoService()
    {
        file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "item.json");
    }

    /// <summary>
    /// 傳入要保存的專案
    /// </summary>
    /// <param name="items"></param>
    public void SaveItems(IEnumerable<TodoItem> items)
    {
        File.WriteAllText(file, JsonSerializer.Serialize(items));
    }

    /// <summary>
    /// 讀取 檔案
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TodoItem> LoadItems()
    {
        if (!File.Exists(file))
            return Enumerable.Empty<TodoItem>();

        var itemJson = File.ReadAllText(file);
        return JsonSerializer.Deserialize<IEnumerable<TodoItem>>(itemJson) ?? Enumerable.Empty<TodoItem>();
    }
}
