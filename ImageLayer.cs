using System;
using System.Drawing;
using System.IO;

namespace ImageLab1
{
    // Класс, представляющий один слой изображения, хранящий изображение, наложение и прозрачность
    public class ImageLayer
    {
        public Bitmap Image { get; set; }
        public string FileName { get; set; }
        public BlendMode BlendMode { get; set; }
        public int Opacity { get; set; }
        public int Id { get; set; }

        public ImageLayer(Bitmap image, string fileName, int id)
        {
            Image = image;
            FileName = fileName;
            Id = id;
            BlendMode = BlendMode.Normal;
            Opacity = 100;
        }
        public void Dispose()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }
        public override string ToString()
        {
            string blendModeName = BlendMode.ToString();
            return $"Слой {Id}: {Path.GetFileName(FileName)} [{blendModeName}, {Opacity}%]";
        }
    }

    // Режимы наложения слоёв
    public enum BlendMode
    {
        Normal,         // Обычный слой
        Sum,            // Сумма цветов
        Difference,     // Модуль разности цветов
        Multiply,       // Умножение (I1 * I2 / 255)
        Screen,         // Осветление
        Average,        // Среднее арифметическое
        Min,            // Минимум из двух значений
        Max,            // Максимум из двух значений
        Overlay,        // Наложение
        SoftLight,      // Мягкий свет
        HardLight       // Жёсткий свет
    }
}