using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageLab1
{
    public partial class Form1 : Form
    {
        private List<ImageLayer> layers;

        private int layerCounter;

        private ImageLayer selectedLayer;

        public Form1()
        {
            InitializeComponent();

            layers = new List<ImageLayer>();
            layerCounter = 0;

            // Заполняем ComboBox режимами наложения
            cmbBlendMode.Items.Clear();
            foreach (BlendMode mode in Enum.GetValues(typeof(BlendMode)))
            {
                cmbBlendMode.Items.Add(mode.ToString());
            }
            cmbBlendMode.SelectedIndex = 0;

            lstLayers.SelectedIndexChanged += LstLayers_SelectedIndexChanged;
            trbOpacity.ValueChanged += TrbOpacity_ValueChanged;
            cmbBlendMode.SelectedIndexChanged += CmbBlendMode_SelectedIndexChanged;
        }

        // Кнопка "Добавить изображение"
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Все файлы|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            Bitmap bitmap = new Bitmap(fileName);
                            ImageLayer layer = new ImageLayer(bitmap, fileName, layerCounter++);
                            layers.Add(layer);
                            UpdateLayersList();
                            RenderResult();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка загрузки файла {fileName}:\n{ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // Кнопка "Удалить слой"
        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {
            if (selectedLayer != null)
            {
                layers.Remove(selectedLayer);
                selectedLayer.Dispose();
                selectedLayer = null;
                UpdateLayersList();
                RenderResult();
            }
            else
            {
                MessageBox.Show("Выберите слой для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Кнопка "Обновить"
        private void btnRender_Click(object sender, EventArgs e)
        {
            RenderResult();
        }

        // Кнопка "Сохранить результат"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxResult.Image == null)
            {
                MessageBox.Show("Нет изображения для сохранения", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg|BMP|*.bmp";
                saveFileDialog.Title = "Сохранить результат";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBoxResult.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("Изображение сохранено!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения:\n{ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Кнопка "Переместить слой вверх"
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (selectedLayer != null)
            {
                int index = layers.IndexOf(selectedLayer);
                if (index < layers.Count - 1)
                {
                    layers.RemoveAt(index);
                    layers.Insert(index + 1, selectedLayer);
                    UpdateLayersList();
                    lstLayers.SelectedIndex = index + 1;
                    RenderResult();
                }
            }
        }

        // Кнопка "Переместить слой вниз"
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (selectedLayer != null)
            {
                int index = layers.IndexOf(selectedLayer);
                if (index > 0)
                {
                    layers.RemoveAt(index);
                    layers.Insert(index - 1, selectedLayer);
                    UpdateLayersList();
                    lstLayers.SelectedIndex = index - 1;
                    RenderResult();
                }
            }
        }

        // Обновление списка слоёв в ListBox
        private void UpdateLayersList()
        {
            lstLayers.Items.Clear();
            foreach (var layer in layers)
            {
                lstLayers.Items.Add(layer);
            }
        }

        // Выбор слоя в списке
        private void LstLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLayers.SelectedIndex >= 0 && lstLayers.SelectedIndex < layers.Count)
            {
                selectedLayer = layers[lstLayers.SelectedIndex];

                // Обновляем настройки в интерфейсе
                cmbBlendMode.SelectedItem = selectedLayer.BlendMode.ToString();
                trbOpacity.Value = selectedLayer.Opacity;
                lblOpacity.Text = $"Прозрачность: {selectedLayer.Opacity}%";
            }
        }

        // Изменение прозрачности
        private void TrbOpacity_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLayer != null)
            {
                selectedLayer.Opacity = trbOpacity.Value;
                lblOpacity.Text = $"Прозрачность: {trbOpacity.Value}%";
                UpdateLayersList();
                RenderResult();
            }
        }

        // Изменение режима наложения
        private void CmbBlendMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedLayer != null && cmbBlendMode.SelectedIndex >= 0)
            {
                selectedLayer.BlendMode = (BlendMode)Enum.Parse(typeof(BlendMode),
                    cmbBlendMode.SelectedItem.ToString());
                UpdateLayersList();
                RenderResult();
            }
        }

        // Все слои в одно изображение
        private void RenderResult()
        {
            if (layers.Count == 0)
            {
                pictureBoxResult.Image = null;
                return;
            }

            // Находим максимальный размер среди всех слоёв
            int maxWidth = 0;
            int maxHeight = 0;
            foreach (var layer in layers)
            {
                if (layer.Image.Width > maxWidth) maxWidth = layer.Image.Width;
                if (layer.Image.Height > maxHeight) maxHeight = layer.Image.Height;
            }

            // Создаём результирующее изображение
            Bitmap result = new Bitmap(maxWidth, maxHeight);

            // Рендерим каждый слой снизу вверх
            foreach (var layer in layers)
            {
                ApplyLayer(result, layer);
            }

            if (pictureBoxResult.Image != null)
            {
                pictureBoxResult.Image.Dispose();
            }
            pictureBoxResult.Image = result;
        }

        // Применение одного слоя к результирующему изображению
        private void ApplyLayer(Bitmap result, ImageLayer layer)
        {
            int opacity = layer.Opacity;
            BlendMode mode = layer.BlendMode;

            // Проходим по всем пикселям результата
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    int layerX = x - (result.Width - layer.Image.Width) / 2;
                    int layerY = y - (result.Height - layer.Image.Height) / 2;

                    if (layerX < 0 || layerX >= layer.Image.Width ||
                        layerY < 0 || layerY >= layer.Image.Height)
                    {
                        continue;
                    }

                    Color baseColor = result.GetPixel(x, y);
                    Color layerColor = layer.Image.GetPixel(layerX, layerY);

                    // Применяем режим наложения
                    Color newColor = ApplyBlendMode(baseColor, layerColor, mode);

                    // Применяем прозрачность
                    if (opacity < 100)
                    {
                        newColor = BlendWithOpacity(baseColor, newColor, opacity);
                    }

                    result.SetPixel(x, y, newColor);
                }
            }
        }

        // Применение режима наложения к двум цветам
        private Color ApplyBlendMode(Color baseColor, Color layerColor, BlendMode mode)
        {
            int r, g, b;

            switch (mode)
            {
                case BlendMode.Normal:
                    r = layerColor.R;
                    g = layerColor.G;
                    b = layerColor.B;
                    break;

                case BlendMode.Sum:
                    r = Math.Min(baseColor.R + layerColor.R, 255);
                    g = Math.Min(baseColor.G + layerColor.G, 255);
                    b = Math.Min(baseColor.B + layerColor.B, 255);
                    break;

                case BlendMode.Difference:
                    r = Math.Abs(baseColor.R - layerColor.R);
                    g = Math.Abs(baseColor.G - layerColor.G);
                    b = Math.Abs(baseColor.B - layerColor.B);
                    break;

                case BlendMode.Multiply:
                    r = (baseColor.R * layerColor.R) / 255;
                    g = (baseColor.G * layerColor.G) / 255;
                    b = (baseColor.B * layerColor.B) / 255;
                    break;

                case BlendMode.Screen:
                    r = 255 - ((255 - baseColor.R) * (255 - layerColor.R) / 255);
                    g = 255 - ((255 - baseColor.G) * (255 - layerColor.G) / 255);
                    b = 255 - ((255 - baseColor.B) * (255 - layerColor.B) / 255);
                    break;

                case BlendMode.Average:
                    r = (baseColor.R + layerColor.R) / 2;
                    g = (baseColor.G + layerColor.G) / 2;
                    b = (baseColor.B + layerColor.B) / 2;
                    break;

                case BlendMode.Min:
                    r = Math.Min(baseColor.R, layerColor.R);
                    g = Math.Min(baseColor.G, layerColor.G);
                    b = Math.Min(baseColor.B, layerColor.B);
                    break;

                case BlendMode.Max:
                    r = Math.Max(baseColor.R, layerColor.R);
                    g = Math.Max(baseColor.G, layerColor.G);
                    b = Math.Max(baseColor.B, layerColor.B);
                    break;

                case BlendMode.Overlay:
                    r = baseColor.R < 128 ? (2 * baseColor.R * layerColor.R / 255) :
                        255 - 2 * (255 - baseColor.R) * (255 - layerColor.R) / 255;
                    g = baseColor.G < 128 ? (2 * baseColor.G * layerColor.G / 255) :
                        255 - 2 * (255 - baseColor.G) * (255 - layerColor.G) / 255;
                    b = baseColor.B < 128 ? (2 * baseColor.B * layerColor.B / 255) :
                        255 - 2 * (255 - baseColor.B) * (255 - layerColor.B) / 255;
                    break;

                case BlendMode.SoftLight:
                    r = (1 - 2 * layerColor.R / 255) * baseColor.R * baseColor.R / 255 +
                        2 * layerColor.R / 255 * baseColor.R;
                    g = (1 - 2 * layerColor.G / 255) * baseColor.G * baseColor.G / 255 +
                        2 * layerColor.G / 255 * baseColor.G;
                    b = (1 - 2 * layerColor.B / 255) * baseColor.B * baseColor.B / 255 +
                        2 * layerColor.B / 255 * baseColor.B;
                    break;

                case BlendMode.HardLight:
                    r = layerColor.R < 128 ? (2 * baseColor.R * layerColor.R / 255) :
                        255 - 2 * (255 - baseColor.R) * (255 - layerColor.R) / 255;
                    g = layerColor.G < 128 ? (2 * baseColor.G * layerColor.G / 255) :
                        255 - 2 * (255 - baseColor.G) * (255 - layerColor.G) / 255;
                    b = layerColor.B < 128 ? (2 * baseColor.B * layerColor.B / 255) :
                        255 - 2 * (255 - baseColor.B) * (255 - layerColor.B) / 255;
                    break;

                default:
                    r = layerColor.R;
                    g = layerColor.G;
                    b = layerColor.B;
                    break;
            }

            return Color.FromArgb(r, g, b);
        }

        // Смешивание цвета с учётом прозрачности
        private Color BlendWithOpacity(Color baseColor, Color layerColor, int opacity)
        {
            float alpha = opacity / 100f;
            int r = (int)(baseColor.R * (1 - alpha) + layerColor.R * alpha);
            int g = (int)(baseColor.G * (1 - alpha) + layerColor.G * alpha);
            int b = (int)(baseColor.B * (1 - alpha) + layerColor.B * alpha);
            return Color.FromArgb(r, g, b);
        }

        // Очистка ресурсов при закрытии формы
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var layer in layers)
            {
                layer.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}