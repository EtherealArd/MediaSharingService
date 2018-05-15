using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Model
{
    public static class WorkImage
    {
        public static BitmapImage ImageByByteArray(this byte[] array)
        {
            if (array == null || array.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(array))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public static byte[] ByteArrayByImage(this BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        public static BitmapFrame CreateResizedImage(this ImageSource source, int width, int height, int margin)
        {
            if (source == null)
                return null;
            var coefH = (double)width / (double)source.Height;
            var coefW = (double)height / (double)source.Width;


            if (coefW >= coefH)
            {
                height = (int)(source.Height * coefH);
                width = (int)(source.Width * coefH);
            }
            else
            {
                height = (int)(source.Height * coefW);
                width = (int)(source.Width * coefW);

            }
            var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);

            var group = new DrawingGroup();
            RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
            group.Children.Add(new ImageDrawing(source, rect));

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
                drawingContext.DrawDrawing(group);

            var resizedImage = new RenderTargetBitmap(
                width, height,         // Resized dimensions
                96, 96,                // Default DPI values
                PixelFormats.Default); // Default pixel format
            resizedImage.Render(drawingVisual);

            return BitmapFrame.Create(resizedImage);
        }
    }
}