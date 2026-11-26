using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FileHandler
    {
        public List<string> ReadLines(string path)
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                return lines;
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Ошибка: Файл не найден. Проверьте путь", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception("Ошибка: Нет доступа к файлу (запрещено системой)", ex);
            }
            catch (IOException ex)
            {
                throw new Exception("Ошибка сбоя чтения в процессе обработки файла. ФАЙЛ НЕ ПРОЧТЕН (Скорее всего есть пустые строки) Проверьте файл. ", ex);
            }


        }
    }
}
